namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUnitsToScore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Score", "Units", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Score", "Units");
        }
    }
}
