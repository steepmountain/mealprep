<template>
  <div class="ingredient-list">
    <cv-form id="meal-form">
      <IngredientRow v-for="item in items" v-bind:key="item.id" v-bind:index="item.id" v-on:change="updateCalories" />
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
      items: [{ id: 1, rowCalories: 0 }]
    };
  },
  components: {
    IngredientRow
  },
  methods: {
    updateCalories(row) {
      var current = this.items.filter(child => child.id == row.id);
      current.rowCalories = row.calories;

      this.sumCalories = this.items.reduce((sum, child) => {
        sum += child.rowCalories;
      });
    },

    addRow() {
      this.currentIndex++;
      this.items.push({ id: this.currentIndex, rowCalories: 0 });
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
