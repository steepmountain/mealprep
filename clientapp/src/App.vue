<template>
  <div id="app">
    <div>
      <cv-header aria-label="Carbon header" class="header">
        <cv-header-name href="javascript:void(0)" prefix="💪">[Prep That Meal]</cv-header-name>
        <div class="header-function-wrapper">
          <LocaleSwitcher @change-locale="forceRender" :locales="['en', 'no']" />
        <cv-button @click="showSaveMealModal">{{ $t('save' )}}</cv-button>
          <cv-button kind="secondary" @click="showLoadMealModal">{{ $t('open') }}</cv-button>
        </div>
      </cv-header>

      <h1 class="logo">💪</h1>
      <h1>Prep That Meal</h1>
      <IngredientList ref="ingredientList" v-bind:recipe="recipe" />

      
      <p class="faded">
      {{ $t('poweredByNutritionix')}}
      </p>
      
      <LoadMealModal
        v-bind:showModal="loadMealModalVisible"
        v-on:hide="hideLoadMealModal"
        v-on:load-recipe="loadRecipe"
      />
      <SaveMealModal
        v-bind:showModal="saveMealModalVisible"
        v-on:hide="hideSaveMealModal"
        v-on:save="saveMeal"
        ref="saveModal"
      />

      <div class="fixed-bottom" v-if="showFeatureToast">
        <cv-toast-notification
          @close="closeFeatureToast"
          :title="$t('nb')"
          :sub-title="$t('featureToastMessage')"
        ></cv-toast-notification>
      </div>
    </div>
  </div>
</template>

<script>
import IngredientList from "./components/IngredientList.vue";
import LoadMealModal from "./components/modals/LoadMealModal.vue";
import SaveMealModal from "./components/modals/SaveMealModal.vue";
import LocaleSwitcher from "./components/LocaleSwitcher.vue";

export default {
  name: "app",
  components: {
    IngredientList,
    LoadMealModal,
    SaveMealModal,
    LocaleSwitcher
  },
  data() {
    return {
      loadMealModalVisible: false,
      saveMealModalVisible: false,
      savedSuccessfully: true,
      showFeatureToast: true,
      recipe: {
        ingredients: [],
        numberOfMeals: 1
      }
    };
  },
  methods: {
    showLoadMealModal() {
      this.loadMealModalVisible = true;
    },
    hideLoadMealModal() {
      this.loadMealModalVisible = false;
    },
    showSaveMealModal() {
      this.saveMealModalVisible = true;
    },
    hideSaveMealModal() {
      this.saveMealModalVisible = false;
    },
    saveMeal(recipeName) {
      let result = this.$refs.ingredientList.saveRecipe(recipeName);
      this.$refs.saveModal.setSaveState(result);
    },
    loadRecipe(recipe) {
      this.recipe = recipe;
    },
    closeFeatureToast() {
      this.showFeatureToast = false;
    },
    forceRender() {
      this.$forceUpdate();
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 4rem;
}

#meal-form {
  max-width: 1200px;
  margin: 0 auto;
}

.logo {
  font-size: 6rem;
  line-height: 8rem;
}

h1 {
  margin: 3rem !important;
}

.header {
  display: flex;
  justify-content: space-between;
}

.header-function-wrapper {
  display: flex;
}

.fixed-bottom {
  position: fixed;
  bottom: 0;
  right: 0;
  text-align: left;
}

.faded {
    color: #848181;
    font-size: 0.8rem;
    position: fixed;
    bottom: 0.7rem;
    left: 1rem;
}
</style>
