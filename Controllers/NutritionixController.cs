using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mealprep.Data;
using Mealprep.Extensions;
using Mealprep.Models;
using Mealprep.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace Mealprep.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class NutritionixController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly NutritionixService _nutritionixService;

        public NutritionixController(ApplicationDbContext context, NutritionixService nutritionixService)
        {
            _context = context;
            _nutritionixService = nutritionixService;
        }

        [Route("nutrition")]
        public async Task<IEnumerable<SimpleNutritionItem>> Nutrition(string query)
        {
            return (await _nutritionixService.NutritionInformation(query).ConfigureAwait(false)).AsIngredients();
        }

        [Route("lookup")]
        public async Task<IEnumerable<SimpleNutritionItem>> Lookup(string query)
        {
            return (await _nutritionixService.IngredientLookup(query).ConfigureAwait(false)).AsIngredients();
        }
    }
}
