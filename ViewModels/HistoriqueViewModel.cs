using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LOFI.Data;
using LOFI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace LOFI.ViewModels;

public partial class HistoriqueViewModel : ObservableObject
{
    private HistoriqueService historiqueService { get; set; } = new HistoriqueService();

    [ObservableProperty]
    bool isBusy;
    
    const int RefreshDuration = 2;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<Historique> historiques;

    public HistoriqueViewModel()
    {
        Historiques = new ObservableCollection<Historique>();

        GetHistorique();
    }

    [RelayCommand]
    private async Task Refresh()
    {
        IsRefreshing = true;
        GetHistorique();

        await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
        IsRefreshing = false;
    }
    async void GetHistorique()
    {
        try
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Historiques = await historiqueService.getHistoriqueListByCompte();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Alerte !", $"Erreur de chargement des données..{ex.Message}", "REESSAYER");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
