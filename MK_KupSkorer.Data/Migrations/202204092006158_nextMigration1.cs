namespace MK_KupSkorer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "TotalWins", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "TotalWins");
        }
    }
}
