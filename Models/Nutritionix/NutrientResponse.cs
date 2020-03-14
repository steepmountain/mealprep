using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mealprep.Models.Nutritionix
{
    public static class NutrientResponse
    {
        public class Rootobject
        {
            public Food[] Foods { get; set; }
        }

        public class Food : IFoodItem
        {
            public string Food_name { get; set; }
            public object Brand_name { get; set; }
            public float? Serving_qty { get; set; }
            public string Serving_unit { get; set; }
            public float? Serving_weight_grams { get; set; }
            public float? Nf_calories { get; set; }
            public float? Nf_total_fat { get; set; }
            public float? Nf_saturated_fat { get; set; }
            public float? Nf_cholesterol { get; set; }
            public float? Nf_sodium { get; set; }
            public float? Nf_total_carbohydrate { get; set; }
            public float? Nf_dietary_fiber { get; set; }
            public float? Nf_sugars { get; set; }
            public float? Nf_protein { get; set; }
            public float? Nf_potassium { get; set; }
            public float? Nf_p { get; set; }
            public Full_Nutrients[] Full_nutrients { get; set; }
            public object Nix_brand_name { get; set; }
            public object Nix_brand_id { get; set; }
            public object Nix_item_name { get; set; }
            public object Nix_item_id { get; set; }
            public object Upc { get; set; }
            public DateTime Consumed_at { get; set; }
            public Metadata Metadata { get; set; }
            public float? Source { get; set; }
            public float? Ndb_no { get; set; }
            public Tags Tags { get; set; }
            public Alt_Measures[] Alt_measures { get; set; }
            public object Lat { get; set; }
            public object Lng { get; set; }
            public float? Meal_type { get; set; }
            public Photo Photo { get; set; }
            public object Sub_recipe { get; set; }
        }

        public class Metadata
        {
            public bool Is_raw_food { get; set; }
        }

        public class Tags
        {
            public string Item { get; set; }
            public string Measure { get; set; }
            public string Quantity { get; set; }
            public float? Food_group { get; set; }
            public float? Tag_id { get; set; }
        }

        public class Photo
        {
            public string Thumb { get; set; }
            public string Highres { get; set; }
            public bool Is_user_uploaded { get; set; }
        }

        public class Full_Nutrients
        {
            public float? Attr_id { get; set; }
            public float? Value { get; set; }
        }

        public class Alt_Measures
        {
            public float? Serving_weight { get; set; }
            public string Measure { get; set; }
            public float? Seq { get; set; }
            public float? Qty { get; set; }
        }
    }
}
