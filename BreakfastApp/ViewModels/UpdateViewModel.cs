using BreakfastApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.IO;

namespace BreakfastApp.ViewModels
{
    public partial class UpdateViewModel : ObservableObject
    {
        private readonly int id;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string imageUri;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string ingredients;

        [ObservableProperty]
        private string addOn;

        [ObservableProperty]
        private string nutrition; // New property for Nutrition

        private readonly BreakfastStore database;

        public UpdateViewModel(int id, BreakfastStore database)
        {
            this.id = id;
            this.database = database;

            DisplayItem();
        }

        private void DisplayItem()
        {
            BreakfastTable breakfastDto = database.GetItem(id);

            Name = breakfastDto.Name;
            Description = breakfastDto.Description;
            ImageUri = breakfastDto.ImageUri;
            Ingredients = breakfastDto.Ingredients;
            AddOn = breakfastDto.AddOn;
            Nutrition = breakfastDto.Nutrition; // Assign Nutrition value
        }

        [RelayCommand]
        public async void Update()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Name) ||
                    string.IsNullOrWhiteSpace(Description) ||
                    string.IsNullOrWhiteSpace(ImageUri) ||
                    string.IsNullOrWhiteSpace(Nutrition)) // Check if Nutrition is empty
                {
                    throw new InvalidDataException();
                }

                if (!Uri.IsWellFormedUriString(ImageUri, UriKind.Absolute))
                {
                    throw new UriFormatException();
                }
            }
            catch (Exception ex)
            {
                if (ex is InvalidDataException)
                {
                    await Application.Current.MainPage.DisplayAlert(Constants.IncorrectDataTitle,
                        Constants.IncorrectDataMessage, Constants.IncorrectDataBtnText);
                    return;
                }

                await Application.Current.MainPage.DisplayAlert(Constants.IncorrectUriTitle,
                    Constants.IncorrectUriMessage, Constants.IncorrectUriBtnText);
                return;
            }

            BreakfastTable breakfastDto = new BreakfastTable
            {
                Id = id,
                Name = Name,
                Description = Description,
                ImageUri = ImageUri,
                Ingredients = Ingredients,
                AddOn = AddOn,
                Nutrition = Nutrition // Assign Nutrition value
            };

            database.Update(breakfastDto);

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void ResetUserInput()
        {
            Name = String.Empty;
            ImageUri = String.Empty;
            Description = String.Empty;
            AddOn = String.Empty;
            Ingredients = String.Empty;
            Nutrition = String.Empty; // Reset Nutrition value
        }
    }
}
