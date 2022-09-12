using LOFI.ViewModels;

namespace LOFI.Pages;

public partial class RegisterPage : ContentPage
{
    private readonly UserViewModel userViewModel;
    public RegisterPage()
	{
		InitializeComponent();
        userViewModel = new UserViewModel();
        BindingContext = userViewModel;
    }
}