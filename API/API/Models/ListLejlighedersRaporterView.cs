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
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Status_ID { get; set; }

        //[Key]
        [Column(Order = 1)]
        public int RapportStatus { get; set; }

        //[Key]
        [Column(Order = 2)]
        public DateTime Dato { get; set; }

        [Column(Order = 3)]
        public string Note { get; set; }

        //[Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RapportType { get; set; }

        //[Key]
        [Column(Order = 5)]
        [StringLength(5)]
        public string Godkendt { get; set; }

        //[Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Faldstamme_ID { get; set; }

        //[Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaldstammeDel_ID { get; set; }

        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Vindue_ID { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Lejlighed_No { get; set; }
    }
}
