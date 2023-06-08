
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LOFI.Helpers;
using LOFI.Models;

namespace LOFI.ViewModels;

public partial class BankViewModel : ObservableObject
{
    private readonly SerializeClass<Compte> serializeClass = new SerializeClass<Compte>();

    [ObservableProperty]
    Compte compteUser;

    [ObservableProperty]
    int soldeMtn;

    [ObservableProperty]
    int soldeAirtel;


    [RelayCommand]
    async Task getSolde()
    {
        await Task.Delay(100);
        SoldeMtn = 800000;
    }
    
    [RelayCommand]
    async Task getSoldeAirtel()
    {
        await Task.Delay(100);
        SoldeAirtel = 200000;
    }

    public BankViewModel()
    {
        CompteUser = serializeClass.Deserialize(Settings.Compte);
        SoldeMtn = 000000;
        SoldeAirtel = 000000;
    }
}
