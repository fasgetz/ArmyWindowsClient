namespace ArmyClient.Migrations.MSSQL.ExtremistMaterials
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tested : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.FoundMaterials", new[] { "WebAddress" });
            //CreateTable(
            //    "dbo.LoadingNotImages",
            //    c => new
            //        {
            //            IdMaterial = c.Int(nullable: false),
            //            WebAddress = c.String(maxLength: 150),
            //            Material = c.String(),
            //            DateOfEntry = c.DateTime(),
            //            DateOfLoading = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.IdMaterial);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.LoadingNotImages");
            //CreateIndex("dbo.FoundMaterials", "WebAddress", unique: true);
        }
    }
}
