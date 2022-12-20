using CommunityToolkit.Maui.Views;
using LOFI.Pages.ModalPage;
using LOFI.ViewModels;

namespace LOFI.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		BindingContext = homeViewModel;
	}

    private async void TvTapped(object sender, EventArgs e)
	{
		await this.ShowPopupAsync(new TvOfferPage());
    }
	
	private async void NetworkTapped(object sender, EventArgs e)
	{
		await this.ShowPopupAsync(new InternetOfferPage());
    }
	
	private async void SendTapped(object sender, EventArgs e)
	{
		await this.ShowPopupAsync(new SendMoneyPage());
    }
	
	private async void TappedElect(object sender, EventArgs e)
	{
		await this.ShowPopupAsync(new ElectPage());
    }

	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
        await DisplayAlert("Mon compte", "Recharge effectuée avec succès", "OK");
    }

	private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
	{
		await DisplayAlert("Mon compte", "Retrait effectué avec succès", "OK");
	}
}