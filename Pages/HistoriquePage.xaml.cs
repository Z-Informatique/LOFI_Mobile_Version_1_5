using LOFI.ViewModels;

namespace LOFI.Pages;

public partial class HistoriquePage : ContentPage
{
    public HistoriquePage(HistoriqueViewModel historiqueViewModel)
	{
		InitializeComponent();
        BindingContext = historiqueViewModel;

    }
}