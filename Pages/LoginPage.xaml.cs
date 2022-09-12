using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using LOFI.ViewModels;

namespace LOFI.Pages;
public partial class LoginPage : ContentPage
{
    private readonly UserViewModel userViewModel;
    public LoginPage()
	{
		InitializeComponent();
        userViewModel = new UserViewModel();
        BindingContext = userViewModel;
    }

}