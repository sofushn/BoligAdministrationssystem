using UWP_App.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UWP_App.Persistency;

namespace UWP_App.Handler
{
    public class StatusRapportHandler
    {
        private ICreatePersistency _createPersistency;
        private IRetrievePersistency _retrievePersistency;
        
        public StatusRapportHandler()
        {
            _createPersistency = CurrentUser.Persistency;
            _retrievePersistency = CurrentUser.Persistency;
        }

        public async Task CreateRapportAsync(string note, StatusValues value, StatusRapportTypes type, ICanBeReportedOn itemToBeREpportedOn)
        {
            StatusRapportBase baseRapport = null;
            switch (type)
            {
                case StatusRapportTypes.Faldstamme:
                {
                    StatusRapportFaldstamme faldstammeRapport = new StatusRapportFaldstamme();
                    faldstammeRapport.Faldstamme = itemToBeREpportedOn as Faldstamme;

                    baseRapport = faldstammeRapport;
                    break;
                }
                case StatusRapportTypes.Vindue:
                {
                    StatusRapportVindue vindueRapport = new StatusRapportVindue();
                    vindueRapport.Vindue = itemToBeREpportedOn as Vindue;

                    baseRapport = vindueRapport;
                    break;
                }
                default:
                {
                    throw new ArgumentException("is not a valid value", "type");
                }
            }

            baseRapport.Dato = DateTime.Now;
            baseRapport.Godkendt = false;
            baseRapport.Note = note;
            baseRapport.Status = value;
            
            await _createPersistency.CreateStatusRapport(baseRapport);
        
        }

        public IEnumerable<StatusRapportBase> GetLejlighedsRapporter(Lejlighed lejlighed)
        {
            return _retrievePersistency.GetLejlighedsStatusRapporter(lejlighed);
        }
    }
}