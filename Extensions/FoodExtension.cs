using MealprepFull.Data.Entities.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MealprepFull.Models.Nutritionix.NutritionixIngredient;

namespace MealprepFull.Extensions
{
    public static class FoodExtension
    {
        public static IEnumerable<Ingredient> AsIngredients(this IEnumerable<Food> foods)
        {
            return foods.Select(food => new Ingredient(food));
        }
    }
}
