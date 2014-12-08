namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyScores : DbMigration
    {
        public override void Up()
        {
			//DropForeignKey("dbo.Score", "Player_PlayerID", "dbo.Player");
			//DropIndex("dbo.Score", new[] { "Player_PlayerID" });
			//AlterColumn("dbo.Score", "Player_PlayerID", c => c.Int(nullable: false));
			//CreateIndex("dbo.Score", "Player_PlayerID");
			//AddForeignKey("dbo.Score", "Player_PlayerID", "dbo.Player", "PlayerID", cascadeDelete: true);
			Sql("UPDATE dbo.Score SET Player_PlayerID = (SELECT PlayerID FROM dbo.Player WHERE Player.PlayerID = Player.PlayerID % 10)");
		}
        
        public override void Down()
        {
            DropForeignKey("dbo.Score", "Player_PlayerID", "dbo.Player");
            DropIndex("dbo.Score", new[] { "Player_PlayerID" });
            AlterColumn("dbo.Score", "Player_PlayerID", c => c.Int());
            CreateIndex("dbo.Score", "Player_PlayerID");
            AddForeignKey("dbo.Score", "Player_PlayerID", "dbo.Player", "PlayerID");
        }
    }
}
