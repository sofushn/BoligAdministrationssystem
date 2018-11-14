using System;

namespace UWP_App.Model
{
    public abstract class StatusRapportBase
    {
        public int Status_ID { get; set; }
        public StatusValues Status { get; set; }
        public DateTime Dato { get; set; }
        public string Note { get; set; }
        public abstract StatusRapportTypes RapportType { get; }
        public bool Godkendt { get; set; }
    }
}