using System.Collections.Generic;
using System.Threading.Tasks;
using UWP_App.Model;

namespace UWP_App.Persistency
{
    public interface IRetrievePersistency
    {
        IEnumerable<Faldstamme> GetLejlighedsFaldstammer(Lejlighed lejlighed);
        IEnumerable<Vindue> GetLejlighedsVinduer(Lejlighed lejlighed);
        Task<IEnumerable<StatusRapportBase>> GetLejlighedsStatusRapporterAsync(Lejlighed lejlighed);
        IEnumerable<Lejlighed> GetAndelshaversLejligheder(Andelshaver andelshaver);
        IEnumerable<Kontrakt> GetAndelshaversKontrakter(Andelshaver andelshaver);
        Andelshaver GetAndelshaver(int andelshaverID);

    }
}