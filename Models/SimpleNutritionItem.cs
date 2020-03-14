using Mealprep.Models.Nutritionix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mealprep.Models
{
    public class SimpleNutritionItem
    {
        public string Name { get; set; }
        public string MeasurementUnit { get; set; }
        public float CaloriesPerMeasurementUnit { get; set; }
        public SimpleNutritionItem(IFoodItem nutritionixIngredient)
        {
            var servingQuantity = nutritionixIngredient.Serving_qty ?? 1;
            switch (nutritionixIngredient)
            {
                case InstantSearchResponse.Common common:
                    Name = common.Food_name;
                    MeasurementUnit = common.Serving_unit;
                    CaloriesPerMeasurementUnit = 0;
                    break;
                case NutrientResponse.Food food:
                    var calories = food.Nf_calories ?? 1;
                    Name = food.Food_name;
                    MeasurementUnit = food.Serving_unit;
                    CaloriesPerMeasurementUnit = calories / servingQuantity;
                    break;
            }
        }
    }
}
