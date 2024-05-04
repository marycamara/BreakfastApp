using BreakfastApp.ViewModels;
using Microsoft.Maui.Controls;
using System;
namespace BreakfastApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel vm;

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            this.vm = vm;
        }

        protected override void OnAppearing()
        {
            vm.LoadBreakfast();
        }

        private async void OnGoToByChancePageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipePage());
        }

        private async void OnGoToShoppingListPageClicked(object sender, EventArgs e)
        {
            // Navigate to the ShoppingListPage
            await Navigation.PushAsync(new ShoppingListPage());
        }
    }
}
