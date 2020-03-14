using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mealprep.Models.Nutritionix
{
    public static class InstantSearchResponse
    {
        public class Rootobject
        {
            public Common[] Common { get; set; }
            public Branded[] Branded { get; set; }
        }

        public class Common : IFoodItem
        {
            public string Food_name { get; set; }
            public string Serving_unit { get; set; }
            public string Tag_name { get; set; }
            public float? Serving_qty { get; set; }
            public float? Common_type { get; set; }
            public string Tag_id { get; set; }
            public Photo Photo { get; set; }
            public string Locale { get; set; }
        }

        public class Photo
        {
            public string Thumb { get; set; }
            public object Highres { get; set; }
            public bool? Is_user_uploaded { get; set; }
        }

        public class Branded
        {
            public string Food_name { get; set; }
            public string Serving_unit { get; set; }
            public string Nix_brand_id { get; set; }
            public string Brand_name_item_name { get; set; }
            public float? Serving_qty { get; set; }
            public float? Nf_calories { get; set; }
            public Photo Photo { get; set; }
            public string Brand_name { get; set; }
            public float? Region { get; set; }
            public float? Brand_type { get; set; }
            public string Nix_item_id { get; set; }
            public string Locale { get; set; }
        }
    }
}
