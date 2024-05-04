namespace BreakfastApp.Views;

public partial class EditProfilePage : ContentPage
{
    public EditProfilePage()
    {
        InitializeComponent();
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Add your save functionality here
        // For example, save the edited profile data

        // Navigate back to the profile page
        await Shell.Current.GoToAsync("//profile");
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        // Navigate back to the profile page
        await Shell.Current.GoToAsync("//profile");
    }
}


