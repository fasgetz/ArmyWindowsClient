namespace ArmyClient.ModelExtremistMaterials
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ExtremistMaterialsDB : DbContext
    {
        public ExtremistMaterialsDB()
            : base("name=ExtremistMaterialsDB")
        {
        }

        public virtual DbSet<Materials> Materials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
