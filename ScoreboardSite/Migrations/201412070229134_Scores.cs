using System.Data.Entity.Core.Common.CommandTrees;

namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Scores : DbMigration
    {
        public override void Up()
        {
	        CreateTable(
		        "dbo.Score",
		        c => new
		        {
			        ID = c.Int(nullable: false, identity: true)
		        }
		        ).PrimaryKey(t => t.ID);
			AddColumn("dbo.Score", "CompletionTime", c => c.Time());
			AddColumn("dbo.Score", "DeathCount", c => c.Int(nullable: true));
			AddColumn("dbo.Score", "MonstersSlayen", c => c.Int(nullable: true));
			AddColumn("dbo.Score", "OverallScore", c => c.Int(nullable: true));
			AddColumn("dbo.Score", "TotalAchievements", c => c.Int(nullable: true));
			AddColumn("dbo.Score", "Discriminator", c => c.String(nullable: false, maxLength: 128, defaultValue: "OverallScore"));
            
        }
        
        public override void Down()
        {
			DropTable("dbo.Score");
        }
    }
}
