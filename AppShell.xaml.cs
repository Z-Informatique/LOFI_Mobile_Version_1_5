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
        Routing.RegisterRoute(nameof(BankPage), typeof(BankPage));
    }

    private async void toolLogout_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Déconnexion", "Êtes-vous certain de vouloir vous déconnecter ?", "OUI", "NON");

        if (result)
        {
            Preferences.Clear();
            Settings.Token = string.Empty;
            Settings.User = string.Empty;
            Settings.Compte = string.Empty;
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

    }
}
