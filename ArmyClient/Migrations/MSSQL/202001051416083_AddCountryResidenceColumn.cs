namespace ArmyClient.Migrations.MSSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryResidenceColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CountryResidence_Id", c => c.Byte());
            CreateIndex("dbo.Users", "CountryResidence_Id");
            AddForeignKey("dbo.Users", "CountryResidence_Id", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CountryResidence_Id", "dbo.Countries");
            DropIndex("dbo.Users", new[] { "CountryResidence_Id" });
            DropColumn("dbo.Users", "CountryResidence_Id");
        }
    }
}
