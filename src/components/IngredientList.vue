<template>
  <div class="ingredient-list">
    <cv-form id="meal-form">
      <div class="button-toolbar">
        <cv-number-input
          label="Antall måltid"
          v-model="numberOfMeals"
          min="1"
          @input="calculateSum"
        />
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
            v-for="item in items"
            v-bind:key="item.id"
            v-bind:numberOfMeals="numberOfMeals"
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
  data() {
    return {
      sumCalories: 0,
      sumCaloriesPerMeal: 0,
      currentIndex: 1,
      numberOfMeals: 1,
      items: []
    };
  },
  components: {
    IngredientRow
  },
  mounted: function() {
    this.addRow();
  },
  methods: {
    update(mutated) {
      let original = this.items.filter(item => item.index == mutated.index);
      let itemIndex = this.getItemIndex(mutated.index);
      let updated = { ...original, ...mutated };
      this.items.splice(itemIndex, 1, updated);

      this.calculateSum();
    },

    getItemIndex(itemIndex) {
      return this.items.findIndex(element => element.index == itemIndex);
    },

    onAutoRow(itemIndex) {
      let arrayIndex = this.getItemIndex(itemIndex);
      let item = this.items[arrayIndex];
      if (this.isLastItem(item) && this.isRowFilled(item)) {
        this.addRow();
      }
    },

    isLastItem(item) {
      return this.items[this.items.length - 1].index == item.index;
    },

    isRowFilled(item) {
      return item.caloriesPerUnit > 0 && item.unitAmount > 0;
    },

    calculateSum() {
      this.sumCalories = this.items
        .map(item => item.totalCalories)
        .reduce((sum, next) => sum + next, 0);

      this.sumCaloriesPerMeal = ingredientService.caloriesPerMeal(
        this.sumCalories,
        this.numberOfMeals
      );
    },

    removeRow(index) {
      let itemIndex = this.items.findIndex(element => element.index == index);
      this.items.splice(itemIndex, 1);
      this.calculateSum();
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
      this.items.push(ingredient);
    },
    saveRecipe(recipeName) {
      let allItems = localStorageService.load();
      allItems.push({
        name: recipeName,
        ingredients: this.items.map(ingredient => {
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
