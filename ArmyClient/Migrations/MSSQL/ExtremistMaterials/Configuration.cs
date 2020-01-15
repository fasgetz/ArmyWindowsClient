namespace ArmyClient.Migrations.MSSQL.ExtremistMaterials
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArmyClient.Models.ModelExtremistMaterials.ExmMaterialsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\MSSQL\ExtremistMaterials";
        }

        protected override void Seed(ArmyClient.Models.ModelExtremistMaterials.ExmMaterialsDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
