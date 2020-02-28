<template>
  <div class="ingredient-list">
    <cv-form id="meal-form">
      <div class="button-toolbar">
        <cv-number-input label="Antall måltid" v-model="recipe.numberOfMeals" min="1" />
        <cv-button @click="addRow" type="button">Ny rad</cv-button>
      </div>
      <cv-structured-list>
        <template slot="headings">
          <cv-structured-list-heading>Ingrediens</cv-structured-list-heading>
          <cv-structured-list-heading>Mengde</cv-structured-list-heading>
          <cv-structured-list-heading>Måleenhet</cv-structured-list-heading>
          <cv-structured-list-heading>Kalorier per målenehet</cv-structured-list-heading>
          <cv-structured-list-heading>Kalorier per måltid</cv-structured-list-heading>
          <cv-structured-list-heading>Total kalorier</cv-structured-list-heading>
          <cv-structured-list-heading></cv-structured-list-heading>
        </template>
        <template slot="items">
          <IngredientRow
            v-for="item in recipe.ingredients"
            v-bind:key="item.id"
            v-bind:numberOfMeals="recipe.numberOfMeals"
            v-bind:initialIngredient="item"
            v-on:remove-row="removeRow"
            v-on:change="update"
            v-on:auto-row="onAutoRow"
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
    }
  },
  components: {
    IngredientRow
  },
  mounted: function() {
    if (this.recipe.ingredients.length == 0) {
      this.addRow();
    }
  },
  methods: {
    update(mutated) {
      let original = this.recipe.ingredients.filter(
        item => item.index == mutated.index
      );
      let itemIndex = this.getItemIndex(mutated.index);
      let updated = { ...original, ...mutated };
      this.recipe.ingredients.splice(itemIndex, 1, updated);
    },

    getItemIndex(itemIndex) {
      return this.recipe.ingredients.findIndex(
        element => element.index == itemIndex
      );
    },

    onAutoRow(itemIndex) {
      let arrayIndex = this.getItemIndex(itemIndex);
      let item = this.recipe.ingredients[arrayIndex];
      if (this.isLastItem(item) && this.isRowFilled(item)) {
        this.addRow();
      }
    },

    isLastItem(item) {
      return (
        this.recipe.ingredients[
          this.recipe.ingredients.length - 1
        ].index == item.index
      );
    },

    isRowFilled(item) {
      return item.caloriesPerUnit > 0 && item.unitAmount > 0;
    },

    removeRow(index) {
      let itemIndex = this.recipe.ingredients.findIndex(
        element => element.index == index
      );
      this.recipe.ingredients.splice(itemIndex, 1);
    },

    addRow() {
      this.currentIndex++;
      let ingredient = {
        key: this.currentIndex,
        index: this.currentIndex,
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
