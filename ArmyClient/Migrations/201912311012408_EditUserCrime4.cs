namespace ArmyClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUserCrime4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserCrimes", "WebAddressPost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserCrimes", "WebAddressPost", c => c.String());
        }
    }
}
