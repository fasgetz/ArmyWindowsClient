namespace ArmyClient.Migrations.MSSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditGroupsDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialNetworkGroups", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SocialNetworkGroups", "Description");
        }
    }
}
