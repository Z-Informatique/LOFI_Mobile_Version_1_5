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
        await DisplayAlert("Mon compte", "Transfert effectué avec succès", "OK");
    }

	private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
	{
        await DisplayAlert("Mon compte", "Recharge effectuée avec succès", "OK");
    }

	private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
	{
		await DisplayAlert("Mon compte", "Retrait effectué avec succès", "OK");
	}
}