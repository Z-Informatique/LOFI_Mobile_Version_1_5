using LOFI.Helpers;
using LOFI.Models;

namespace LOFI.Data
{
    public class CompteService
    {
        private readonly DataRestFull<Compte> dataRestFull;
        private readonly string url = Links.comptes;

        public CompteService()
        {
            dataRestFull = new DataRestFull<Compte>(url);
        }

        public async Task<Compte> CompteAsync(int IdUser)
        {
            Compte compte = await dataRestFull.GetDataByParameter($"comptesByUser?IdUser={IdUser}");
            return compte;
        }

    }
}
