namespace MK_KupSkorer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Race", "WinnerId", "dbo.Player");
            DropIndex("dbo.Race", new[] { "WinnerId" });
            AlterColumn("dbo.Race", "WinnerId", c => c.Int());
            CreateIndex("dbo.Race", "WinnerId");
            AddForeignKey("dbo.Race", "WinnerId", "dbo.Player", "PlayerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Race", "WinnerId", "dbo.Player");
            DropIndex("dbo.Race", new[] { "WinnerId" });
            AlterColumn("dbo.Race", "WinnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Race", "WinnerId");
            AddForeignKey("dbo.Race", "WinnerId", "dbo.Player", "PlayerId", cascadeDelete: true);
        }
    }
}
