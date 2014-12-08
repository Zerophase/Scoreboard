namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryAgainToGetEverythingIN : DbMigration
    {
        public override void Up()
        {
			Sql("UPDATE dbo.Score SET Player_PlayerID = (SELECT PlayerID FROM dbo.Player WHERE Player.PlayerID = dbo.Score.ID % 10 )");
        }
        
        public override void Down()
        {
        }
    }
}
