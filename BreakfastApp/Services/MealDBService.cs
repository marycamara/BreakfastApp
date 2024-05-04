// MealDBService.cs
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BreakfastApp.ViewModels;

namespace BreakfastApp.Services
{
    public class MealDBService
    {
        private const string API_URL = "https://www.themealdb.com/api/json/v1/1/search.php?s=";

        public async Task<List<RecipeModel>> GetAllRecipesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(API_URL);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                        var recipes = new List<RecipeModel>();
                        foreach (var meal in apiResponse.Meals)
                        {
                            recipes.Add(new RecipeModel
                            {
                                Title = meal.StrMeal,
                                Image = meal.StrMealThumb
                            });
                        }
                        return recipes;
                    }
                    else
                    {
                        // Handle unsuccessful response
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }

    public class ApiResponse
    {
        public List<Meal> Meals { get; set; }
    }

    public class Meal
    {
        public string StrMeal { get; set; }
        public string StrMealThumb { get; set; }
    }
}
