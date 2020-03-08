<template>
  <cv-structured-list-item>
    <cv-structured-list-data>
      <cv-text-input
        v-if="searchState == SearchStates.TextBox"
        v-model="ingredient.name"
        :placeholder="$t('name')"
      />
      <cv-button
        kind="primary"
        type="button"
        v-if="searchState == SearchStates.TextBox"
        @click="actionChange"
      >
        {{ $t('search') }}
        <Search16 class="bx--btn__icon" />
      </cv-button>

      <cv-combo-box
        v-if="searchState == SearchStates.ComboBox"
        :label="$t('chooseOne')"
        :options="ingredientOptions"
        @change="nutrients"
      ></cv-combo-box>
      <cv-button
        kind="danger"
        type="button"
        v-if="searchState == SearchStates.ComboBox"
        @click="resetCombobox"
      >
        {{ $t('reset') }}
        <Search16 class="bx--btn__icon" />
      </cv-button>
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-number-input v-model="ingredient.unitAmount" min="0" />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-text-input v-model="ingredient.unit" :placeholder="$t('measurementUnit')" />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-number-input v-model="ingredient.caloriesPerUnit" min="0" />
    </cv-structured-list-data>
    <cv-structured-list-data>{{caloriesPerMeal}}</cv-structured-list-data>
    <cv-structured-list-data>{{totalCalories}}</cv-structured-list-data>
    <cv-structured-list-data>
      <cv-button kind="danger" @click="$emit('remove-row', ingredient)" type="button">
        {{ $t('remove') }}
        <Delete16 class="bx--btn__icon" />
      </cv-button>
    </cv-structured-list-data>
  </cv-structured-list-item>
</template>

<script>
import IngredientService from "../services/IngredientService";
import Delete16 from "@carbon/icons-vue/es/delete/16";
import Search16 from "@carbon/icons-vue/es/search/16";
import axios from "axios";
import { SearchState } from "../models/SearchState";

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
    numberOfMeals: Number,
    autoLookup: {
      default: true,
      type: Boolean
    }
  },
  data() {
    return {
      SearchStates: SearchState,
      searchState: SearchState.TextBox,
      ingredientOptions: [],
      iconUrl: "https://img.icons8.com/material/4ac144/256/user-male.png"
    };
  },
  components: {
    Delete16,
    Search16
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
  methods: {
    resetCombobox() {
      this.searchState = this.SearchStates.TextBox;
      this.ingredientOptions = [];
    },
    actionChange() {
      if (!this.autoLookup || this.ingredient.name < 2) {
        return;
      }

      //   let unitAmount = 1;
      let queryString = `${this.ingredient.name}`; //   ${unitAmount} ${this.ingredient.unit}`.trim();

      axios.get(`/api/food/lookup?query=${queryString}`).then(response => {
        response.data.forEach(element => {
          this.ingredientOptions.push({
            name: element.name,
            value: element.name,
            label: element.name
          });
          this.searchState = this.SearchStates.ComboBox;
        });
      });
    },
    nutrients() {
      let queryString = `${this.ingredient.name} ${this.ingredientOptions.unitAmount} ${this.ingredient.unit}`.trim();
      axios.get(`/api/food/nutrition?query=${queryString}`).then(response => {
        let element = response.data[0];
        this.ingredient.name = element.name;
        this.ingredient.unitAmount = element.amount;
        this.ingredient.unit = element.measurementUnit;
        this.ingredient.caloriesPerUnit =
          Math.round(
            (element.caloriesPerMeasurementUnit + Number.EPSILON) * 100
          ) / 100;
      });
    }
  }
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
