<template>
  <cv-structured-list-item>
    <cv-structured-list-data>
      <cv-text-input v-model="ingredient.name" placeholder="Ingrediens" />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-number-input v-model="ingredient.unitAmount" min="0" @input="calculateCalories" v-on:blur="$emit('auto-row', ingredient.index)"/>
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-text-input v-model="ingredient.unit" placeholder="Måleenhet" />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-number-input v-model="ingredient.caloriesPerUnit" min="0" @input="calculateCalories" v-on:blur="$emit('auto-row', ingredient.index)"/>
    </cv-structured-list-data>
    <cv-structured-list-data>{{caloriesPerMeal}}</cv-structured-list-data>
    <cv-structured-list-data>{{ingredient.totalCalories}}</cv-structured-list-data>
    <cv-structured-list-data>
      <cv-button @click="$emit('remove-row', ingredient.index)" kind="danger">
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
    initialIngredient: {
      index: Number,
      name: String,
      unitAmount: Number,
      unit: String,
      caloriesPerUnit: Number,
      totalCalories: Number
    },
    numberOfMeals: Number
  },
  data() {
    return {
      ingredient: {
        index: this.initialIngredient.index,
        name: this.initialIngredient.name,
        unitAmount: this.initialIngredient.unitAmount,
        unit: this.initialIngredient.unit,
        caloriesPerUnit: this.initialIngredient.caloriesPerUnit,
        totalCalories: this.initialIngredient.totalCalories
      }
    };
  },
  components: {
    Delete16
  },
  computed: {
    caloriesPerMeal: function() {
      return ingredientService.caloriesPerMeal(
        this.ingredient.totalCalories,
        this.numberOfMeals
      );
    }
  },
  methods: {
    calculateCalories() {
      if (
        this.ingredient.caloriesPerUnit > 0 &&
        this.ingredient.unitAmount > 0
      ) {
        this.ingredient.totalCalories = ingredientService.calculateIngredientCalories(
          this.ingredient.caloriesPerUnit,
          this.ingredient.unitAmount
        );
      } else {
        this.ingredient.totalCalories = 0;
      }
      this.$emit("change", this.ingredient);
    }
  }
};
</script>

<style>
.row-button {
    background: red !important;
}

.row-button:active, .row-button:hover {
    outline: 2px solid white !important;
    outline-offset: -4px;
}

.row-button svg {
    fill: white;
    outline: white;
}
</style>
