using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAppWindows.Models
{
    public class Kontrakt
    {
        public int Kontrakt_ID { get; set; }
        public int Andelshaver_ID { get; set; }
        public int Lejlighed_No { get; set; }
        public DateTime Start_Dato { get; set; }
        public DateTime Slut_Dato { get; set; }
    }
}
