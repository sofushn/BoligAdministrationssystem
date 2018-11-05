using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainAppWindows.Persistency;
using MainAppWindows.Models;

namespace MainAppWindows.Handler
{
    public static class OverallHandler
    {
        public static List<Lejlighed> GetAndelshaversLejligheder(int andelshaverID)
        {
            return PersistencyFacade.GetAndelshaversLejligheder(andelshaverID);
        }
    }
}
