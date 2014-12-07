namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompletionTimePopulated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Score", "CompletionTime", c => c.Time());
            AddColumn("dbo.Score", "Player_PlayerID", c => c.Int());
            CreateIndex("dbo.Score", "Player_PlayerID");
            AddForeignKey("dbo.Score", "Player_PlayerID", "dbo.Player", "PlayerID");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TotalAchievements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AchievementCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OverallScore",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MonstersSlayen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KillCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CompletionTIme",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompletionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Score", "Player_PlayerID", "dbo.Player");
            DropIndex("dbo.Score", new[] { "Player_PlayerID" });
            AlterColumn("dbo.Score", "DeathCount", c => c.Int(nullable: false));
            DropColumn("dbo.Score", "Player_PlayerID");
            DropColumn("dbo.Score", "Discriminator");
            DropColumn("dbo.Score", "CompletionTIme");
            RenameColumn(table: "dbo.Score", name: "TotalAchievements", newName: "AchievementCount");
            RenameColumn(table: "dbo.Score", name: "OverallScore", newName: "TotalScore");
            RenameColumn(table: "dbo.Score", name: "MonstersSlayen", newName: "KillCount");
            RenameColumn(table: "dbo.Score", name: "DeathCount", newName: "TotalDeaths");
            RenameTable(name: "dbo.Score", newName: "DeathCount");
        }
    }
}
