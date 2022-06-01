using System;
using System.Collections.Generic;
using System.Text;
using Turnverein.Models;
using Turnverein.Views;
using Xamarin.Forms;

namespace Turnverein.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public string AccountName { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);

        }

        private async void OnLoginClicked(object obj)
        {
            Account account = new Account(Password, AccountName);
            if (account.CorrectInformation())
            {
                await Application.Current.MainPage.DisplayAlert("Login", "Login erfolgreich", "Ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login", "Login nicht korrekt, kein Benutzername oder kein Passwort", "Ok");
            }

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(ContestPage)}");
        }
    }
}
