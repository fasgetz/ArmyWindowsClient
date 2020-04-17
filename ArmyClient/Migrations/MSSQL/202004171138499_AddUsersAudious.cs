namespace ArmyClient.Migrations.MSSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersAudious : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialNetworkAudios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocialNetworkUserID = c.Int(nullable: false),
                        ArtistName = c.String(),
                        AudioName = c.String(),
                        DateAddedSocNetw = c.DateTime(),
                        DateAddedOnDB = c.DateTime(),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SocialNetworkUser", t => t.SocialNetworkUserID, cascadeDelete: true)
                .Index(t => t.SocialNetworkUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialNetworkAudios", "SocialNetworkUserID", "dbo.SocialNetworkUser");
            DropIndex("dbo.SocialNetworkAudios", new[] { "SocialNetworkUserID" });
            DropTable("dbo.SocialNetworkAudios");
        }
    }
}
