namespace MK_KupSkorer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "TotalRacePoints", c => c.Double(nullable: false));
            DropColumn("dbo.Player", "TotalPoints");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Player", "TotalPoints", c => c.Double(nullable: false));
            DropColumn("dbo.Player", "TotalRacePoints");
        }
    }
}
