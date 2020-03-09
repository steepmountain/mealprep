<template>
  <cv-structured-list-item>
    <cv-structured-list-data>
      <cv-loading :overlay="true" v-if="searchState == SearchStates.NutrientSearching" />
      <cv-combo-box
        class="input-margin-fix"
        v-loading="searchState == SearchStates.InstantSearching"
        :label="$t('name')"
        :options="ingredientOptions"
        @filter="onFilter"
        @change="nutrientsSearch"
        ref="ingredientNameCombobox"
      ></cv-combo-box>
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-number-input v-model="ingredient.unitAmount" min="0" />
    </cv-structured-list-data>
    <cv-structured-list-data>
      <cv-text-input v-model="computedUnit" :placeholder="$t('measurementUnit')" />
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
import axios from "axios";
import { SearchState } from "../models/SearchState";
import _ from "lodash";

const ingredientService = new IngredientService();

export default {
  props: {
    ingredient: {
      name: { type: String, default: "" },
      unitAmount: { type: Number, default: 1 },
      unit: String,
      caloriesPerUnit: Number,
      totalCalories: Number
    },
    numberOfMeals: Number
  },
  data() {
    return {
      SearchStates: SearchState,
      searchState: SearchState.NotSearching,
      ingredientOptions: []
    };
  },
  components: {
    Delete16
  },
  computed: {
    computedUnit: {
      get() {
        return this.ingredient.unit;
      },
      set(value) {
        this.ingredient.unit = value;
      }
    },
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
  watch: {
    computedUnit(newValue) {
        this.ingredient.unit = newValue;
        this.debounceNutrientSearch();
    }
  },
  created() {
      this.debounceNutrientSearch = _.debounce(this.nutrientsSearch, 500);
      this.debounceInstantSearch = _.debounce(this.instantSearch, 500);
  },
  methods: {
    resetCombobox() {
      this.ingredientOptions = [];
    },
    onFilter(filter) {
      this.ingredient.name = filter ?? "";
      this.debounceInstantSearch();
    },
    instantSearch() {
      if (this.ingredient.name < 2) {
        return;
      }
      this.startInstantSearch();
      let queryString = `${this.ingredient.name}`;
      axios
        .get(`/api/food/lookup?query=${queryString}`)
        .then(response => {
          this.resetCombobox();
          response.data.forEach(element => {
            this.ingredientOptions.push({
              name: element.name,
              value: element.name,
              label: element.name
            });
          });
        })
        .catch(error => window.console.log(error.Response))
        .then(() => this.endInstantSearch());
    },
    startInstantSearch() {
      this.$refs.ingredientNameCombobox.doOpen(false);
      this.searchState = this.SearchStates.InstantSearching;
    },
    endInstantSearch() {
      this.searchState = this.SearchStates.HasSearched;
      this.$refs.ingredientNameCombobox.doOpen(true);
    },
    nutrientsSearch() {
      if (this.searchState != this.SearchStates.HasSearched) {
        return;
      }
      this.startNutrientSearch();
      let queryString = `${this.ingredient.name} ${this.ingredient.unitAmount} ${this.ingredient.unit}`.trim();
      axios
        .get(`/api/food/nutrition?query=${queryString}`)
        .then(response => {
          let element = response.data[0];
          this.ingredient.name = element.name;
          this.ingredient.unit = element.measurementUnit;
          this.ingredient.caloriesPerUnit =
            Math.round(
              (element.caloriesPerMeasurementUnit + Number.EPSILON) * 100
            ) / 100;
        })
        .catch(error => window.console.log(error))
        .then(() => this.endNutrientSearch());
    },
    startNutrientSearch() {
      this.searchState = this.SearchStates.NutrientSearching;
      this.$refs.ingredientNameCombobox.doOpen(false);
    },
    endNutrientSearch() {
      this.searchState = this.SearchStates.HasSearched;
      this.$refs.ingredientNameCombobox.doOpen(false);
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

.input-margin-fix {
  margin-top: 0.5rem;
}
</style>
