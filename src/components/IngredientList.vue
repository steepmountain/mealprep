<template>
<div class="ingredient-list">
    <cv-form id="meal-form">
        <IngredientRow v-for="item in items" v-bind:key="item.id" v-bind:index="item.id" v-bind:name="item.name" v-bind:amount="item.amount" v-bind:unit="item.unit" v-bind:caloriesPerAmount="item.caloriesPerAmount" v-bind:totalCalories="item.totalCalories" v-on:change="updateCalories" />
    </cv-form>
    Total calories: {{sumCalories}}
    <cv-button @click="addRow">Ny rad</cv-button>
</div>
</template>

<script>
import IngredientRow from "./IngredientRow.vue";
// Todo: make a model of row and send it down. edit the model in the row and see the edits up here
export default {
    name: "app",
    data() {
        return {
            sumCalories: 0,
            currentIndex: 1,
            items: []
        };
    },
    components: {
        IngredientRow
    },
    mounted: function () {
        this.addRow();
    },
    // computed: {
    //     summedCalories: function () {
    //         return this.sumCalories = this.items.reduce((sum, child) => {
    //             sum + child.rowCalories;
    //         });
    //     }
    // },
    methods: {
        updateCalories() {
            this.sumCalories = this.items
                .map(item => item.totalCalories)
                .reduce((sum, next) => {
                    sum + next;
                }, 0);
        },

        addRow() {
            this.currentIndex++;
            let ingredient = {
                key: this.currentIndex,
                index: this.currentIndex,
                name: "",
                amount: 0,
                unit: "",
                caloriesPerAmount: 0,
                totalCalories: 0
            };
            this.items.push(ingredient);
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
