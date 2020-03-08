using MealprepFull.Models.Nutritionix;
using static MealprepFull.Models.Nutritionix.NutritionixIngredient;

namespace MealprepFull.Data.Entities.Recipes
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string MeasurementUnit { get; set; }
        public double CaloriesPerMeasurementUnit { get; set; }

        public Ingredient(Food nutritionixIngredient)
        {
            Name = nutritionixIngredient.food_name;
            Amount = nutritionixIngredient.serving_qty;
            MeasurementUnit = nutritionixIngredient.serving_unit;
            CaloriesPerMeasurementUnit = nutritionixIngredient.nf_calories / nutritionixIngredient.serving_qty;
        }
    }
}