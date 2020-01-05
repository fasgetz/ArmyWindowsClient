namespace ArmyClient.Migrations.PostgreSQL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArmyClient.Model.ArmyDB_PG>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\PostgreSQL";
            ContextKey = "ArmyClient.Model.ArmyDB_PG";
        }

        protected override void Seed(ArmyClient.Model.ArmyDB_PG context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
