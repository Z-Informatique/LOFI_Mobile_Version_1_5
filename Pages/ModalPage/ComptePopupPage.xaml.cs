using CommunityToolkit.Maui.Views;

namespace LOFI.Pages.ModalPage;

public partial class ComptePopupPage : Popup
{
	public ComptePopupPage()
	{
		InitializeComponent();
    }
    private void btnClose_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}