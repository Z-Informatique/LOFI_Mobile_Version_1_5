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
    public class HomeViewModel : BaseViewModel
    {
        private CompteService CompteService { get; set; } = new CompteService();
        public Compte Compte { get; set; } = new Compte();
        string _prenom;
        public string Prenom
        {
            get => _prenom;
            set
            {
                _prenom = value;
                OnPropertyChanged();
            }
        }
        public HomeViewModel()
        {
            Prenom = Helpers.Settings.Prenom;
        }

        async Task getCompte()
        {
            if (Helpers.Settings.UserRole == "0")
            {
                Compte = await CompteService.CompteAsync(Convert.ToInt32(Helpers.Settings.IdUser));
                //if (Compte is not null)
                //    Helpers.Settings.IdCompte = Compte.Id.ToString();
            }
        }
    }
}
