using System.Collections.Generic;
using UWP_App.Model;

namespace UWP_App.Persistency
{
    public interface IPersistency
    {
        IEnumerable<Faldstamme> GetLejlighedsFaldstammer(Lejlighed lejlighed);
        IEnumerable<Vindue> GetLejlighedsVinduer(Lejlighed lejlighed);
        IEnumerable<StatusRapportBase> GetLejlighedsStatusRapporter(Lejlighed lejlighed);
        IEnumerable<Lejlighed> GetAndelshaversLejligheder();
        Andelshaver GetAndelshaver();

    }
}