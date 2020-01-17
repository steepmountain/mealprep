<template>
  <div class="ingredient-row">
    <cv-text-input label="Ingrediens" v-model="ingredient.name" placeholder="Ingrediens" />

    <cv-number-input label="Mengde" v-model="ingredient.amount" min="0" @input="calulcateCalories" />

    <cv-text-input
      label="Måleenhet"
      v-model="ingredient.unit"
      placeholder="Måleenhet"
      @input="$emit('update-unit', $event.target.value)"
    />

    <cv-number-input
      label="Kalorier per måleenhet"
      v-model="ingredient.caloriesPerAmount"
      min="0"
      @input="calulcateCalories"
    />
    {{ingredient.totalCalories}}
  </div>
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
    calulcateCalories() {
      if (this.ingredient.caloriesPerAmount > 0 && this.ingredient.amount > 0) {
        this.ingredient.totalCalories = this.ingredient.caloriesPerAmount * this.ingredient.amount;
      } else {
        this.ingredient.totalCalories = 0;
      }
      this.$emit(
        "change",
        this.ingredient
      );
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
