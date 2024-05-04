
using Microsoft.Maui.Controls;
using Serilog;
using System;
using System.Threading.Tasks;

namespace BreakfastApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Log.Information("Login button clicked."); // Log button click event

            try
            {
                // Temporary username and password values
                string username = "example_username";
                string password = "example_password";

                Log.Information("Attempting login for user: {Username}", username);

                // Simulate authentication process (replace with actual authentication logic)
                bool isAuthenticated = await Authenticate(username, password);

                if (isAuthenticated)
                {
                    Log.Information("User {Username} authenticated successfully.", username);

                    // Navigate to the main page if authentication is successful
                    await Shell.Current.GoToAsync("//MainPage");
                }
                else
                {
                    Log.Warning("Authentication failed for user {Username}.", username);

                    // Display an error message or handle failed authentication
                    await DisplayAlert("Error", "Invalid username or password", "OK");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred during login.");
                // Handle any exceptions that occur during the login process
            }
        }

        private async Task<bool> Authenticate(string username, string password)
        {
            // Implement your authentication logic here
            // For demonstration purposes, let's assume authentication succeeds if username and password are not empty
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }
    }
}
