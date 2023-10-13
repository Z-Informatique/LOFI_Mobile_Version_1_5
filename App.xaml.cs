using LOFI.Pages;

namespace LOFI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        if (string.IsNullOrEmpty(Helpers.Settings.User))
        {
            MainPage = new NavigationPage(new LoginPage());
        }
        else
        {
            MainPage = new AppShell();
        }
    }
}
