namespace ArmyClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCrimes", "IsCrimee", c => c.Boolean(nullable: false, defaultValue: false));
            DropColumn("dbo.UserCrimes", "IsCrime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserCrimes", "IsCrime", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserCrimes", "IsCrimee");
        }
    }
}
