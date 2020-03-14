using Mealprep.Models.Nutritionix;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mealprep.Services
{
    public class NutritionixService
    {
        private readonly string Url = "https://trackapi.nutritionix.com/v2";
        private readonly RestClient _client;
        private readonly JsonSerializerOptions _serializationOptions;

        public NutritionixService(IOptions<NutritionixApiOptions> options)
        {
            _client = new RestClient(Url);
            var headers = new Dictionary<string, string>()
            {
                { "Content-Type", "application/x-www-form-urlencoded" },
                { "x-app-id", options.Value.XAppId },
                { "x-app-key", options.Value.XAppKey }
            };
            _client.AddDefaultHeaders(headers);

            _serializationOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<InstantSearchResponse.Common>> IngredientLookup(string naturalQuery)
        {
            var request = new RestRequest("/search/instant", DataFormat.Json);
            request.AddParameter("application/x-www-form-urlencoded", $"&query={naturalQuery}", ParameterType.RequestBody);
            request.Method = Method.POST;
            var response = await _client.ExecuteAsync(request).ConfigureAwait(false);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new List<InstantSearchResponse.Common>();
            }

            return JsonSerializer.Deserialize<InstantSearchResponse.Rootobject>(response.Content, _serializationOptions).Common.ToList();
        }

        public async Task<List<NutrientResponse.Food>> NutritionInformation(string naturalQuery)
        {
            var request = new RestRequest("/natural/nutrients", DataFormat.Json);
            request.AddParameter("application/x-www-form-urlencoded", $"timezone=US/Eastern&query={naturalQuery}", ParameterType.RequestBody);
            request.Method = Method.POST;
            var response = await _client.ExecuteAsync(request).ConfigureAwait(false);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new List<NutrientResponse.Food>();
            }

            return JsonSerializer.Deserialize<NutrientResponse.Rootobject>(response.Content, _serializationOptions).Foods.ToList();
        }
    }
}
