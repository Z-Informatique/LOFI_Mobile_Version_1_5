using CommunityToolkit.Maui.Views;

namespace LOFI.Pages.ModalPage;

public partial class ElectPage : Popup
{
	public ElectPage()
	{
		InitializeComponent();
    }
    private void btnClose_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}