namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordAddedToPlayer : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Player", "Password", c => c.String(nullable: false, maxLength: 50, defaultValue: "Test"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "Password");
        }
    }
}
