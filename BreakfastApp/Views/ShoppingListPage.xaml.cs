using BreakfastApp.ViewModels;
using Microsoft.Maui.Controls;

namespace BreakfastApp.Views
{
    public partial class ShoppingListPage : ContentPage
    {
        public ShoppingListPage()
        {
            InitializeComponent();
            BindingContext = new ShoppingListViewModel();
        }
    }
}
