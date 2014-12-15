namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FriendsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        PlayerID = c.Int(nullable: false),
                        PlayerID2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerID, t.PlayerID2 });
            
            CreateTable(
                "dbo.FriendsPlayer",
                c => new
                    {
                        Friends_PlayerID = c.Int(nullable: false),
                        Friends_PlayerID2 = c.Int(nullable: false),
                        Player_PlayerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Friends_PlayerID, t.Friends_PlayerID2, t.Player_PlayerID })
                .ForeignKey("dbo.Friends", t => new { t.Friends_PlayerID, t.Friends_PlayerID2 }, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.Player_PlayerID, cascadeDelete: true)
                .Index(t => new { t.Friends_PlayerID, t.Friends_PlayerID2 })
                .Index(t => t.Player_PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendsPlayer", "Player_PlayerID", "dbo.Player");
            DropForeignKey("dbo.FriendsPlayer", new[] { "Friends_PlayerID", "Friends_PlayerID2" }, "dbo.Friends");
            DropIndex("dbo.FriendsPlayer", new[] { "Player_PlayerID" });
            DropIndex("dbo.FriendsPlayer", new[] { "Friends_PlayerID", "Friends_PlayerID2" });
            DropTable("dbo.FriendsPlayer");
            DropTable("dbo.Friends");
        }
    }
}
