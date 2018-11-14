using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_App.Model
{
    public class Faldstamme : ICanBeReportedOn
    {
        public int Faldstamme_ID { get; set; }
        public int Del_ID { get; set; }
        public StatusValues Status { get; set; }

        public string IDCombine
        {
            get { return Faldstamme_ID + "," + Del_ID; }
        }

        public int Lejlighed_No { get; set; }
        public string Beskrivelse { get; set; }
    }
}
