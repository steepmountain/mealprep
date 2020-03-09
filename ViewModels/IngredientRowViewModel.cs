using MealprepFull.Models.Nutritionix;

namespace MealprepFull.ViewModels
{
    public class IngredientRowViewModel
    {
        public string Name { get; set; }
        public string MeasurementUnit { get; set; }
        public float CaloriesPerMeasurementUnit { get; set; }
        public IngredientRowViewModel(IFoodItem nutritionixIngredient)
        {
            var servingQuantity = nutritionixIngredient.serving_qty ?? 1;
            switch (nutritionixIngredient)
            {
                case InstantSearchResponse.Common common:
                    Name = common.food_name;
                    MeasurementUnit = common.serving_unit;
                    CaloriesPerMeasurementUnit = 0;
                    break;
                case NutrientResponse.Food food:
                    var calories = food.nf_calories ?? 1;
                    Name = food.food_name;
                    MeasurementUnit = food.serving_unit;
                    CaloriesPerMeasurementUnit = calories / servingQuantity;
                    break;

            }
        }
    }
}
