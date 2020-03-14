using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mealprep.Models.Nutritionix
{
    public interface IFoodItem
    {
        string Food_name { get; set; }
        float? Serving_qty { get; set; }
        string Serving_unit { get; set; }
    }
}
