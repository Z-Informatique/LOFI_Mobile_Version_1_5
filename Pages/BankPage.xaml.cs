using LOFI.ViewModels;

namespace LOFI.Pages;

public partial class BankPage : ContentPage
{
	public BankPage(BankViewModel bankViewModel)
	{
		InitializeComponent();
		BindingContext = bankViewModel;
	}
}