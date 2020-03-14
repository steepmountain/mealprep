using Mealprep.Models;
using Mealprep.Models.Nutritionix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mealprep.Extensions
{
    public static class NutritionixExtension
    {
        public static IEnumerable<SimpleNutritionItem> AsIngredients(this IEnumerable<NutrientResponse.Food> foods)
        {
            return foods.Select(food => new SimpleNutritionItem(food));
        }

        public static IEnumerable<SimpleNutritionItem> AsIngredients(this IEnumerable<InstantSearchResponse.Common> foods)
        {
            return foods.Select(food => new SimpleNutritionItem(food));
        }
    }
}
