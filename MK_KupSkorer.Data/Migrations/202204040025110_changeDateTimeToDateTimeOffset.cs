namespace MK_KupSkorer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDateTimeToDateTimeOffset : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kup", "KupDateTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Kup", "UpdatedDateTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Race", "RaceDateTime", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Race", "RaceDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Kup", "UpdatedDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Kup", "KupDateTime", c => c.DateTime(nullable: false));
        }
    }
}
