using LOFI.Data;
using LOFI.Models;
using LOFI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LOFI.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private UserService userService { get; set; } = new UserService();

        public User User { get; set; } = new User();

        string _telephone;
        public string Telephone
        {
            get => _telephone;
            set { _telephone = value; OnPropertyChanged(); }
        }
        string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand => new Command(async () => await LoginCommandAsync());
        public ICommand RegisterCommand => new Command(async () => await RegisterCommandAsync());
        public ICommand LoginCommandPage => new Command(async () => await LoginCommandPageAsync());
        public ICommand RegisterCommandPage => new Command(async () => await RegisterCommandPageAsync());
        
        private async Task LoginCommandPageAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private async Task RegisterCommandPageAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        private async Task LoginCommandAsync()
        {
            if (string.IsNullOrEmpty(Telephone))
            {
                await Application.Current.MainPage.DisplayAlert("Alerte !", "Le champ téléphone est vide.", "OK");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Alerte !", "Le champ mot de passe est vide.", "OK");
                return;
            }
            IsBusy = true;
            User user = await userService.Login(Telephone, Password);

            if (user != null && !string.IsNullOrEmpty(user.TelUser))
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alerte !", "Téléphone ou mot de passe incorrect.", "OK");
            }
            IsBusy = false;
        }

        private async Task RegisterCommandAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Inscription !", "Succès.", "OK");
        }

    }
}
