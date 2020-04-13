namespace ArmyClient.Migrations.MSSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialNetworkGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocialNetworkUserID = c.Int(nullable: false),
                        Name = c.String(),
                        GroupAddress = c.String(),
                        MembersCount = c.Int(nullable: false),
                        DateAddedOnDB = c.DateTime(storeType: "date"),
                        GroupPublicity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SocialNetworkUser", t => t.SocialNetworkUserID, cascadeDelete: true)
                .Index(t => t.SocialNetworkUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialNetworkGroups", "SocialNetworkUserID", "dbo.SocialNetworkUser");
            DropIndex("dbo.SocialNetworkGroups", new[] { "SocialNetworkUserID" });
            DropTable("dbo.SocialNetworkGroups");
        }
    }
}
