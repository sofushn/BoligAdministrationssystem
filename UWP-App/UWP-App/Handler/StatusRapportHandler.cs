using UWP_App.Model;
using System;
using System.Threading.Tasks;
using UWP_App.Persistency;

namespace UWP_App.Handler
{
    public static class StatusRapportHandler
    {
        public static void CreateRapport(string note, StatusValues value, StatusRapportTypes type, ICanBeReportedOn itemToBeREpportedOn)
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

            //DB-IMP : Change to real persistency class
            new TempTestData().CreateStatusRapport(baseRapport);
        }
    }
}