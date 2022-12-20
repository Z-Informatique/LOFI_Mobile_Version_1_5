using CommunityToolkit.Maui.Views;

namespace LOFI.Pages.ModalPage;

public partial class InternetOfferPage : Popup
{
	public InternetOfferPage()
	{
		InitializeComponent();
	}

    private void btnClose_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}