﻿using CommunityToolkit.Maui;
using LOFI.Pages;
using LOFI.ViewModels;
using ZXing.Net.Maui;

namespace LOFI;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>()
            .UseBarcodeReader()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSansRegular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSansSemibold.ttf", "OpenSansSemibold");
            fonts.AddFont("PoppinsRegular.ttf", "Regular");
            fonts.AddFont("PoppinsSemiBold.ttf", "Bold");
            fonts.AddFont("materialfont.ttf", "materialfont");
        })
        #region
            .ConfigureMauiHandlers(h =>
            {
                h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
                h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraView), typeof(CameraViewHandler));
                h.AddHandler(typeof(ZXing.Net.Maui.Controls.BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
            });
        #endregion

        builder.Services.AddSingleton<TransfertPage>();
        builder.Services.AddSingleton<TransfertViewModel>();
        
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomeViewModel>();

        builder.Services.AddSingleton<HistoriquePage>();
        builder.Services.AddSingleton<HistoriqueViewModel>();

        builder.Services.AddSingleton<BankPage>();
        builder.Services.AddSingleton<BankViewModel>();


        return builder.Build();
    }
}