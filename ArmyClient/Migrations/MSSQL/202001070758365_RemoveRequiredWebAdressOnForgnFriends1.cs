namespace ArmyClient.Migrations.MSSQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredWebAdressOnForgnFriends1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ForeignFriends", "WebAddress", c => c.String(nullable: true, maxLength: 60));
        }

        public override void Down()
        {
            AlterColumn("dbo.ForeignFriends", "WebAddress", c => c.String(nullable: false, maxLength: 60));
        }
    }
}
