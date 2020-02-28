export default class IngredientService {
    caloriesPerMeal(calories, numberOfMeals) {
        if (calories == 0) {
            return 0;
        }
        return Math.trunc(calories / numberOfMeals);
    }

    calculateIngredientCalories(caloriesPerUnit, numberOfUnits) {
        if (caloriesPerUnit == 0) {
            return 0;
        }
        return Math.trunc(caloriesPerUnit * numberOfUnits);
    }
}