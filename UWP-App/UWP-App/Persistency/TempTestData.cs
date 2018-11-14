using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UWP_App.Model;

namespace UWP_App.Persistency
{
    public class TempTestData : IPersistency
    {
        public IEnumerable<Faldstamme> GetLejlighedsFaldstammer(Lejlighed lejlighed)
        {
            List<Faldstamme> list = new List<Faldstamme>()
            {
                new Faldstamme()
                {
                    Faldstamme_ID = 0,
                    Del_ID = 0,
                    Status = StatusValues.Normal,
                    Lejlighed_No = 0,
                    Beskrivelse = "I køkkenet"
                },
                new Faldstamme()
                {
                    Faldstamme_ID = 1,
                    Del_ID = 0,
                    Status = StatusValues.Bad,
                    Lejlighed_No = 0,
                    Beskrivelse = "På toiletet"
                },
                new Faldstamme()
                {
                    Faldstamme_ID = 0,
                    Del_ID = 1,
                    Status = StatusValues.Normal,
                    Lejlighed_No = 1,
                    Beskrivelse = "I køkkenet"
                }
            };

            return list.Where(x => x.Lejlighed_No == lejlighed.Lejlighed_No);
        }

        public IEnumerable<StatusRapportBase> GetLejlighedsStatusRapporter(Lejlighed lejlighed)
        {
            List<StatusRapportBase> list = new List<StatusRapportBase>()
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

            return list;
        }

        public IEnumerable<Lejlighed> GetAndelshaversLejligheder()
        {
            Lejlighed l = new Lejlighed()
            {
                Lejlighed_No = 0,
                Adresse = "Hjemmevej, 1234 Lille by, Danmark",
                Maandelig_Leje = 5000,
                Rum_Antal = 2,
                Stoerelse = 120
            };
            return new List<Lejlighed>() {l};
        }

        public Andelshaver GetAndelshaver()
        {
            throw new System.NotImplementedException();
        }
    }
}