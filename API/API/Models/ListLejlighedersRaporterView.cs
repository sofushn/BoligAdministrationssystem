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
        public int RaportStatus { get; set; }

        //[Key]
        [Column(Order = 2)]
        public DateTime Dato { get; set; }

        public string Note { get; set; }

        //[Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RaportType { get; set; }

        //[Key]
        [Column(Order = 4)]
        [StringLength(5)]
        public string Godkendt { get; set; }

        //[Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Faldstamme_ID { get; set; }

        //[Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Del_ID { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Lejlighed_No { get; set; }

        //[Key]
        [Column(Order = 8)]
        public int Status { get; set; }
    }
}
