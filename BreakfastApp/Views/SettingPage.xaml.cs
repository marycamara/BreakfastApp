namespace BreakfastApp.Views
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private async void EditProfile_Clicked(object sender, EventArgs e)
        {
            // Navigate to the edit profile page
            await Navigation.PushAsync(new EditProfilePage());
        }
    }
}