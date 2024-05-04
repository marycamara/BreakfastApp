using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BreakfastApp.Models; // Import the Breakfast class from BreakfastApp.Models
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace BreakfastApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<BreakfastApp.Models.BreakfastList> breakfasts; // Specify the namespace explicitly

        [ObservableProperty]
        private bool isRefreshing;

        private readonly BreakfastStore database;

        public MainViewModel()
        {
            database = new BreakfastStore();

            if (database.GetAllItems().Count == 0)
            {
                InitialItemsLoad();
            }

            LoadBreakfast();
        }

        private void InitialItemsLoad()
        {
            database.Create(new BreakfastTable
            {
                Name = "French toast",
                Description = "This is a classic",
                ImageUri = "https://embed.widencdn.net/img/mccormick/htzunwgdp2/1365x1365px/quick_and_easy_french_toast_3898.jpg?crop=true&anchor=341,0&q=80&color=ffffffff&u=o2hyef",
                Ingredients = "Eggs, Bread, Milk",
                AddOn = "Syrup",
                Nutrition = "[\"Calories: 300\", \"Protein: 10g\", \"Carbs: 30g\"]" // Add Nutrition property
            });

            database.Create(new BreakfastTable
            {
                Name = "Scrambled eggs",
                Description = "This is just amazing",
                ImageUri = "https://fthmb.tqn.com/jUhIdGy4dtspZpskD--OngG9jFc=/2200x1467/filters:fill(auto,1)/scrambled-eggs-deluxe-g22-56a8c2ad3df78cf772a06135.jpg",
                Ingredients = "Eggs",
                AddOn = "Cheese",
                Nutrition = "[\"Calories: 250\", \"Protein: 12g\", \"Carbs: 5g\"]" // Add Nutrition property
            });
        }

        public void LoadBreakfast()
        {
            Breakfasts = new List<BreakfastApp.Models.BreakfastList>();
            List<BreakfastTable> breakfastDtos = database.GetAllItems();

            foreach (BreakfastTable breakfastDto in breakfastDtos)
            {
                BreakfastApp.Models.BreakfastList breakfast = new()
                {
                    Id = breakfastDto.Id,
                    Name = breakfastDto.Name,
                    Description = breakfastDto.Description,
                    Image = new Uri(breakfastDto.ImageUri, UriKind.RelativeOrAbsolute),
                    Ingredients = !string.IsNullOrWhiteSpace(breakfastDto.Ingredients) ?
                        breakfastDto.Ingredients.Split(", ").ToList() :
                        new List<string>(),
                    AddOn = !string.IsNullOrWhiteSpace(breakfastDto.AddOn) ?
                        breakfastDto.AddOn.Split(", ").ToList() :
                        new List<string>(),
                    Nutrition = !string.IsNullOrWhiteSpace(breakfastDto.Nutrition) ?
                        breakfastDto.Nutrition.Split(", ").ToList() :
                        new List<string>() // Initialize Nutrition property
                };

                Breakfasts.Add(breakfast);
            }
        }

        [RelayCommand]
        private void Refresh()
        {
            LoadBreakfast();
            IsRefreshing = false;
        }

        [RelayCommand]
        private void Delete(int id)
        {
            database.Delete(id);
            LoadBreakfast();
        }

        [RelayCommand]
        private async Task GoToUpdate(int id) =>
            await Application.Current!.MainPage!.Navigation
                .PushAsync(new Views.UpdatePage(new UpdateViewModel(id, database)));


        [RelayCommand]
        private async Task GoToCreate() =>
            await Application.Current!.MainPage!.Navigation
                .PushAsync(new Views.CreatePage(new CreateViewModel(database)));
    }
}
