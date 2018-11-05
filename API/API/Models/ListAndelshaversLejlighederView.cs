namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListAndelshaversLejlighederView")]
    public partial class ListAndelshaversLejlighederView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Andelshaver_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Lejlighed_No { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Adresse { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rum_Antal { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Stoerelse { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal Maandelig_Leje { get; set; }
    }
}
