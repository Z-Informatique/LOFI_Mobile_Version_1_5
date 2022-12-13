using CommunityToolkit.Maui;

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
        return builder.Build();
    }
}