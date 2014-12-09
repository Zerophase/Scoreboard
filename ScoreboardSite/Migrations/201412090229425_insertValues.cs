namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertValues : DbMigration
    {
        public override void Up()
        {
			Sql("INSERT INTO Player (Player.OverallScore_ID)" +
					" SELECT ID FROM Score AS s" +
					" INNER JOIN Player p on s.Player_PlayerID = p.PlayerID" +
					" WHERE s.Player_PlayerID = p.PlayerID");
        }
        
        public override void Down()
        {
        }
    }
}
