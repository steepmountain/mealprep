<template>
<div id="app">
    <div>
        <h1 class="logo">💪</h1>
        <h1>Prep That Meal</h1>
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

.logo {
    font-size: 6rem;
    line-height: 8rem;
}

h1 {
    margin: 3rem;
}

</style>
