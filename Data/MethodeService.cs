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
    public class MethodeService
    {
        private readonly DataRestFull<Methode> dataRestFull;
        private readonly string url = Links.Methodes;
        public MethodeService()
        {
            dataRestFull = new DataRestFull<Methode>(url);
        }

        public async Task<ObservableCollection<Methode>> getAllMethodes()
        {
            return await dataRestFull.GetAsyncObservable();
        }
    }
}
