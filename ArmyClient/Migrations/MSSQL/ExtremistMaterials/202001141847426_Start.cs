namespace ArmyClient.Migrations.MSSQL.ExtremistMaterials
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.FoundMaterials",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            IdMaterial = c.Int(nullable: false),
            //            WebAddress = c.String(maxLength: 150),
            //            DateOfEntry = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Materials", t => t.IdMaterial, cascadeDelete: true)
            //    .Index(t => t.IdMaterial);
            
            //CreateTable(
            //    "dbo.Materials",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            Material = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.FoundMaterials", "IdMaterial", "dbo.Materials");
            //DropIndex("dbo.FoundMaterials", new[] { "IdMaterial" });
            //DropTable("dbo.Materials");
            //DropTable("dbo.FoundMaterials");
        }
    }
}
