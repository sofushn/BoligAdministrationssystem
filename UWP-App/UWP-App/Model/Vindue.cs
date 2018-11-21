using System;
using System.Collections.Generic;

namespace UWP_App.Model
{
    public class Vindue : ICanBeReportedOn
    {
        public int Vindue_ID { get; set; }
        public int Lejlighed_No { get; set; }
        public string Beskrivelse { get; set; }

        public StatusValues Status { get; set; }
        public DateTime? Sidst_Malet { get; set; }

    }
}