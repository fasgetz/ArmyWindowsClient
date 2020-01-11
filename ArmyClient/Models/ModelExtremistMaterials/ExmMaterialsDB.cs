namespace ArmyClient.Models.ModelExtremistMaterials
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ExmMaterialsDB : DbContext
    {
        public ExmMaterialsDB()
            : base("name=ExmMaterialsDB")
        {
        }

        public virtual DbSet<FoundMaterials> FoundMaterials { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materials>()
                .HasMany(e => e.FoundMaterials)
                .WithRequired(e => e.Materials)
                .HasForeignKey(e => e.IdMaterial);
        }
    }
}
