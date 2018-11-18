using System.Collections.Generic;
using System.Threading.Tasks;
using UWP_App.Model;

namespace UWP_App.Persistency
{
    public interface IRetrievePersistency
    {
        Task<IEnumerable<Faldstamme>> GetLejlighedsFaldstammerAsync(Lejlighed lejlighed);
        Task<IEnumerable<Vindue>> GetLejlighedsVinduerAsync(Lejlighed lejlighed);
        Task<IEnumerable<StatusRapportBase>> GetLejlighedsStatusRapporterAsync(Lejlighed lejlighed);
        Task<IEnumerable<Lejlighed>> GetAndelshaversLejlighederAsync(Andelshaver andelshaver);
        Task<IEnumerable<Kontrakt>> GetAndelshaversKontrakterAsync(Andelshaver andelshaver);
        Task<Andelshaver> GetAndelshaverAsync(int andelshaverID);

    }
}