<template>
  <div class="ingredient-list">
    <cv-form id="meal-form">
      <div class="button-toolbar">
        <cv-number-input :label="numberOfMealsLabel" v-model="recipe.numberOfMeals" min="1" />
        <cv-button @click="addRow" type="button">{{ $t('newRow') }}</cv-button>
      </div>
      <cv-structured-list>
        <template slot="headings">
          <cv-structured-list-heading>{{ $t('ingredient') }}</cv-structured-list-heading>
          <cv-structured-list-heading>{{ $t('amount') }}</cv-structured-list-heading>
          <cv-structured-list-heading>{{ $t('measurementUnit') }}</cv-structured-list-heading>
          <cv-structured-list-heading>{{ $t('caloriesPerMeasurementUnit') }}t</cv-structured-list-heading>
          <cv-structured-list-heading>{{ $t('caloriesPerMeal') }}</cv-structured-list-heading>
          <cv-structured-list-heading>{{ $t('totalCalories') }}</cv-structured-list-heading>
          <cv-structured-list-heading></cv-structured-list-heading>
        </template>
        <template slot="items">
          <IngredientRow
            v-for="(item, index) in recipe.ingredients"
            v-bind:key="index"
            v-bind:numberOfMeals="recipe.numberOfMeals"
            v-bind:ingredient="item"
            v-on:remove-row="removeRow"
          />

          <cv-structured-list-data></cv-structured-list-data>
          <cv-structured-list-data></cv-structured-list-data>
          <cv-structured-list-data></cv-structured-list-data>
          <cv-structured-list-data></cv-structured-list-data>
          <cv-structured-list-data>{{sumCaloriesPerMeal}}</cv-structured-list-data>
          <cv-structured-list-data>{{sumCalories}}</cv-structured-list-data>
          <cv-structured-list-data></cv-structured-list-data>
        </template>
      </cv-structured-list>
    </cv-form>
  </div>
</template>

<script>
import IngredientRow from "./IngredientRow.vue";
import IngredientService from "../services/IngredientService";
import LocalStorageService from "../services/LocalStorageService";
import { SaveStates } from "../models/SaveStates";

const ingredientService = new IngredientService();
const localStorageIndex = "recipes";
const localStorageService = new LocalStorageService(localStorageIndex);

export default {
  props: {
    recipe: {
      name: String,
      numberOfMeals: Number,
      ingredients: Array
    }
  },
  computed: {
    sumCalories: function() {
      return this.recipe.ingredients
        .map(item =>
          ingredientService.calculateIngredientCalories(
            item.caloriesPerUnit,
            item.unitAmount
          )
        )
        .reduce((sum, next) => sum + next, 0);
    },
    sumCaloriesPerMeal: function() {
      return ingredientService.caloriesPerMeal(
        this.recipe.ingredients
          .map(item =>
            ingredientService.calculateIngredientCalories(
              item.caloriesPerUnit,
              item.unitAmount
            )
          )
          .reduce((sum, next) => sum + next, 0),
        this.recipe.numberOfMeals
      );
    },
    numberOfMealsLabel: function(){
        return this.$t("numberOfMeals");
    }
  },
  components: {
    IngredientRow
  },
  mounted() {
    if (this.recipe.ingredients.length == 0) {
      this.addRow();
    }
  },
  methods: {
    removeRow(ingredient) {
      let index = this.recipe.ingredients.indexOf(ingredient);
      this.recipe.ingredients.splice(index, 1);
    },

    addRow() {
      let ingredient = {
        name: "",
        unitAmount: 0,
        unit: "",
        caloriesPerUnit: 0,
        totalCalories: 0
      };
      this.recipe.ingredients.push(ingredient);
    },

    saveRecipe(recipeName) {
      let allItems = localStorageService.load();
      allItems.push({
        name: recipeName,
        numberOfMeals: this.recipe.numberOfMeals,
        ingredients: this.recipe.ingredients.map(ingredient => {
          return {
            name: ingredient.name,
            unitAmount: ingredient.unitAmount,
            unit: ingredient.unit,
            caloriesPerUnit: ingredient.caloriesPerUnit
          };
        })
      });
      localStorageService.save(allItems);
      return SaveStates.Success;
    }
  }
};
</script>

<style>
.ingredient-row {
  display: flex;
  justify-content: space-between;
  margin-bottom: 2rem;
}

.button-toolbar {
  display: flex;
  justify-content: flex-end;
}

.cv-structured-list-data {
  padding-top: 0.7rem;
  padding-bottom: 0.7rem;
}
</style>
