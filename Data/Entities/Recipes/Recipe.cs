using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mealprep.Data.Entities.Recipes
{
    public class Recipe
    {
        public int Id { get; set; }
        public ApplicationUser Owner { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int NumberOfMeals { get; set; }
    }
}
