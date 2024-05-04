// RecipePage.xaml.cs
using BreakfastApp.ViewModels;
using Microsoft.Maui.Controls;

namespace BreakfastApp.Views
{
    public partial class RecipePage : ContentPage
    {
        public RecipePage()
        {
            InitializeComponent();
            BindingContext = new RecipePageViewModel();
        }
    }
}
