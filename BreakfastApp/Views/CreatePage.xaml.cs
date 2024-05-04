using BreakfastApp.ViewModels;

namespace BreakfastApp.Views;

public partial class CreatePage : ContentPage
{
	public CreatePage(CreateViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}