namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListLejlighedersRaporterView")]
    public partial class ListLejlighedersRaporterView
    {
        [Key]
        public int Status_ID { get; set; }

        public int RapportStatus { get; set; }

        public DateTime? Dato { get; set; }

        public string Note { get; set; }

        public int RapportType { get; set; }

        [StringLength(5)]
        public string Godkendt { get; set; }

        public int? Faldstamme_ID { get; set; }

        public int? FaldstammeDel_ID { get; set; }

        public int? Vindue_ID { get; set; }

        public int Lejlighed_No { get; set; }
    }
}
