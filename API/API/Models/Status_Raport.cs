namespace API.Models
{
    using API.Converter;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [JsonConverter(typeof(RaportJsonConverter))]
    public partial class Status_Raport
    {
        [Key]
        public int Status_ID { get; set; }

        public int Status { get; set; }
        public DateTime Dato { get; set; }
        public string Note { get; set; }
        public int RaportType { get; set; }

        [Required]
        [StringLength(5)]
        public string Godkendt { get; set; }
    }

    public class Faldstamme_Raport : Status_Raport
    {
        public int Faldstamme_ID { get; set; }
        public int FaldstammeDel_ID { get; set; }
        public virtual Faldstammer Faldstamme { get; set; }
    }

    public class Vindue_Raport : Status_Raport
    {
        public int Vindue_ID { get; set; }
        public virtual Vindue Vindue { get; set; }
    }
}
