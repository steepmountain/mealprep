using MealprepFull.Data.Entities.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealprepFull.Models.Nutritionix;
using MealprepFull.ViewModels;

namespace MealprepFull.Extensions
{
    public static class NutritionixExtension
    {
        public static IEnumerable<IngredientRowViewModel> AsIngredients(this IEnumerable<NutrientResponse.Food> foods)
        {
            return foods.Select(food => new IngredientRowViewModel(food));
        }
        public static IEnumerable<IngredientRowViewModel> AsIngredients(this IEnumerable<InstantSearchResponse.Common> foods)
        {
            return foods.Select(food => new IngredientRowViewModel(food));
        }

    }
}
