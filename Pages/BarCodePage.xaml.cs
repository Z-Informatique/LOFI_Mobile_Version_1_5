namespace LOFI.Pages;

public partial class BarCodePage : ContentPage
{
	public BarCodePage()
	{
		InitializeComponent();
        Title = "Payer sans contact";
    }

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(() =>
        {
            barResult.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
        });
    }
}