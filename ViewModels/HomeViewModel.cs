using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LOFI.ApiMomoModel;
using LOFI.Data;
using LOFI.Helpers;
using LOFI.Models;
using LOFI.Pages;
using System.Collections.ObjectModel;


namespace LOFI.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private CompteService CompteService { get; set; } = new CompteService();
    private HistoriqueService historiqueService { get; set; } = new HistoriqueService();
    private readonly SerializeClass<Compte> serializeClass = new SerializeClass<Compte>();
    private readonly SerializeClass<User> serializeUser = new SerializeClass<User>();
    private MomoClass MomoClass { get; set; } = new MomoClass();
    private readonly Guid newUId = Guid.NewGuid();

    [ObservableProperty]
    Compte compteUser;

    [ObservableProperty]
    User user;

    [ObservableProperty]
    string fullName;
    
    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    string soldeMobile;

    [ObservableProperty]
    string uniqueRef;

    [ObservableProperty]
    string apiKey;

    [ObservableProperty]
    ObservableCollection<Historique> historiques;


    const int RefreshDuration = 2;

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    private async Task Refresh()
    {
        IsRefreshing = true;
        GetHistorique();

        await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
        IsRefreshing = false;
    }

    [RelayCommand]
    async Task History()
    {
        await Shell.Current.GoToAsync($"{nameof(HistoriquePage)}");
    }
    
    [RelayCommand]
    async Task QrCode()
    {
        await Shell.Current.GoToAsync($"{nameof(BarCodePage)}");
    }

    public HomeViewModel()
    {
        Historiques = new ObservableCollection<Historique>();

        //getUserCredentialApiKey();
        getUserInfo();
        getCompte();
        //GetHistorique();
    }
    void getUserInfo()
    {
        User = serializeUser.Deserialize(Settings.User);
        FullName = User.NomUser + " " + User.PrenomUser;
    }
    //Cette fonction permet d'initialiser les credentials d'un utilisateur
    async void getUserCredentialApiKey()
    {
        try
        {
            UniqueRef = Preferences.Get("uuid", string.Empty);

            //if (string.IsNullOrEmpty(UniqueRef))
            //{
            //    UniqueRef = newUId.ToString();

            //    UserCreateModel userCreateModel = new UserCreateModel
            //    {
            //        providerCallbackHost = "string"
            //    };

            //    var result = await MomoClass.createUser(UniqueRef, userCreateModel);
            //    if(result)
            //        Preferences.Set("uuid", UniqueRef);
            //}

            //string apikey = await MomoClass.CreateApiKey(UniqueRef);
            //if (!string.IsNullOrEmpty(apikey))
            //    Preferences.Set("apikey", apikey);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Credential !", "Une erreur s'est produite. " + ex.Message, "OK");
        }
    }

    //Cette fonction récupère les informations de compte d'un utilisateur
    async void getCompte()
    {
        try
        {
            IsBusy = true;
            if (Settings.Compte != string.Empty)
            {
                CompteUser = serializeClass.Deserialize(Settings.Compte);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erreur", "Une erreur s'est produite. " + ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand]
    async Task getSolde()
    {
        UniqueRef = Preferences.Get("uuid", string.Empty);
        ApiKey = Preferences.Get("apikey", string.Empty);

        await Task.Delay(100);

        if (string.IsNullOrEmpty(UniqueRef) && string.IsNullOrEmpty(ApiKey))
        {
            getUserCredentialApiKey();
        }

    }


    async void GetHistorique()
    {
        try
        {
            var histories = await historiqueService.getHistoriqueListByCompte();
            Historiques.Clear();

            foreach (var history in histories.Take(5))
            {
                Historiques.Add(history);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erreur", $"Erreur de chargement des données..{ex.Message}", "REESSAYER");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
