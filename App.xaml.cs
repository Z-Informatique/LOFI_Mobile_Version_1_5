using LOFI.Pages;

namespace LOFI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        if (string.IsNullOrEmpty(Helpers.Settings.Token))
        {
            MainPage = new NavigationPage(new LoginPage());
        }
        else
        {
            MainPage = new AppShell();
        }
    }
}
