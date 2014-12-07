namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScoreFixTwo : DbMigration
    {
        public override void Up()
        {
			//RenameColumn(table: "dbo.Score", name: "TotalDeaths", newName: "DeathCount");
        }
        
        public override void Down()
        {
        }
    }
}
