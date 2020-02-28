<template>
  <div id="app">
    <div>
      <cv-header aria-label="Carbon header" class="header">
        <cv-header-name href="javascript:void(0)" prefix="💪">[Prep That Meal]</cv-header-name>
        <div>
          <cv-button @click="showSaveMealModal">Lagre</cv-button>
          <cv-button kind="secondary" @click="showLoadMealModal">Åpne</cv-button>
        </div>
      </cv-header>

      <h1 class="logo">💪</h1>
      <h1>Prep That Meal</h1>

      <IngredientList ref="ingredientList" v-bind:recipe="recipe"/>

      <LoadMealModal
        v-bind:showModal="loadMealModalVisible"
        v-on:hide="hideLoadMealModal"
        v-on:load-recipe="loadRecipe"
      />
      <SaveMealModal
        v-bind:showModal="saveMealModalVisible"
        v-on:hide="hideSaveMealModal"
        v-on:save="saveMeal"
      />

      <!-- <cv-toolbar class="infobar">
        <p>Hvis totale kalorier her</p>
      </cv-toolbar>-->
    </div>
  </div>
</template>

<script>
import IngredientList from "./components/IngredientList.vue";
import LoadMealModal from "./components/modals/LoadMealModal.vue";
import SaveMealModal from "./components/modals/SaveMealModal.vue";
// import Header from "./components/Header.vue";

export default {
  name: "app",
  components: {
    IngredientList,
    LoadMealModal,
    SaveMealModal
  },
  data() {
    return {
      loadMealModalVisible: false,
      saveMealModalVisible: false,
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
      this.$refs.ingredientList.saveRecipe(recipeName);
    },
    loadRecipe(recipe) {
      this.recipe = recipe;
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
  margin: 3rem;
}

.header {
  display: flex;
  justify-content: space-between;
}

.infobar {
  display: flex;
  justify-content: flex-end;
  margin-bottom: 0 !important;
  position: fixed;
  bottom: 0;
  width: 100%;
  background: lightgray;
  padding: 1rem;
}
</style>
