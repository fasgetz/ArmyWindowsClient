namespace ArmyClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUserCrime5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCrimes", "WebAddressPost", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCrimes", "WebAddressPost");
        }
    }
}
