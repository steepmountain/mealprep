using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealprepFull.Models.Nutritionix
{
    public class NutrientResponse
    {

        public class Rootobject
        {
            public Food[] foods { get; set; }
        }

        public class Food : IFoodItem
        {
            public string food_name { get; set; }
            public object brand_name { get; set; }
            public float? serving_qty { get; set; }
            public string serving_unit { get; set; }
            public float? serving_weight_grams { get; set; }
            public float? nf_calories { get; set; }
            public float? nf_total_fat { get; set; }
            public float? nf_saturated_fat { get; set; }
            public float? nf_cholesterol { get; set; }
            public float? nf_sodium { get; set; }
            public float? nf_total_carbohydrate { get; set; }
            public float? nf_dietary_fiber { get; set; }
            public float? nf_sugars { get; set; }
            public float? nf_protein { get; set; }
            public float? nf_potassium { get; set; }
            public float? nf_p { get; set; }
            public Full_Nutrients[] full_nutrients { get; set; }
            public object nix_brand_name { get; set; }
            public object nix_brand_id { get; set; }
            public object nix_item_name { get; set; }
            public object nix_item_id { get; set; }
            public object upc { get; set; }
            public DateTime consumed_at { get; set; }
            public Metadata metadata { get; set; }
            public float? source { get; set; }
            public float? ndb_no { get; set; }
            public Tags tags { get; set; }
            public Alt_Measures[] alt_measures { get; set; }
            public object lat { get; set; }
            public object lng { get; set; }
            public float? meal_type { get; set; }
            public Photo photo { get; set; }
            public object sub_recipe { get; set; }
        }

        public class Metadata
        {
            public bool is_raw_food { get; set; }
        }

        public class Tags
        {
            public string item { get; set; }
            public string measure { get; set; }
            public string quantity { get; set; }
            public float? food_group { get; set; }
            public float? tag_id { get; set; }
        }

        public class Photo
        {
            public string thumb { get; set; }
            public string highres { get; set; }
            public bool is_user_uploaded { get; set; }
        }

        public class Full_Nutrients
        {
            public float? attr_id { get; set; }
            public float? value { get; set; }
        }

        public class Alt_Measures
        {
            public float? serving_weight { get; set; }
            public string measure { get; set; }
            public float? seq { get; set; }
            public float? qty { get; set; }
        }

    }
}
