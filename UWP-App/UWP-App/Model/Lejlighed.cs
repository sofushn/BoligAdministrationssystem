using System.Collections.Generic;

namespace UWP_App.Model
{
    public class Lejlighed
    {
        public int Lejlighed_No { get; set; }
        public string Adresse { get; set; }
        public int Rum_Antal { get; set; }
        public float Stoerelse { get; set; }
        public float Maandelig_Leje { get; set; }
        public IEnumerable<Faldstamme> Faldstammer { get; set; }
        public IEnumerable<Vindue> Vinduer { get; set; }

        public Lejlighed() { }
    }
}