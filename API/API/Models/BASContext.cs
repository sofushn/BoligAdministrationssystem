namespace API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BASContext : DbContext
    {
        public BASContext()
            : base("name=BASContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        #region DbSets
        public virtual DbSet<Status_Raport> Status_Raport { get; set; }
        public virtual DbSet<Andelshaver> Andelshaver { get; set; }
        public virtual DbSet<Faldstammer> Faldstammer { get; set; }
        public virtual DbSet<Kontrakter> Kontrakter { get; set; }
        public virtual DbSet<Lejligheder> Lejligheder { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vindue> Vindue { get; set; }
        public virtual DbSet<ListAndelshaversLejlighederView> ListAndelshaversLejlighederView { get; set; }
        public virtual DbSet<ListLejlighedersRaporterView> ListLejlighedersRaporterView { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status_Raport>().ToTable("Status_Raport");
            modelBuilder.Entity<Faldstamme_Raport>().ToTable("Faldstamme_Raport");
            modelBuilder.Entity<Vindue_Raport>().ToTable("Vindue_Raport");



            modelBuilder.Entity<Faldstamme_Raport>()
                .HasRequired(e => e.Faldstamme)
                .WithMany(e => e.Faldstamme_Raporter)
                .HasForeignKey(e => new { e.Faldstamme_ID, e.FaldstammeDel_ID })
                .WillCascadeOnDelete(false);

            //...

            modelBuilder.Entity<Vindue_Raport>()
                .HasRequired(e => e.Vindue)
                .WithMany(e => e.Vindue_Raporter)
                .HasForeignKey(e => e.Vindue_ID)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<Andelshaver>()
                .HasMany(e => e.Kontrakter)
                .WithRequired(e => e.Andelshaver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lejligheder>()
                .Property(e => e.Stoerelse)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Lejligheder>()
                .Property(e => e.Maandelig_Leje)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Lejligheder>()
                .HasMany(e => e.Faldstammer)
                .WithRequired(e => e.Lejligheder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lejligheder>()
                .HasMany(e => e.Kontrakter)
                .WithRequired(e => e.Lejligheder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lejligheder>()
                .HasMany(e => e.Vindue)
                .WithRequired(e => e.Lejligheder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status_Raport>()
                .Property(e => e.Godkendt)
                .IsFixedLength();

            modelBuilder.Entity<ListAndelshaversLejlighederView>()
                .Property(e => e.Stoerelse)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ListAndelshaversLejlighederView>()
                .Property(e => e.Maandelig_Leje)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ListLejlighedersRaporterView>()
                .Property(e => e.Godkendt)
                .IsFixedLength();
            
        }
    }
}
