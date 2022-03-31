namespace MK_KupSkorer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kup", "Player3Id", "dbo.Player");
            DropForeignKey("dbo.Kup", "Player4Id", "dbo.Player");
            DropIndex("dbo.Kup", new[] { "Player3Id" });
            DropIndex("dbo.Kup", new[] { "Player4Id" });
            AddColumn("dbo.Kup", "KupDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Kup", "UpdatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Race", "WinnerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Kup", "Player3Id", c => c.Int());
            AlterColumn("dbo.Kup", "Player4Id", c => c.Int());
            CreateIndex("dbo.Kup", "Player3Id");
            CreateIndex("dbo.Kup", "Player4Id");
            CreateIndex("dbo.Race", "WinnerId");
            AddForeignKey("dbo.Race", "WinnerId", "dbo.Player", "PlayerId", cascadeDelete: false);
            AddForeignKey("dbo.Kup", "Player3Id", "dbo.Player", "PlayerId");
            AddForeignKey("dbo.Kup", "Player4Id", "dbo.Player", "PlayerId");
            DropColumn("dbo.Kup", "KupDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kup", "KupDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Kup", "Player4Id", "dbo.Player");
            DropForeignKey("dbo.Kup", "Player3Id", "dbo.Player");
            DropForeignKey("dbo.Race", "WinnerId", "dbo.Player");
            DropIndex("dbo.Race", new[] { "WinnerId" });
            DropIndex("dbo.Kup", new[] { "Player4Id" });
            DropIndex("dbo.Kup", new[] { "Player3Id" });
            AlterColumn("dbo.Kup", "Player4Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Kup", "Player3Id", c => c.Int(nullable: false));
            DropColumn("dbo.Race", "WinnerId");
            DropColumn("dbo.Kup", "UpdatedDateTime");
            DropColumn("dbo.Kup", "KupDateTime");
            CreateIndex("dbo.Kup", "Player4Id");
            CreateIndex("dbo.Kup", "Player3Id");
            AddForeignKey("dbo.Kup", "Player4Id", "dbo.Player", "PlayerId", cascadeDelete: true);
            AddForeignKey("dbo.Kup", "Player3Id", "dbo.Player", "PlayerId", cascadeDelete: true);
        }
    }
}
