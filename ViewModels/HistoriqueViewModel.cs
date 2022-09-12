using LOFI.Data;
using LOFI.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;


namespace LOFI.ViewModels
{
    public class HistoriqueViewModel : BaseViewModel
    {
        private HistoriqueService historiqueService { get; set; } = new HistoriqueService();
        bool _IsBusy;
        public bool IsBusy
        {
            get => _IsBusy;
            set
            {
                if (_IsBusy != value)
                {
                    _IsBusy = value;
                    OnPropertyChanged();
                }
            }
        }
        const int RefreshDuration = 2;
        bool isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public ICommand RefreshCommand => new Command(async () => await RefreshDataAsync());
        private ObservableCollection<Historique> historiques = new ObservableCollection<Historique>();
        public ObservableCollection<Historique> Historiques { get => historiques; set { historiques = value; OnPropertyChanged(); } }

        public HistoriqueViewModel()
        {
            GetHistorique();
        }

        private async Task RefreshDataAsync()
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
                IsBusy = false;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Alerte !", "Erreur de chargement des données. Vérifiez votre connexion internet.", "Ok");
                IsBusy = false;
            }
        }
    }
}
