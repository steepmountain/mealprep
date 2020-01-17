<template>
<div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <div>
        <h1>Prep that meal</h1>
            <IngredientList />
    </div>
</div>
</template>

<script>
import IngredientList from './components/IngredientList.vue'

export default {
    name: 'app',
    components: {
        IngredientList
    }
}
</script>

<style>
#app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
}

#meal-form {
  max-width: 1200px;
  margin: 0 auto;
}
</style>
