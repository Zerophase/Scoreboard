namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllDerivedScoresToPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "CompletionTime_ID", c => c.Int());
            AddColumn("dbo.Player", "DeathCount_ID", c => c.Int());
            AddColumn("dbo.Player", "MonstersSlayen_ID", c => c.Int());
            AddColumn("dbo.Player", "TotalAchievements_ID", c => c.Int());
            CreateIndex("dbo.Player", "CompletionTime_ID");
            CreateIndex("dbo.Player", "DeathCount_ID");
            CreateIndex("dbo.Player", "MonstersSlayen_ID");
            CreateIndex("dbo.Player", "TotalAchievements_ID");
            AddForeignKey("dbo.Player", "CompletionTime_ID", "dbo.Score", "ID");
            AddForeignKey("dbo.Player", "DeathCount_ID", "dbo.Score", "ID");
            AddForeignKey("dbo.Player", "MonstersSlayen_ID", "dbo.Score", "ID");
            AddForeignKey("dbo.Player", "TotalAchievements_ID", "dbo.Score", "ID");

			// CompletionTime merge
			Sql("MERGE" +
				" INTO Player AS p" +
				" USING Score AS s" +
				" ON p.PlayerID = s.Player_PlayerID" +
				" AND s.CompletionTime IS NOT NULL" +
				" WHEN MATCHED" +
				" THEN UPDATE" +
				" SET p.CompletionTime_ID = s.ID;");
			// DeathCount merge
			Sql("MERGE" +
				" INTO Player AS p" +
				" USING Score AS s" +
				" ON p.PlayerID = s.Player_PlayerID" +
				" AND s.DeathCount IS NOT NULL" +
				" WHEN MATCHED" +
				" THEN UPDATE" +
				" SET p.DeathCount_ID = s.ID;");
			// MonstersSlayen merge
			Sql("MERGE" +
				" INTO Player AS p" +
				" USING Score AS s" +
				" ON p.PlayerID = s.Player_PlayerID" +
				" AND s.MonstersSlayen IS NOT NULL" +
				" WHEN MATCHED" +
				" THEN UPDATE" +
				" SET p.MonstersSlayen_ID = s.ID;");
			// TotalAchievements merge
			Sql("MERGE" +
				" INTO Player AS p" +
				" USING Score AS s" +
				" ON p.PlayerID = s.Player_PlayerID" +
				" AND s.TotalAchievements IS NOT NULL" +
				" WHEN MATCHED" +
				" THEN UPDATE" +
				" SET p.TotalAchievements_ID = s.ID;");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "TotalAchievements_ID", "dbo.Score");
            DropForeignKey("dbo.Player", "MonstersSlayen_ID", "dbo.Score");
            DropForeignKey("dbo.Player", "DeathCount_ID", "dbo.Score");
            DropForeignKey("dbo.Player", "CompletionTime_ID", "dbo.Score");
            DropIndex("dbo.Player", new[] { "TotalAchievements_ID" });
            DropIndex("dbo.Player", new[] { "MonstersSlayen_ID" });
            DropIndex("dbo.Player", new[] { "DeathCount_ID" });
            DropIndex("dbo.Player", new[] { "CompletionTime_ID" });
            DropColumn("dbo.Player", "TotalAchievements_ID");
            DropColumn("dbo.Player", "MonstersSlayen_ID");
            DropColumn("dbo.Player", "DeathCount_ID");
            DropColumn("dbo.Player", "CompletionTime_ID");
        }
    }
}
