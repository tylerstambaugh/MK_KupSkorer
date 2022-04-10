namespace MK_KupSkorer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class again : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Player", "TotalPoints", c => c.Double());
            AlterColumn("dbo.Player", "TotalBonusPoints", c => c.Int());
            AlterColumn("dbo.Player", "TotalWins", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Player", "TotalWins", c => c.Int(nullable: false));
            AlterColumn("dbo.Player", "TotalBonusPoints", c => c.Int(nullable: false));
            AlterColumn("dbo.Player", "TotalPoints", c => c.Double(nullable: false));
        }
    }
}
