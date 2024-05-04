// RecipePageViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using BreakfastApp.Services;

namespace BreakfastApp.ViewModels
{
    public class RecipePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<RecipeModel> _recipes;
        public ObservableCollection<RecipeModel> Recipes
        {
            get { return _recipes; }
            set
            {
                _recipes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Recipes)));
            }
        }

        public RecipePageViewModel()
        {
            Recipes = new ObservableCollection<RecipeModel>();
            LoadRecipes();
        }

        private async Task LoadRecipes()
        {
            try
            {
                var mealService = new MealDBService();
                var allRecipes = await mealService.GetAllRecipesAsync();
                foreach (var recipe in allRecipes)
                {
                    Recipes.Add(recipe);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class RecipeModel
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string stIngredient1 { get; set; }

    }
}