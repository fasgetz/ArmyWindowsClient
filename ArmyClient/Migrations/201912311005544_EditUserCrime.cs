namespace ArmyClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUserCrime : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.ForeignFriends", "Countries_Id", "dbo.Countries");
            //DropForeignKey("dbo.UserCrimes", "Users_Id", "dbo.Users");
            //DropForeignKey("dbo.Users", "Countries_Id", "dbo.Countries");
            //DropForeignKey("dbo.Users", "Countries_Id1", "dbo.Countries");
            //DropForeignKey("dbo.City", "BirthCountry_Id", "dbo.Countries");
            //DropForeignKey("dbo.Users", "City_Id", "dbo.City");
            //DropForeignKey("dbo.Users", "City_Id1", "dbo.City");
            //DropForeignKey("dbo.City", "ResidenceCountry_Id", "dbo.Countries");
            //DropForeignKey("dbo.UserCrimes", "SocialNetworkUser_Id", "dbo.SocialNetworkUser");
            //DropIndex("dbo.City", new[] { "BirthCountry_Id" });
            //DropIndex("dbo.City", new[] { "ResidenceCountry_Id" });
            //DropIndex("dbo.ForeignFriends", new[] { "Countries_Id" });
            //DropIndex("dbo.SocialNetworkUser", new[] { "SocialNetworkType_Id" });
            //DropIndex("dbo.SocialNetworkUser", new[] { "Users_Id" });
            //DropIndex("dbo.UserCrimes", new[] { "Users_Id" });
            //DropIndex("dbo.Users", new[] { "Countries_Id" });
            //DropIndex("dbo.Users", new[] { "Countries_Id1" });
            //DropIndex("dbo.Users", new[] { "City_Id" });
            //DropIndex("dbo.Users", new[] { "City_Id1" });
            //DropColumn("dbo.SocialNetworkUser", "SocialNetworkId");
            //DropColumn("dbo.UserCrimes", "IdSocialNetworkUser");
            //DropColumn("dbo.Users", "SocialStatusID");
            //DropColumn("dbo.UserSoldierService", "IdUser");
            //DropColumn("dbo.UserSoldierService", "IdSoldierUnit");
            //RenameColumn(table: "dbo.SocialNetworkUser", name: "SocialNetworkType_Id", newName: "SocialNetworkId");
            //RenameColumn(table: "dbo.UserCrimes", name: "SocialNetworkUser_Id", newName: "IdSocialNetworkUser");
            //RenameColumn(table: "dbo.SocialNetworkUser", name: "Users_Id", newName: "IdUser");
            //RenameColumn(table: "dbo.Users", name: "SocialStatuses_IdStatus", newName: "SocialStatusID");
            //RenameColumn(table: "dbo.UserSoldierService", name: "Users_Id", newName: "IdUser");
            //RenameColumn(table: "dbo.UserSoldierService", name: "SoldierUnit_Id", newName: "IdSoldierUnit");
            //RenameColumn(table: "dbo.City", name: "Countries_Id", newName: "CountryId");
            //RenameIndex(table: "dbo.City", name: "IX_Countries_Id", newName: "IX_CountryId");
            //RenameIndex(table: "dbo.UserCrimes", name: "IX_SocialNetworkUser_Id", newName: "IX_IdSocialNetworkUser");
            //RenameIndex(table: "dbo.Users", name: "IX_SocialStatuses_IdStatus", newName: "IX_SocialStatusID");
            //RenameIndex(table: "dbo.UserSoldierService", name: "IX_Users_Id", newName: "IX_IdUser");
            //RenameIndex(table: "dbo.UserSoldierService", name: "IX_SoldierUnit_Id", newName: "IX_IdSoldierUnit");
            //AddColumn("dbo.ForeignFriends", "IdCity", c => c.Int());
            //AddColumn("dbo.UserCrimes", "WebAddressPost", c => c.String());
            //AddColumn("dbo.SoldierUnit", "IdCity", c => c.Int());
            //AlterColumn("dbo.SocialNetworkUser", "SocialNetworkId", c => c.Byte(nullable: false));
            //AlterColumn("dbo.SocialNetworkUser", "IdUser", c => c.Int(nullable: false));
            //AlterColumn("dbo.Users", "Characteristic", c => c.String(unicode: false));
            //CreateIndex("dbo.ForeignFriends", "IdCity");
            //CreateIndex("dbo.SocialNetworkUser", "IdUser");
            //CreateIndex("dbo.SocialNetworkUser", "SocialNetworkId");
            //CreateIndex("dbo.SoldierUnit", "IdCity");
            //AddForeignKey("dbo.ForeignFriends", "IdCity", "dbo.City", "Id");
            //AddForeignKey("dbo.SoldierUnit", "IdCity", "dbo.City", "Id");
            //AddForeignKey("dbo.UserCrimes", "IdSocialNetworkUser", "dbo.SocialNetworkUser", "Id", cascadeDelete: true);
            //DropColumn("dbo.City", "BirthCountry_Id");
            //DropColumn("dbo.City", "ResidenceCountry_Id");
            //DropColumn("dbo.ForeignFriends", "IdCountry");
            //DropColumn("dbo.ForeignFriends", "City");
            //DropColumn("dbo.ForeignFriends", "Countries_Id");
            //DropColumn("dbo.SocialNetworkUser", "UserId");
            //DropColumn("dbo.UserCrimes", "IdUser");
            //DropColumn("dbo.UserCrimes", "Users_Id");
            //DropColumn("dbo.Users", "Countries_Id");
            //DropColumn("dbo.Users", "Countries_Id1");
            //DropColumn("dbo.Users", "City_Id");
            //DropColumn("dbo.Users", "City_Id1");
            //DropColumn("dbo.SoldierUnit", "IdCountry");
            //DropColumn("dbo.SoldierUnit", "City");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.SoldierUnit", "City", c => c.String(maxLength: 35));
            //AddColumn("dbo.SoldierUnit", "IdCountry", c => c.Byte());
            //AddColumn("dbo.Users", "City_Id1", c => c.Int());
            //AddColumn("dbo.Users", "City_Id", c => c.Int());
            //AddColumn("dbo.Users", "Countries_Id1", c => c.Byte());
            //AddColumn("dbo.Users", "Countries_Id", c => c.Byte());
            //AddColumn("dbo.UserCrimes", "Users_Id", c => c.Int());
            //AddColumn("dbo.UserCrimes", "IdUser", c => c.Int(nullable: false));
            //AddColumn("dbo.SocialNetworkUser", "UserId", c => c.Int(nullable: false));
            //AddColumn("dbo.ForeignFriends", "Countries_Id", c => c.Byte());
            //AddColumn("dbo.ForeignFriends", "City", c => c.String(maxLength: 25));
            //AddColumn("dbo.ForeignFriends", "IdCountry", c => c.Byte());
            //AddColumn("dbo.City", "ResidenceCountry_Id", c => c.Byte());
            //AddColumn("dbo.City", "BirthCountry_Id", c => c.Byte());
            //DropForeignKey("dbo.UserCrimes", "IdSocialNetworkUser", "dbo.SocialNetworkUser");
            //DropForeignKey("dbo.SoldierUnit", "IdCity", "dbo.City");
            //DropForeignKey("dbo.ForeignFriends", "IdCity", "dbo.City");
            //DropIndex("dbo.SoldierUnit", new[] { "IdCity" });
            //DropIndex("dbo.SocialNetworkUser", new[] { "SocialNetworkId" });
            //DropIndex("dbo.SocialNetworkUser", new[] { "IdUser" });
            //DropIndex("dbo.ForeignFriends", new[] { "IdCity" });
            //AlterColumn("dbo.Users", "Characteristic", c => c.String());
            //AlterColumn("dbo.SocialNetworkUser", "IdUser", c => c.Int());
            //AlterColumn("dbo.SocialNetworkUser", "SocialNetworkId", c => c.Byte());
            //DropColumn("dbo.SoldierUnit", "IdCity");
            //DropColumn("dbo.UserCrimes", "WebAddressPost");
            //DropColumn("dbo.ForeignFriends", "IdCity");
            //RenameIndex(table: "dbo.UserSoldierService", name: "IX_IdSoldierUnit", newName: "IX_SoldierUnit_Id");
            //RenameIndex(table: "dbo.UserSoldierService", name: "IX_IdUser", newName: "IX_Users_Id");
            //RenameIndex(table: "dbo.Users", name: "IX_SocialStatusID", newName: "IX_SocialStatuses_IdStatus");
            //RenameIndex(table: "dbo.UserCrimes", name: "IX_IdSocialNetworkUser", newName: "IX_SocialNetworkUser_Id");
            //RenameIndex(table: "dbo.City", name: "IX_CountryId", newName: "IX_Countries_Id");
            //RenameColumn(table: "dbo.City", name: "CountryId", newName: "Countries_Id");
            //RenameColumn(table: "dbo.UserSoldierService", name: "IdSoldierUnit", newName: "SoldierUnit_Id");
            //RenameColumn(table: "dbo.UserSoldierService", name: "IdUser", newName: "Users_Id");
            //RenameColumn(table: "dbo.Users", name: "SocialStatusID", newName: "SocialStatuses_IdStatus");
            //RenameColumn(table: "dbo.SocialNetworkUser", name: "IdUser", newName: "Users_Id");
            //RenameColumn(table: "dbo.UserCrimes", name: "IdSocialNetworkUser", newName: "SocialNetworkUser_Id");
            //RenameColumn(table: "dbo.SocialNetworkUser", name: "SocialNetworkId", newName: "SocialNetworkType_Id");
            //AddColumn("dbo.UserSoldierService", "IdSoldierUnit", c => c.Short());
            //AddColumn("dbo.UserSoldierService", "IdUser", c => c.Int());
            //AddColumn("dbo.Users", "SocialStatusID", c => c.Byte());
            //AddColumn("dbo.UserCrimes", "IdSocialNetworkUser", c => c.Int());
            //AddColumn("dbo.SocialNetworkUser", "SocialNetworkId", c => c.Byte(nullable: false));
            //CreateIndex("dbo.Users", "City_Id1");
            //CreateIndex("dbo.Users", "City_Id");
            //CreateIndex("dbo.Users", "Countries_Id1");
            //CreateIndex("dbo.Users", "Countries_Id");
            //CreateIndex("dbo.UserCrimes", "Users_Id");
            //CreateIndex("dbo.SocialNetworkUser", "Users_Id");
            //CreateIndex("dbo.SocialNetworkUser", "SocialNetworkType_Id");
            //CreateIndex("dbo.ForeignFriends", "Countries_Id");
            //CreateIndex("dbo.City", "ResidenceCountry_Id");
            //CreateIndex("dbo.City", "BirthCountry_Id");
            //AddForeignKey("dbo.UserCrimes", "SocialNetworkUser_Id", "dbo.SocialNetworkUser", "Id");
            //AddForeignKey("dbo.City", "ResidenceCountry_Id", "dbo.Countries", "Id");
            //AddForeignKey("dbo.Users", "City_Id1", "dbo.City", "Id");
            //AddForeignKey("dbo.Users", "City_Id", "dbo.City", "Id");
            //AddForeignKey("dbo.City", "BirthCountry_Id", "dbo.Countries", "Id");
            //AddForeignKey("dbo.Users", "Countries_Id1", "dbo.Countries", "Id");
            //AddForeignKey("dbo.Users", "Countries_Id", "dbo.Countries", "Id");
            //AddForeignKey("dbo.UserCrimes", "Users_Id", "dbo.Users", "Id");
            //AddForeignKey("dbo.ForeignFriends", "Countries_Id", "dbo.Countries", "Id");
        }
    }
}
