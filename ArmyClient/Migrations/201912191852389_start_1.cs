namespace ArmyClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCrimes", "DateEnty", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserCrimes", "IsCrime", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCrimes", "IsCrime");
            DropColumn("dbo.UserCrimes", "DateEnty");
        }
    }
}
