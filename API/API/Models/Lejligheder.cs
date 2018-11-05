namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lejligheder")]
    public partial class Lejligheder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lejligheder()
        {
            Faldstammer = new HashSet<Faldstammer>();
            Kontrakter = new HashSet<Kontrakter>();
            Vindue = new HashSet<Vindue>();
        }

        [Key]
        public int Lejlighed_No { get; set; }

        [Required]
        [StringLength(50)]
        public string Adresse { get; set; }

        public int Rum_Antal { get; set; }

        public decimal Stoerelse { get; set; }

        public decimal Maandelig_Leje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faldstammer> Faldstammer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kontrakter> Kontrakter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vindue> Vindue { get; set; }
    }
}
