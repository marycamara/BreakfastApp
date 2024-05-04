using Microsoft.Maui.Controls;

namespace BreakfastApp.Views
{
    public partial class LogoutPage : ContentPage
    {
        public LogoutPage()
        {
            InitializeComponent();
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Implement your logout logic here
            // For example, clear user session, navigate to login page, etc.
            // Once logout is successful, navigate back to the login page
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
