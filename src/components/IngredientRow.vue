<template>
<div class="ingredient-row">
    <cv-text-input label="Ingrediens" v-model="name" placeholder="Ingrediens" />

    <cv-number-input label="Mengde" v-model="amount" min="0" @input="calulcateCalories" />

    <cv-text-input label="Måleenhet" v-model="unit" placeholder="Måleenhet" />

    <cv-number-input label="Kalorier per måleenhet" v-model="caloriesPerAmount" min="0" @input="calulcateCalories" />
    {{totalCalories}}
</div>
</template>

<script>
export default {
    props: {
        index: Number
    },
    data() {
        return {
            name: "",
            amount: 0,
            unit: "",
            caloriesPerAmount: 0,
            totalCalories: 0,
        };
    },
    methods: {
        calulcateCalories() {
            if (this.caloriesPerAmount > 0 && this.amount > 0) {
                this.totalCalories = this.caloriesPerAmount * this.amount;
            } else {
                this.totalCalories = 0;
            }
            this.$emit('change', { id: this.index, calories: this.totalCalories });
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
