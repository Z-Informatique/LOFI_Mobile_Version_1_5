using LOFI.Data;
using LOFI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LOFI.ViewModels
{
    public class TransfertViewModel : BaseViewModel
    {
        double _valeur;
        public double Valeur { get { return _valeur; } set { _valeur=value; OnPropertyChanged(); } }
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
        Methode selectedMethode;
        public Methode SelectedMethode
        {
            get
            {
                return selectedMethode;
            }
            set
            {
                if (selectedMethode != value)
                {
                    selectedMethode = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand RefreshCommand => new Command(async () => await RefreshDataAsync());

        private async Task RefreshDataAsync()
        {
            IsRefreshing = true;
            getAllMethodes();

            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            IsRefreshing = false;
        }
        public MethodeService methodeService { get; set; } = new MethodeService();
        private ObservableCollection<Methode> methode = new ObservableCollection<Methode>();
        public ObservableCollection<Methode> Methodes { get => methode; set { methode = value; OnPropertyChanged(); } }

        public TransfertViewModel()
        {
            getAllMethodes();
        }

        async void getAllMethodes()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                Methodes = await methodeService.getAllMethodes();
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
