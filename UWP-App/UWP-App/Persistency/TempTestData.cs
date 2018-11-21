using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UWP_App.Model;

namespace UWP_App.Persistency
{
    public class TempTestData : IPersistency
    {
        private static List<StatusRapportBase> _statusRapports;

        static TempTestData()
        {
            _statusRapports = new List<StatusRapportBase>()
            {
                new StatusRapportVindue()
                {
                    Status_ID = 0,
                    Status = StatusValues.Normal,
                    Dato = DateTime.Now,
                    Note = "Mit vindue er utæt balalallallalalallal"
                },
                new StatusRapportFaldstamme()
                {
                    Status_ID = 1,
                    Status = StatusValues.Bad,
                    Dato = DateTime.Now.AddDays(-2d),
                    Note = "Der løber vand fra min faldstamme"
                },
                new StatusRapportFaldstamme()
                {
                    Status_ID = 2,
                    Status = StatusValues.Important,
                    Dato = DateTime.Now,
                    Note = "Der fosser ud med vand fra min faldstamme, gulvet er helt vådt",
                    Godkendt = true
                }
            };
        }

        public async Task<IEnumerable<Faldstamme>> GetLejlighedsFaldstammerAsync(Lejlighed lejlighed)
        {
            List<Faldstamme> list = new List<Faldstamme>()
            {
                new Faldstamme()
                {
                    Faldstamme_ID = 0,
                    Del_ID = 0,
                    Status = StatusValues.Normal,
                    Lejlighed_No = 0,
                    Beskrivelse = "Faldstammen i køkkenet"
                },
                new Faldstamme()
                {
                    Faldstamme_ID = 1,
                    Del_ID = 0,
                    Status = StatusValues.Bad,
                    Lejlighed_No = 0,
                    Beskrivelse = "Faldstammen på toiletet"
                },
                new Faldstamme()
                {
                    Faldstamme_ID = 0,
                    Del_ID = 1,
                    Status = StatusValues.Normal,
                    Lejlighed_No = 1,
                    Beskrivelse = "Faldstamme i køkkenet"
                }
            };

            return list.Where(x => x.Lejlighed_No == lejlighed.Lejlighed_No);
        }

        public async Task<IEnumerable<Vindue>> GetLejlighedsVinduerAsync(Lejlighed lejlighed)
        {
            List<Vindue> list = new List<Vindue>()
            {
                new Vindue()
                {
                    Vindue_ID = 0,
                    Status = StatusValues.Normal,
                    Lejlighed_No = 0,
                    Beskrivelse = "Det store vindue i studen"
                },
                new Vindue()
                {
                    Vindue_ID = 1,
                    Status = StatusValues.Bad,
                    Lejlighed_No = 0,
                    Beskrivelse = "Det lille vindue i stuen"
                },
                new Vindue()
                {
                    Vindue_ID = 2,
                    Status = StatusValues.Normal,
                    Lejlighed_No = 1,
                    Beskrivelse = "Vinduet i køkknet"
                }
            };

            return list.Where(x => x.Lejlighed_No == lejlighed.Lejlighed_No);
        }

        public async Task<IEnumerable<StatusRapportBase>> GetLejlighedsStatusRapporterAsync(Lejlighed lejlighed)
        {
            return _statusRapports;
        }

        public async Task<IEnumerable<Lejlighed>> GetAndelshaversLejlighederAsync(Andelshaver andelshaver)
        {
            List<Lejlighed> list =  new List<Lejlighed>()
            {
                new Lejlighed()
                {
                    Lejlighed_No = 0,
                    Adresse = "Hjemmevej, 1234 Lille by, Danmark",
                    Maandelig_Leje = 5000,
                    Rum_Antal = 2,
                    Stoerelse = 120
                }

            };

            List<Lejlighed> returnList = new List<Lejlighed>();
            foreach (Kontrakt kontrakt in andelshaver.Kontrakter)
            {
                returnList.AddRange(list.Where(x => x.Lejlighed_No == kontrakt.Lejlighed_No));
            }

            return returnList;
        }

        public async Task<IEnumerable<Kontrakt>> GetAndelshaversKontrakterAsync(Andelshaver andelshaver)
        {
            List<Kontrakt> list = new List<Kontrakt>()
            {
                new Kontrakt()
                {
                    Kontrakt_ID = 0,
                    Andelshaver_ID = 1,
                    Lejlighed_No = 0,
                }
            };

            return list;
        }

        public async Task<Andelshaver> GetAndelshaverAsync(int andelshaverID)
        {
            return new Andelshaver() { Andelshaver_ID = 1 };
        }

        public IEnumerable<StatusRapportBase> GetLejlighedsStatusRapporter(Lejlighed lejlighed) {
            return GetLejlighedsStatusRapporterAsync(lejlighed).Result;
        }

        public async Task CreateStatusRapport(StatusRapportBase statusRapport)
        {
            // Simulates the DB generating a id
            statusRapport.Status_ID = _statusRapports.Count;
            // Adds to db
            _statusRapports.Add(statusRapport);
        }
    }
}