using System.Web.Management;

namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegionSelection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionID = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
                    })
                .PrimaryKey(t => t.RegionID);
            
			Sql("INSERT INTO dbo.Region (RegionName) VALUES ('East US'), ('West US'), ('Central US')");

            AddColumn("dbo.Player", "Region_RegionID", c => c.Int(nullable: false));

			Sql("MERGE INTO dbo.Player AS p USING dbo.Region AS r " +
				"ON p.PlayerID = 1 AND p.Region_RegionID IS NULL " +
				"WHEN MATCHED THEN UPDATE SET p.Region_RegionID = 1; ");

			Sql("MERGE INTO dbo.Player AS p USING dbo.Region AS r " +
				"ON p.PlayerID = 3 AND p.Region_RegionID IS NULL " +
				"WHEN MATCHED THEN UPDATE SET p.Region_RegionID = 1; ");

			Sql("MERGE INTO dbo.Player AS p USING dbo.Region AS r " +
				"ON p.PlayerID = 5 AND p.Region_RegionID IS NULL " +
				"WHEN MATCHED THEN UPDATE SET p.Region_RegionID = 1; ");

			Sql("MERGE INTO dbo.Player AS p USING dbo.Region AS r " +
				"ON p.PlayerID = 2 AND p.Region_RegionID IS NULL " +
				"WHEN MATCHED THEN UPDATE SET p.Region_RegionID = 2; ");

			Sql("MERGE INTO dbo.Player AS p USING dbo.Region AS r " +
				"ON p.PlayerID = 6 AND p.Region_RegionID IS NULL " +
				"WHEN MATCHED THEN UPDATE SET p.Region_RegionID = 2; ");

			Sql("MERGE INTO dbo.Player AS p USING dbo.Region AS r " +
				"ON p.PlayerID = 9 AND p.Region_RegionID IS NULL " +
				"WHEN MATCHED THEN UPDATE SET p.Region_RegionID = 2; ");

			Sql("MERGE INTO dbo.Player AS p USING dbo.Region AS r " +
				"ON p.PlayerID = 4 AND p.Region_RegionID IS NULL " +
				"WHEN MATCHED THEN UPDATE SET p.Region_RegionID = 3; ");

			Sql("MERGE INTO dbo.Player AS p USING dbo.Region AS r " +
				"ON p.PlayerID = 7 AND p.Region_RegionID IS NULL " +
				"WHEN MATCHED THEN UPDATE SET p.Region_RegionID = 3; ");

			Sql("MERGE INTO dbo.Player AS p USING dbo.Region AS r " +
				"ON p.PlayerID = 8 AND p.Region_RegionID IS NULL " +
				"WHEN MATCHED THEN UPDATE SET p.Region_RegionID = 3; ");

			Sql("MERGE INTO dbo.Player AS p USING dbo.Region AS r " +
				"ON p.PlayerID = 10 AND p.Region_RegionID IS NULL " +
				"WHEN MATCHED THEN UPDATE SET p.Region_RegionID = 3; ");

            CreateIndex("dbo.Player", "Region_RegionID");
            //AddForeignKey("dbo.Player", "Region_RegionID", "dbo.Region", "RegionID", cascadeDelete: true);
			
		}
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "Region_RegionID", "dbo.Region");
            DropIndex("dbo.Player", new[] { "Region_RegionID" });
            DropColumn("dbo.Player", "Region_RegionID");
            DropTable("dbo.Region");
        }
    }
}
