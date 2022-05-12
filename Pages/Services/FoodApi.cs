using RazorComponentLibrary.Objects;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;

namespace RazorComponentLibrary.Services
{
    public class FoodApi : IFoodApi
    {
        private HttpClient _httpClient;
        private JsonSerializerOptions _serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        public FoodApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://7z47kpfpzb.execute-api.us-west-2.amazonaws.com/");
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
            _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
        }
        public async Task<List<FoodObject>> GetAllFoodObjects()
        {
            List<FoodObject> foodObjects = new List<FoodObject>();
            try
            {
                foodObjects = await JsonSerializer.DeserializeAsync<List<FoodObject>>(await _httpClient.GetStreamAsync("GetAllFoodItems"), _serializerOptions);
            }
            catch (Exception ex)
            {
                throw;
            }
            return foodObjects;
        }

        public async Task<FoodObject> GetFoodObject(string name)
        {
            FoodObject foodObject = new FoodObject();
            try
            {
                foodObject = await JsonSerializer.DeserializeAsync<FoodObject>(await _httpClient.GetStreamAsync($"GetSingleFoodItem?name={Uri.EscapeDataString(name)}"), _serializerOptions);
            }
            catch(Exception ex)
            {
                throw;
            }
            return foodObject;
        }

        public async Task<FoodObject> CreateOrUpdateFoodObject(FoodObject foodObject)
        {
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.PostAsJsonAsync("CreateOrUpdateFood", foodObject);
            }
            catch(Exception ex)
            {
                throw;
            }
            if (response.IsSuccessStatusCode) {
                return await JsonSerializer.DeserializeAsync<FoodObject>(await response?.Content.ReadAsStreamAsync(), _serializerOptions);
            }
            else
            {
                throw new Exception((await response?.Content.ReadAsStringAsync()) ?? "An unexpected error occurred. Please try the requested operation a little later");
            }
        }

        public async Task<FoodObject> DeleteFoodObject(FoodObject foodObject)
        {
            var response = await _httpClient.PostAsJsonAsync("DeleteFoodItem", foodObject);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<FoodObject>(await response?.Content.ReadAsStreamAsync(), _serializerOptions);
            }
            else
            {
                throw new Exception((await response?.Content.ReadAsStringAsync()) ?? "An unexpected error occurred. Please try the requested operation a little later");
            }
        }
    }
}
