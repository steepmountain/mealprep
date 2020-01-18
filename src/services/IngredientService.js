export default class IngredientService {
    caloriesPerMeal(calories, numberOfMeals) {
        return Math.trunc(calories / numberOfMeals);
    }

    calculateIngredientCalories(caloriesPerUnit, numberOfUnits) {
        return Math.trunc(caloriesPerUnit * numberOfUnits);
    }
}