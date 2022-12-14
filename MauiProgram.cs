using CommunityToolkit.Maui;
using LOFI.Pages;
using LOFI.ViewModels;

namespace LOFI;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSansRegular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSansSemibold.ttf", "OpenSansSemibold");
            fonts.AddFont("PoppinsRegular.ttf", "Regular");
            fonts.AddFont("PoppinsSemiBold.ttf", "Bold");
        }).UseMauiCommunityToolkit();


        builder.Services.AddSingleton<TransfertPage>();
        builder.Services.AddSingleton<TransfertViewModel>();
        
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomeViewModel>();


        return builder.Build();
    }
}