namespace ArmyClient.Migrations.MSSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditGroupsMembersCount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SocialNetworkGroups", "MembersCount", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SocialNetworkGroups", "MembersCount", c => c.Int(nullable: false));
        }
    }
}
