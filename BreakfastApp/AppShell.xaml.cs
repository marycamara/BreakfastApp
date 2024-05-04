using Microsoft.Maui.Controls;

namespace BreakfastApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("LoginPage", typeof(Views.LoginPage));
            Routing.RegisterRoute("MainPage", typeof(Views.MainPage));
            Routing.RegisterRoute("LogoutPage", typeof(Views.LogoutPage));

            // Set the initial route to the login page
            CurrentItem = new ShellItem
            {
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsSingleItem,
                Items =
                {
                    new ShellSection
                    {
                        Items =
                        {
                            new ShellContent { ContentTemplate = new DataTemplate(typeof(Views.LoginPage)) }
                        }
                    }
                }
            };
        }

        // Method to switch to authenticated state
        public void SwitchToAuthenticatedState()
        {
            // Clear the current items
            CurrentItem.Items.Clear();

            // Add authenticated pages to the ShellSection titled "Authenticated Pages"
            CurrentItem.Items.Add(new ShellSection
            {
                Title = "Authenticated Pages",
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Items =
                {
                    // Add authenticated pages here
                    // For example:
                    // new ShellContent { ContentTemplate = new DataTemplate(typeof(Views.DashboardPage)) }
                }
            });
        }
    }
}
