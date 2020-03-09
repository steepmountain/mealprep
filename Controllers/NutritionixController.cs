using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealprepFull.Data;
using MealprepFull.Data.Entities;
using MealprepFull.Extensions;
using MealprepFull.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace MealprepFull.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class NutritionixController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly NutritionixService _nutritionixService;

        public NutritionixController(ApplicationDbContext context, NutritionixService nutritionixService)
        {
            _context = context;
            _nutritionixService = nutritionixService;
        }

        [Route("nutrition")]
        public async Task<IActionResult> Nutrition(string query)
        {
            return Json((await _nutritionixService.NutritionInformation(query)).AsIngredients());
        }

        [Route("lookup")]
        public async Task<IActionResult> Lookup(string query)
        {
            return Json((await _nutritionixService.IngredientLookup(query)).AsIngredients());
        }
    }
}