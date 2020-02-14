namespace ArmyClient.Migrations.MSSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSessions3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialNetworkSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSocialNetworkUser = c.Int(nullable: false),
                        DateStart = c.DateTime(),
                        DateEnd = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SocialNetworkUser", t => t.IdSocialNetworkUser)
                .Index(t => t.IdSocialNetworkUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialNetworkSessions", "IdSocialNetworkUser", "dbo.SocialNetworkUser");
            DropIndex("dbo.SocialNetworkSessions", new[] { "IdSocialNetworkUser" });
            DropTable("dbo.SocialNetworkSessions");
        }
    }
}
