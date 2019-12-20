namespace ArmyClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCrimes", "IsCrime", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserCrimes", "IsCrimee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserCrimes", "IsCrimee", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserCrimes", "IsCrime");
        }
    }
}
