namespace ArmyClient.Migrations.MSSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSessions2 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.SocialNetworkSessions", "SocialNetworkUser_Id", "dbo.SocialNetworkUser");
            //DropIndex("dbo.SocialNetworkSessions", new[] { "SocialNetworkUser_Id" });
            //DropTable("dbo.SocialNetworkSessions");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.SocialNetworkSessions",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            IdUserSocialNetwork = c.Int(nullable: false),
            //            DateStart = c.DateTime(nullable: false),
            //            DateEnd = c.DateTime(),
            //            SocialNetworkUser_Id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateIndex("dbo.SocialNetworkSessions", "SocialNetworkUser_Id");
            //AddForeignKey("dbo.SocialNetworkSessions", "SocialNetworkUser_Id", "dbo.SocialNetworkUser", "Id");
        }
    }
}
