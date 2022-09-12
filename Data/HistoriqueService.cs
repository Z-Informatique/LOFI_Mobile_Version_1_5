using LOFI.Helpers;
using LOFI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Data
{
    public class HistoriqueService
    {
        private readonly DataRestFull<Historique> dataRestFull;
        private readonly string url = Links.historiques;
        private readonly SerializeClass<Compte> serializeClass = new SerializeClass<Compte>();
        public Compte Compte = new Compte();
        public HistoriqueService()
        {
            dataRestFull = new DataRestFull<Historique>(url);
            Compte = serializeClass.Deserialize(Settings.Compte);
        }

        public async Task<ObservableCollection<Historique>> getHistoriqueListByCompte()
        {
            return await dataRestFull.GetDataListByParameterObs($"gethistoriquebycompte?idCompte={Compte.Id}");
        }

    }
}
