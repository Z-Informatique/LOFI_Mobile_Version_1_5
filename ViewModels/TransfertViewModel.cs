using CommunityToolkit.Mvvm.ComponentModel;
using LOFI.Data;
using LOFI.Models;
using System.Collections.ObjectModel;

namespace LOFI.ViewModels;

public partial class TransfertViewModel : ObservableObject
{
    public MethodeService methodeService { get; set; } = new MethodeService();

    [ObservableProperty]
    int montant;
    
    [ObservableProperty]
    string titre;
    
    [ObservableProperty]
    int frais;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    Methode selectedMethode;

    [ObservableProperty]
    Operateur selectedOperateur;

    [ObservableProperty]
    ObservableCollection<Methode> methodes;

    [ObservableProperty]
    ObservableCollection<Operateur> operateurs;

    public TransfertViewModel()
    {
        Methodes = new ObservableCollection<Methode>();
        Operateurs = new ObservableCollection<Operateur>();

        getAllMethodes();
        getOperateur();
    }

    async void getAllMethodes()
    {
        try
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Methodes = await methodeService.getAllMethodes();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Alerte !", "Erreur de chargement des données. " + ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    async void getOperateur()
    {
        try
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Operateurs = await methodeService.getAllOperateur();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Alerte !", "Erreur de chargement des données. " + ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }


}
