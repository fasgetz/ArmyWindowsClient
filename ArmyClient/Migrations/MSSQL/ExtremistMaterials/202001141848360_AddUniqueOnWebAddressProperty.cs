namespace ArmyClient.Migrations.MSSQL.ExtremistMaterials
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueOnWebAddressProperty : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FoundMaterials", "WebAddress", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.FoundMaterials", new[] { "WebAddress" });
        }
    }
}
