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
          <cv-structured-list-heading></cv-structured-list-heading>
          <cv-structured-list-heading>Ingrediens</cv-structured-list-heading>
          <cv-structured-list-heading>Mengde</cv-structured-list-heading>
          <cv-structured-list-heading>Måleenhet</cv-structured-list-heading>
          <cv-structured-list-heading>Kalorier per målenehet</cv-structured-list-heading>
          <cv-structured-list-heading>Total kalorier</cv-structured-list-heading>
        </template>
        <template slot="items">
          <IngredientRow
            v-for="item in items"
            v-bind:key="item.id"
            v-bind:ingredientIn="item"
            v-on:remove-row="removeRow"
            v-on:change="update"
          />

          <cv-structured-list-data></cv-structured-list-data>
          <cv-structured-list-data></cv-structured-list-data>
          <cv-structured-list-data></cv-structured-list-data>
          <cv-structured-list-data></cv-structured-list-data>
          <cv-structured-list-data></cv-structured-list-data>
          <template v-if="numberOfMeals > 1">
            <cv-structured-list-data>
              {{ formatSum(sumCaloriesPerMeal)}} (
              <strong>{{ formatSum(sumCalories)}}</strong>)
            </cv-structured-list-data>
          </template>
          <template v-else>
            <cv-structured-list-data>{{ formatSum(sumCaloriesPerMeal)}}</cv-structured-list-data>
          </template>
        </template>
      </cv-structured-list>
    </cv-form>
  </div>
</template>

<script>
import IngredientRow from "./IngredientRow.vue";

export default {
  name: "app",
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
    formatSum(number) {
      if (Number.isInteger(number)) {
        return number;
      } else {
        return Number(number).toFixed(2);
      }
    },
    update(mutated) {
      let original = this.items.filter(item => item.index == mutated.index);
      let itemIndex = this.items.findIndex(
        element => element.index == mutated.index
      );
      let updated = { ...original, ...mutated };
      this.items.splice(itemIndex, 1, updated);

      this.calculateSum();
    },

    calculateSum() {
      this.sumCalories = this.items
        .map(item => item.totalCalories)
        .reduce((sum, next) => sum + next, 0);

      this.sumCaloriesPerMeal = this.sumCalories / this.numberOfMeals;
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
        amount: 0,
        unit: "",
        caloriesPerAmount: 0,
        totalCalories: 0
      };
      this.items.push(ingredient);
    }
  }
};
</script>

<style scoped>
.ingredient-row {
  display: flex;
  justify-content: space-between;
  margin-bottom: 2rem;
}

.bx--form-item {
  margin: 0 40px;
}

.button-toolbar {
  display: flex;
  justify-content: flex-end;
}
</style>
