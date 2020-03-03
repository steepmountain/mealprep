<template>
  <cv-structured-list-item>
    <cv-structured-list-data>
      <cv-text-input v-model="ingredient.name" placeholder="Ingrediens" />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-number-input
        v-model="ingredient.unitAmount"
        min="0"
      />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-text-input v-model="ingredient.unit" placeholder="Måleenhet" />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-number-input
        v-model="ingredient.caloriesPerUnit"
        min="0"
      />
    </cv-structured-list-data>
    <cv-structured-list-data>{{caloriesPerMeal}}</cv-structured-list-data>
    <cv-structured-list-data>{{totalCalories}}</cv-structured-list-data>
    <cv-structured-list-data>
      <cv-button  kind="danger" @click="$emit('remove-row', ingredient)" type="button">
        Fjern
        <Delete16 class="bx--btn__icon" />
      </cv-button>
    </cv-structured-list-data>
  </cv-structured-list-item>
</template>

<script>
import IngredientService from "../services/IngredientService";
import Delete16 from "@carbon/icons-vue/es/delete/16";

const ingredientService = new IngredientService();

export default {
  props: {
    ingredient: {
      name: String,
      unitAmount: Number,
      unit: String,
      caloriesPerUnit: Number,
      totalCalories: Number
    },
    numberOfMeals: Number
  },
  components: {
    Delete16
  },
  computed: {
    caloriesPerMeal: function() {
      return ingredientService.caloriesPerMeal(
        ingredientService.calculateIngredientCalories(
          this.ingredient.caloriesPerUnit,
          this.ingredient.unitAmount
        ),
        this.numberOfMeals
      );
    },
    totalCalories: function() {
      return ingredientService.calculateIngredientCalories(
        this.ingredient.caloriesPerUnit,
        this.ingredient.unitAmount
      );
    }
  },
};
</script>

<style>
.row-button {
  background: red !important;
}

.row-button:active,
.row-button:hover {
  outline: 2px solid white !important;
  outline-offset: -4px;
}

.row-button svg {
  fill: white;
  outline: white;
}
</style>
