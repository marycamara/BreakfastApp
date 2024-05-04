using System;
using System.IO;
using BreakfastApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BreakfastApp.ViewModels
{
    public partial class CreateViewModel : ObservableObject
    {
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

        public CreateViewModel(BreakfastStore database)
        {
            this.database = database;
        }

        

        [RelayCommand]
        public async void Create()
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

            BreakfastTable breakfastList = new BreakfastTable
            {
                Name = Name,
                Description = Description,
                ImageUri = ImageUri,
                Ingredients = Ingredients,
                AddOn = AddOn,
                Nutrition = Nutrition // Assign Nutrition value
            };

            database.Create(breakfastList);
            ResetUserInput();

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
