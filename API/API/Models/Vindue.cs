namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vindue")]
    public partial class Vindue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vindue()
        {
            Vindue_Raporter = new HashSet<Vindue_Raport>();
        }

        [Key]
        public int Vindue_ID { get; set; }

        public int Lejlighed_No { get; set; }

        public int Status { get; set; }

        public DateTime Sidst_Malet { get; set; }

        public virtual Lejligheder Lejligheder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vindue_Raport> Vindue_Raporter { get; set; }
    }
}
