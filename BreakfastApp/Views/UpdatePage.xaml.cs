using BreakfastApp.ViewModels;

namespace BreakfastApp.Views;

public partial class UpdatePage : ContentPage
{
	public UpdatePage(UpdateViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}