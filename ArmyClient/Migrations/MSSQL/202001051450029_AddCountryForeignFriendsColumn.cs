namespace ArmyClient.Migrations.MSSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryForeignFriendsColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ForeignFriends", "CountryId", c => c.Byte());
            CreateIndex("dbo.ForeignFriends", "CountryId");
            AddForeignKey("dbo.ForeignFriends", "CountryId", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ForeignFriends", "CountryId", "dbo.Countries");
            DropIndex("dbo.ForeignFriends", new[] { "CountryId" });
            DropColumn("dbo.ForeignFriends", "CountryId");
        }
    }
}
