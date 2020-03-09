using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealprepFull.Models.Nutritionix
{
    public interface IFoodItem
    {
        string food_name { get; set; }
        float? serving_qty { get; set; }
        string serving_unit { get; set; }
    }
}
