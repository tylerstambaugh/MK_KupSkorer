namespace MK_KupSkorer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsActiveOnPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "IsActive");
        }
    }
}
