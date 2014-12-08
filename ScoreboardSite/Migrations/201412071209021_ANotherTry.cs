namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ANotherTry : DbMigration
    {
        public override void Up()
        {
			Sql("UPDATE dbo.Score SET Player_PlayerID = (SELECT PlayerID FROM dbo.Player WHERE Player.PlayerID = dbo.Score.ID % 10 OR (Player.PlayerID = 10 AND dbo.Score.ID % 10 = 0))");
        }
        
        public override void Down()
        {
        }
    }
}
