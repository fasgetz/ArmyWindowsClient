namespace ArmyClient.Migrations.MSSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredWebAdressOnForgnFriends2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserCrimes", "WebAddressPost", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserCrimes", "WebAddressPost", c => c.String(nullable: false));
        }
    }
}
