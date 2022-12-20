using CommunityToolkit.Maui.Views;

namespace LOFI.Pages.ModalPage;

public partial class TvOfferPage : Popup
{
	public TvOfferPage()
	{
		InitializeComponent();
	}

    private void btnClose_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}