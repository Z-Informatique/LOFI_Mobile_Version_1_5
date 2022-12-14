using CommunityToolkit.Mvvm.ComponentModel;
using LOFI.Data;
using LOFI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private CompteService CompteService { get; set; } = new CompteService();

        [ObservableProperty]
        Compte compte;

        [ObservableProperty]
        string fullName;
        
        [ObservableProperty]
        string telephone;
        
        [ObservableProperty]
        bool isBusy;

        public HomeViewModel()
        {
            FullName = Helpers.Settings.Nom + " " + Helpers.Settings.Prenom;
            Telephone = Helpers.Settings.Telephone;

            getCompte();
        }

        async void getCompte()
        {
            try
            {
                IsBusy = true;
                if (Helpers.Settings.UserRole == "0")
                {
                    Compte = await CompteService.CompteAsync(Convert.ToInt32(Helpers.Settings.IdUser));
                    //if (Compte is not null)
                    //    Helpers.Settings.IdCompte = Compte.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erreur !", "Une erreur s'est produite. " + ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
