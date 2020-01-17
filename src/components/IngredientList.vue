<template>
  <div class="ingredient-list">
    <cv-form id="meal-form">
      <IngredientRow
        v-for="item in items"
        v-bind:key="item.id"
        v-bind:ingredientIn="item"
        v-on:change="update"
      />
    </cv-form>
    Total calories: {{sumCalories}}
    <cv-button @click="addRow">Ny rad</cv-button>
  </div>
</template>

<script>
import IngredientRow from "./IngredientRow.vue";
// Todo: make a model of row and send it down. edit the model in the row and see the edits up here
export default {
  name: "app",
  data() {
    return {
      sumCalories: 0,
      currentIndex: 1,
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
      let current = this.items.filter(item => item.index == mutated.index);
      let itemIndex = this.items.indexOf(current);
      let updated = { ...current, ...mutated };
      this.items.splice(itemIndex, 1, updated);

      this.sumCalories = this.items
        .map(item => item.totalCalories)
        .reduce((sum, next) => sum + next, 0);
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
</style>
