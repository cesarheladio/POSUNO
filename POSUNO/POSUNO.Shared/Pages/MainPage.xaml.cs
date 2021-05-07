using POSUNO.Models;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace POSUNO.Pages
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public User User { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            User = (User)e.Parameter;
            WelcomeTextBlock.Text = $"Bienvenido: {User.FullName}";
        }

        private async void LogoutImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentDialogResult dialog = await ConfirmLeaveAsync();
            if (dialog == ContentDialogResult.Primary)
            {
                Frame.Navigate(typeof(LoginPage));
            }
        }

        private async Task<ContentDialogResult> ConfirmLeaveAsync()
        {
            ContentDialog comfirmDialog = new ContentDialog
            {
                Title = "Confirmacion",
                Content = "EstasSeguro de salir?",
                PrimaryButtonText = "Si",
                CloseButtonText = "No",
            };
            return await comfirmDialog.ShowAsync();
        }
    }
}
