namespace ArmyClient.Migrations.PostgreSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        CountryId = c.Short(),
                        Countries_Id = c.Short(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Countries_Id)
                .Index(t => t.Countries_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Short(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ForeignFriends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocialNetworkUserID = c.Int(nullable: false),
                        WebAddress = c.String(nullable: false, maxLength: 60),
                        Name = c.String(maxLength: 25),
                        Family = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 25),
                        IdCity = c.Int(),
                        BirthDay = c.DateTime(storeType: "date"),
                        Photo = c.Binary(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.City_Id)
                .ForeignKey("dbo.SocialNetworkUser", t => t.SocialNetworkUserID, cascadeDelete: true)
                .Index(t => t.SocialNetworkUserID)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.SocialNetworkUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        SocialNetworkId = c.Short(nullable: false),
                        WebAddress = c.String(nullable: false, maxLength: 100),
                        Opened = c.Boolean(nullable: false),
                        Description = c.String(),
                        SocialNetworkType_Id = c.Short(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SocialNetworkType", t => t.SocialNetworkType_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.SocialNetworkType_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.SocialNetworkType",
                c => new
                    {
                        Id = c.Short(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserCrimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSocialNetworkUser = c.Int(),
                        Photo = c.Binary(),
                        DateLoad = c.DateTime(),
                        Description = c.String(),
                        DateEnty = c.DateTime(nullable: false),
                        IsCrime = c.Boolean(nullable: false),
                        WebAddressPost = c.String(nullable: false),
                        SocialNetworkUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SocialNetworkUser", t => t.SocialNetworkUser_Id)
                .Index(t => t.SocialNetworkUser_Id);
            
            CreateTable(
                "dbo.UserCrimesCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCrimesId = c.Int(nullable: false),
                        CrimesTypeId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CrimesType", t => t.CrimesTypeId, cascadeDelete: true)
                .ForeignKey("dbo.UserCrimes", t => t.UserCrimesId, cascadeDelete: true)
                .Index(t => t.UserCrimesId)
                .Index(t => t.CrimesTypeId);
            
            CreateTable(
                "dbo.CrimesType",
                c => new
                    {
                        Id = c.Short(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        Family = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 25),
                        Photo = c.Binary(),
                        DateBirth = c.DateTime(),
                        AddressResidence = c.String(maxLength: 150),
                        Characteristic = c.String(),
                        IsMonitoring = c.Boolean(),
                        SocialStatusID = c.Short(),
                        email = c.String(maxLength: 50),
                        phone = c.String(maxLength: 15),
                        DateOfEntry = c.DateTime(),
                        CityBirth_Id = c.Int(),
                        CurrentCityResience_Id = c.Int(),
                        City_Id = c.Int(),
                        City1_Id = c.Int(),
                        SocialStatuses_IdStatus = c.Short(),
                        City_Id1 = c.Int(),
                        City_Id2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.City_Id)
                .ForeignKey("dbo.City", t => t.City1_Id)
                .ForeignKey("dbo.SocialStatuses", t => t.SocialStatuses_IdStatus)
                .ForeignKey("dbo.City", t => t.City_Id1)
                .ForeignKey("dbo.City", t => t.City_Id2)
                .Index(t => t.City_Id)
                .Index(t => t.City1_Id)
                .Index(t => t.SocialStatuses_IdStatus)
                .Index(t => t.City_Id1)
                .Index(t => t.City_Id2);
            
            CreateTable(
                "dbo.SocialStatuses",
                c => new
                    {
                        IdStatus = c.Short(nullable: false),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.IdStatus);
            
            CreateTable(
                "dbo.UserSoldierService",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(),
                        IdSoldierUnit = c.Short(),
                        DateStart = c.DateTime(),
                        DateEnd = c.DateTime(),
                        Rank = c.String(maxLength: 50),
                        Position = c.String(maxLength: 50),
                        Data = c.String(),
                        SoldierUnit_Id = c.Short(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SoldierUnit", t => t.SoldierUnit_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.SoldierUnit_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.SoldierUnit",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Affilation = c.String(maxLength: 50),
                        IdCity = c.Int(),
                        AddressResidence = c.String(maxLength: 150),
                        AbountInform = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.City_Id)
                .Index(t => t.City_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "City_Id2", "dbo.City");
            DropForeignKey("dbo.Users", "City_Id1", "dbo.City");
            DropForeignKey("dbo.UserSoldierService", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.UserSoldierService", "SoldierUnit_Id", "dbo.SoldierUnit");
            DropForeignKey("dbo.SoldierUnit", "City_Id", "dbo.City");
            DropForeignKey("dbo.Users", "SocialStatuses_IdStatus", "dbo.SocialStatuses");
            DropForeignKey("dbo.SocialNetworkUser", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "City1_Id", "dbo.City");
            DropForeignKey("dbo.Users", "City_Id", "dbo.City");
            DropForeignKey("dbo.UserCrimesCategory", "UserCrimesId", "dbo.UserCrimes");
            DropForeignKey("dbo.UserCrimesCategory", "CrimesTypeId", "dbo.CrimesType");
            DropForeignKey("dbo.UserCrimes", "SocialNetworkUser_Id", "dbo.SocialNetworkUser");
            DropForeignKey("dbo.SocialNetworkUser", "SocialNetworkType_Id", "dbo.SocialNetworkType");
            DropForeignKey("dbo.ForeignFriends", "SocialNetworkUserID", "dbo.SocialNetworkUser");
            DropForeignKey("dbo.ForeignFriends", "City_Id", "dbo.City");
            DropForeignKey("dbo.City", "Countries_Id", "dbo.Countries");
            DropIndex("dbo.SoldierUnit", new[] { "City_Id" });
            DropIndex("dbo.UserSoldierService", new[] { "Users_Id" });
            DropIndex("dbo.UserSoldierService", new[] { "SoldierUnit_Id" });
            DropIndex("dbo.Users", new[] { "City_Id2" });
            DropIndex("dbo.Users", new[] { "City_Id1" });
            DropIndex("dbo.Users", new[] { "SocialStatuses_IdStatus" });
            DropIndex("dbo.Users", new[] { "City1_Id" });
            DropIndex("dbo.Users", new[] { "City_Id" });
            DropIndex("dbo.UserCrimesCategory", new[] { "CrimesTypeId" });
            DropIndex("dbo.UserCrimesCategory", new[] { "UserCrimesId" });
            DropIndex("dbo.UserCrimes", new[] { "SocialNetworkUser_Id" });
            DropIndex("dbo.SocialNetworkUser", new[] { "Users_Id" });
            DropIndex("dbo.SocialNetworkUser", new[] { "SocialNetworkType_Id" });
            DropIndex("dbo.ForeignFriends", new[] { "City_Id" });
            DropIndex("dbo.ForeignFriends", new[] { "SocialNetworkUserID" });
            DropIndex("dbo.City", new[] { "Countries_Id" });
            DropTable("dbo.SoldierUnit");
            DropTable("dbo.UserSoldierService");
            DropTable("dbo.SocialStatuses");
            DropTable("dbo.Users");
            DropTable("dbo.CrimesType");
            DropTable("dbo.UserCrimesCategory");
            DropTable("dbo.UserCrimes");
            DropTable("dbo.SocialNetworkType");
            DropTable("dbo.SocialNetworkUser");
            DropTable("dbo.ForeignFriends");
            DropTable("dbo.Countries");
            DropTable("dbo.City");
        }
    }
}
