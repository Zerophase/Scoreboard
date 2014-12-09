namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOverallScoreToPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "OverallScore_ID", c => c.Int());
            CreateIndex("dbo.Player", "OverallScore_ID");
            AddForeignKey("dbo.Player", "OverallScore_ID", "dbo.Score", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "OverallScore_ID", "dbo.Score");
            DropIndex("dbo.Player", new[] { "OverallScore_ID" });
            DropColumn("dbo.Player", "OverallScore_ID");
        }
    }
}
