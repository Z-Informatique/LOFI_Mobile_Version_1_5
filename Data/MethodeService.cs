using LOFI.Helpers;
using LOFI.Models;
using System.Collections.ObjectModel;

namespace LOFI.Data;

public class MethodeService
{
    private readonly DataRestFull<Methode> dataRestFull;
    private readonly DataRestFull<Operateur> restOperateur;
    private readonly string url = Links.Methodes;
    private readonly string urlOperateur = Links.Operateurs;
    public MethodeService()
    {
        dataRestFull = new DataRestFull<Methode>(url);
        restOperateur = new DataRestFull<Operateur>(urlOperateur);
    }

    public async Task<ObservableCollection<Methode>> getAllMethodes()
    {
        return await dataRestFull.GetAsyncObservable();
    }

    public async Task<ObservableCollection<Operateur>> getAllOperateur() => await restOperateur.GetAsyncObservable();

}
