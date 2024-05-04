using System.Collections.Generic;

namespace BreakfastApp.Models
{
    public class RecipeSearchResponse
    {
        public List<Recipe> Results { get; set; }
        public int Offset { get; set; }
        public int Number { get; set; }
        public int TotalResults { get; set; }
    }

    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
    }
}
