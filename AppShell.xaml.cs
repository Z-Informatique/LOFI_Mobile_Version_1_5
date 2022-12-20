using LOFI.Helpers;
using LOFI.Pages;

namespace LOFI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(TransfertPage), typeof(TransfertPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(HistoriquePage), typeof(HistoriquePage));
        Routing.RegisterRoute(nameof(BarCodePage), typeof(BarCodePage));
    }

    private async void toolLogout_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Déconnexion", "Êtes-vous certain de vouloir vous déconnecter ?", "OUI", "NON");

        if (result)
        {
            Preferences.Clear();
            Settings.Token = string.Empty;
            Settings.IdUser = string.Empty;
            Settings.Nom = string.Empty;
            Settings.Prenom = string.Empty;
            Settings.Telephone = string.Empty;
            Settings.UserRole = string.Empty;
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

    }
}
