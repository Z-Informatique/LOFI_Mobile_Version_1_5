using LOFI.ViewModels;

namespace LOFI.Pages;

public partial class HistoriquePage : ContentPage
{
	private readonly HistoriqueViewModel historiqueViewModel;
	public HistoriquePage()
	{
		InitializeComponent();
		historiqueViewModel = new HistoriqueViewModel();
		BindingContext = historiqueViewModel;

    }
}