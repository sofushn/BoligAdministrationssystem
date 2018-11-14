using System.Collections.Generic;

namespace UWP_App.Model
{
    public class Andelshaver
    {
        public int Andelshaver_ID { get; set; }
        public string Navn { get; set; }
        public string EMail { get; set; }
        public string Mobil_Nummer { get; set; }
        public List<Kontrakt> Kontrakter { get; set; }
        public List<Lejlighed> Lejligheder { get; set; }
    }
}