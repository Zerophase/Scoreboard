namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscriminatorAttempt : DbMigration
    {
        public override void Up()
        {
			//DropColumn("dbo.Score", "Discriminator");
			//RenameColumn(table: "dbo.Score", name: "Discriminator1", newName: "Discriminator");
			//AlterColumn("dbo.Score", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Score", "Discriminator", c => c.String());
            RenameColumn(table: "dbo.Score", name: "Discriminator", newName: "Discriminator1");
            AddColumn("dbo.Score", "Discriminator", c => c.String());
        }
    }
}
