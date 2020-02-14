namespace ArmyClient.Migrations.MSSQL.ExtremistMaterials
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedScreenShotAndDateOfLoading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoundMaterials", "ScreenShot", c => c.Binary(nullable: true));
            AddColumn("dbo.FoundMaterials", "DateOfLoading", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoundMaterials", "DateOfLoading");
            DropColumn("dbo.FoundMaterials", "ScreenShot");
        }
    }
}
