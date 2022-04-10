namespace MK_KupSkorer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Race", "WinnerId", "dbo.Player");
            DropIndex("dbo.Race", new[] { "WinnerId" });
            AlterColumn("dbo.Race", "WinnerId", c => c.Int());
            CreateIndex("dbo.Race", "WinnerId");
            AddForeignKey("dbo.Race", "WinnerId", "dbo.Player", "PlayerId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Race", "WinnerId", "dbo.Player");
            DropIndex("dbo.Race", new[] { "WinnerId" });
            AlterColumn("dbo.Race", "WinnerId", c => c.Int());
            CreateIndex("dbo.Race", "WinnerId");
            AddForeignKey("dbo.Race", "WinnerId", "dbo.Player", "PlayerId");
        }
    }
}
