namespace MK_KupSkorer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kup", "RaceCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kup", "RaceCount");
        }
    }
}
