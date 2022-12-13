using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LOFI.Data;
using LOFI.Models;
using LOFI.Pages;
using System.Windows.Input;

namespace LOFI.ViewModels;

public partial class UserViewModel : ObservableObject
{
    private UserService userService { get; set; } = new UserService();

    public User User { get; set; } = new User();

    [ObservableProperty]
    string telephone;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    bool isBusy;

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

    [RelayCommand]
    private async Task Login()
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
