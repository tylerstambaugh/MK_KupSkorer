namespace MK_KupSkorer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kup",
                c => new
                    {
                        KupId = c.Int(nullable: false, identity: true),
                        RaceCount = c.Int(nullable: false),
                        KupDateTime = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedDateTime = c.DateTimeOffset(nullable: false, precision: 7),
                        Player1Id = c.Int(nullable: false),
                        Player2Id = c.Int(nullable: false),
                        Player3Id = c.Int(),
                        Player4Id = c.Int(),
                    })
                .PrimaryKey(t => t.KupId)
                .ForeignKey("dbo.Player", t => t.Player1Id, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.Player2Id, cascadeDelete: false)
                .ForeignKey("dbo.Player", t => t.Player3Id)
                .ForeignKey("dbo.Player", t => t.Player4Id)
                .Index(t => t.Player1Id)
                .Index(t => t.Player2Id)
                .Index(t => t.Player3Id)
                .Index(t => t.Player4Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Nickname = c.String(maxLength: 20),
                        TotalRacePoints = c.Double(nullable: false),
                        TotalBonusPoints = c.Int(nullable: false),
                        TotalWins = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Race",
                c => new
                    {
                        RaceId = c.Int(nullable: false, identity: true),
                        RaceDateTime = c.DateTimeOffset(precision: 7),
                        KupId = c.Int(nullable: false),
                        WinnerId = c.Int(),
                    })
                .PrimaryKey(t => t.RaceId)
                .ForeignKey("dbo.Kup", t => t.KupId, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.WinnerId)
                .Index(t => t.KupId)
                .Index(t => t.WinnerId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Race", "WinnerId", "dbo.Player");
            DropForeignKey("dbo.Race", "KupId", "dbo.Kup");
            DropForeignKey("dbo.Kup", "Player4Id", "dbo.Player");
            DropForeignKey("dbo.Kup", "Player3Id", "dbo.Player");
            DropForeignKey("dbo.Kup", "Player2Id", "dbo.Player");
            DropForeignKey("dbo.Kup", "Player1Id", "dbo.Player");
            DropForeignKey("dbo.Player", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Race", new[] { "WinnerId" });
            DropIndex("dbo.Race", new[] { "KupId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Player", new[] { "UserId" });
            DropIndex("dbo.Kup", new[] { "Player4Id" });
            DropIndex("dbo.Kup", new[] { "Player3Id" });
            DropIndex("dbo.Kup", new[] { "Player2Id" });
            DropIndex("dbo.Kup", new[] { "Player1Id" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Race");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Player");
            DropTable("dbo.Kup");
        }
    }
}
