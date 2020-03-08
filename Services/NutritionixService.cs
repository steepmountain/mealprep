using MealprepFull.Data.Entities.Recipes;
using MealprepFull.Extensions;
using MealprepFull.Models.Nutritionix;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MealprepFull.Models.Nutritionix.NutritionixIngredient;

namespace MealprepFull.Services
{
    public class NutritionixService
    {
        private readonly string Url = "https://trackapi.nutritionix.com/v2";
        private readonly RestClient _client;

        public NutritionixService(IConfiguration configuration)
        {
            _client = new RestClient(Url);
            var headers = new Dictionary<string, string>()
            {
                { "Content-Type", "application/x-www-form-urlencoded" },
                { "x-app-id", configuration["Nutritionix:x-app-id"]},
                { "x-app-key", configuration["Nutritionix:x-app-key"]}
            };
            _client.AddDefaultHeaders(headers);
        }

        public async Task<List<Ingredient>> Food(string naturalQuery)
        {
            var request = new RestRequest("/natural/nutrients", DataFormat.Json);
            request.AddParameter("application/x-www-form-urlencoded", $"timezone=US/Eastern&query={naturalQuery}", ParameterType.RequestBody);
            request.Method = Method.POST;
            var response = await _client.ExecuteAsync(request);
            
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new List<Ingredient>();
            }
            
            return JsonConvert.DeserializeObject<Rootobject>(response.Content).foods.AsIngredients().ToList();
        }
    }
}
