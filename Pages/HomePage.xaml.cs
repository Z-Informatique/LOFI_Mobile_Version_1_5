using LOFI.ViewModels;

namespace LOFI.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		BindingContext = homeViewModel;
	}

	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
        await DisplayAlert("Mon compte", "Transfert effectu� avec succ�s", "OK");
    }

	private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
	{
        await DisplayAlert("Mon compte", "Recharge effectu�e avec succ�s", "OK");
    }

	private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
	{
		await DisplayAlert("Mon compte", "Retrait effectu� avec succ�s", "OK");
	}
}