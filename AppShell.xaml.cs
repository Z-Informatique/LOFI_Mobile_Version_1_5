using LOFI.Pages;

namespace LOFI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(TransfertPage), typeof(TransfertPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }
}
