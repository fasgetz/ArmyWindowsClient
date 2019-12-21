namespace ArmyClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ForeignFriends", "Photo", c => c.Binary());
            AlterColumn("dbo.SocialNetworkUser", "Description", c => c.String(unicode: false));
            AlterColumn("dbo.UserCrimes", "Photo", c => c.Binary());
            AlterColumn("dbo.Users", "Photo", c => c.Binary());
            AlterColumn("dbo.Users", "DateBirth", c => c.DateTime());
            AlterColumn("dbo.Users", "Characteristic", c => c.String(unicode: false));
            AlterColumn("dbo.UserSoldierService", "DateStart", c => c.DateTime());
            AlterColumn("dbo.UserSoldierService", "DateEnd", c => c.DateTime());
            AlterColumn("dbo.UserSoldierService", "Data", c => c.String(unicode: false));
            AlterColumn("dbo.SoldierUnit", "AbountInform", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SoldierUnit", "AbountInform", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.UserSoldierService", "Data", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.UserSoldierService", "DateEnd", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.UserSoldierService", "DateStart", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Users", "Characteristic", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Users", "DateBirth", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Users", "Photo", c => c.Binary(storeType: "image"));
            AlterColumn("dbo.UserCrimes", "Photo", c => c.Binary(storeType: "image"));
            AlterColumn("dbo.SocialNetworkUser", "Description", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.ForeignFriends", "Photo", c => c.Binary(storeType: "image"));
        }
    }
}
