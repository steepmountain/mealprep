<template>
  <cv-structured-list-item>
      <cv-structured-list-data>
      <cv-button v-on:click="$emit('remove-row', ingredient.index)" type="button" kind="danger">Fjern</cv-button>
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-text-input v-model="ingredient.name" placeholder="Ingrediens" />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-number-input v-model="ingredient.amount" min="0" @input="calculateCalories" />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-text-input v-model="ingredient.unit" placeholder="Måleenhet" />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-number-input v-model="ingredient.caloriesPerAmount" min="0" @input="calculateCalories" />
    </cv-structured-list-data>

    <cv-structured-list-data>{{ingredient.totalCalories}}</cv-structured-list-data>
  </cv-structured-list-item>
</template>

<script>
export default {
  props: {
    ingredientIn: {
      index: Number,
      name: String,
      amount: Number,
      unit: String,
      caloriesPerAmount: Number,
      totalCalories: Number
    }
  },
  data() {
    return {
      ingredient: {
        index: this.ingredientIn.index,
        name: this.ingredientIn.name,
        amount: this.ingredientIn.amount,
        unit: this.ingredientIn.unit,
        caloriesPerAmount: this.ingredientIn.caloriesPerAmount,
        totalCalories: this.ingredientIn.totalCalories
      }
    };
  },
  methods: {
    calculateCalories() {
      if (this.ingredient.caloriesPerAmount > 0 && this.ingredient.amount > 0) {
        this.ingredient.totalCalories =
          this.ingredient.caloriesPerAmount * this.ingredient.amount;
      } else {
        this.ingredient.totalCalories = 0;
      }
      this.$emit("change", this.ingredient);
    }
  }
};
</script>

<style scoped>
</style>
