using MainAppWindows.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAppWindows.Models
{
    public class StatusRaport
    {
        public int Status_ID { get; set; }
        public StatusValues Status { get; set; }
        public DateTime Dato { get; set; }
        public string Note { get; set; }
        public StatusRaportTypes RaportType { get; set; }
        public bool Godkendt { get; set; }
    }
}
