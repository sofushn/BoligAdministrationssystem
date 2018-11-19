using System.Threading.Tasks;
using UWP_App.Model;

namespace UWP_App.Persistency
{
    public interface ICreatePersistency
    {
        Task CreateStatusRapport(StatusRapportBase statusRapport);
    }
}