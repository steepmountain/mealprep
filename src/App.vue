<template>
  <div id="app">
    <div>
      <cv-header aria-label="Carbon header" class="header">
        <cv-header-name href="javascript:void(0)" prefix="💪">[Prep That Meal]</cv-header-name>
          <cv-button>Lagre</cv-button>
      </cv-header>

      <h1 class="logo">💪</h1>
      <h1>Prep That Meal</h1>
      <IngredientList />

      <cv-toolbar class="infobar">
        <p>Hvis totale kalorier her</p>
      </cv-toolbar>
    </div>
  </div>
</template>

<script>
import IngredientList from "./components/IngredientList.vue";
// import Header from "./components/Header.vue";

export default {
  name: "app",
  components: {
    IngredientList
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
