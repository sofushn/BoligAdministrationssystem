using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAppWindows.Models
{
    public class Faldstamme
    {
        public int Faldstamme_ID { get; set; }
        public int Del_ID { get; set; }
        public int Lejlighed_No { get; set; }
        public StatusValues Status { get; set; }
        public object Lejligheder { get; set; }

        public string IDCombine
        {
            get { return Faldstamme_ID + "," + Del_ID; }
        }
    }
}
