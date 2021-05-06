﻿using POSUNO.Helpers;
using POSUNO.Models;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace POSUNO.Pages
{   
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private  async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = await ValidForm();
            if(!isValid)
            {
                return;
            }

            Response response = await ApiService.LoginAsync(new LoginRequest
            {
                Email=EmailTextBox.Text,
                Password=PasswordPasswordBox.Password,
            });
            MessageDialog messageDialog;
            if(!response.IsSuccess)
            {
                messageDialog = new MessageDialog(response.Message, "ERROR");
                await messageDialog.ShowAsync();
                return;
            }

            User user = (User)response.Result;
            if(user==null)
            {
                messageDialog = new MessageDialog("Usuario o contraseña incorrectos", "ERROR");
                await messageDialog.ShowAsync();
                return;
            }

             messageDialog = new MessageDialog($"Bienvenido {user.FullName}","ok");
            await messageDialog.ShowAsync();
        }

        private async Task<bool> ValidForm()
        {
            MessageDialog messageDialog;

            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                messageDialog = new MessageDialog("Debes ingresar tu email.", "Error");
                await messageDialog.ShowAsync();
                return false;
            }
            if (!RegexUtilities.IsValidEmail(EmailTextBox.Text))
            {
                messageDialog = new MessageDialog("Debes ingresar un email valido.", "Error");
                await messageDialog.ShowAsync();
                return false;
            }
            if (PasswordPasswordBox.Password.Length < 6)
            {
                messageDialog = new MessageDialog("Debes ingresar tu contraseña de al menos seis (6) carátertes.", "Error");
                await messageDialog.ShowAsync();
                return false;
            }
            return true;
        }
    }
}
