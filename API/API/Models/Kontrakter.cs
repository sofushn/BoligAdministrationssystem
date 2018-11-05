namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kontrakter")]
    public partial class Kontrakter
    {
        [Key]
        [Column(Order = 0)]
        public int Kontrakt_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Andelshaver_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Lejlighed_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start_Dato { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Slut_Dato { get; set; }

        public virtual Andelshaver Andelshaver { get; set; }

        public virtual Lejligheder Lejligheder { get; set; }
    }
}
