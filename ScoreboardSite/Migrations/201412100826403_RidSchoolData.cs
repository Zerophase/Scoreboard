namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RidSchoolData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OfficeAssignment", "InstructorID", "dbo.Person");
            DropForeignKey("dbo.Department", "InstructorID", "dbo.Person");
            DropForeignKey("dbo.Course", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Person");
            DropForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseInstructor", "InstructorID", "dbo.Person");
            DropIndex("dbo.Course", new[] { "DepartmentID" });
            DropIndex("dbo.Department", new[] { "InstructorID" });
            DropIndex("dbo.OfficeAssignment", new[] { "InstructorID" });
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropIndex("dbo.Enrollment", new[] { "StudentID" });
            DropIndex("dbo.CourseInstructor", new[] { "CourseID" });
            DropIndex("dbo.CourseInstructor", new[] { "InstructorID" });
            DropTable("dbo.Course");
            DropTable("dbo.Department");
            
            DropTable("dbo.OfficeAssignment");
            DropTable("dbo.Enrollment");
            DropTable("dbo.CourseInstructor");
            DropStoredProcedure("dbo.Department_Insert");
            DropStoredProcedure("dbo.Department_Update");
            DropStoredProcedure("dbo.Department_Delete");
			DropTable("dbo.Person");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseInstructor",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.InstructorID });
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID);
            
            CreateTable(
                "dbo.OfficeAssignment",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(),
                        EnrollmentDate = c.DateTime(),
                        Email = c.String(),
                        Secret = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        InstructorID = c.Int(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Credits = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateIndex("dbo.CourseInstructor", "InstructorID");
            CreateIndex("dbo.CourseInstructor", "CourseID");
            CreateIndex("dbo.Enrollment", "StudentID");
            CreateIndex("dbo.Enrollment", "CourseID");
            CreateIndex("dbo.OfficeAssignment", "InstructorID");
            CreateIndex("dbo.Department", "InstructorID");
            CreateIndex("dbo.Course", "DepartmentID");
            AddForeignKey("dbo.CourseInstructor", "InstructorID", "dbo.Person", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Enrollment", "StudentID", "dbo.Person", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Enrollment", "CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Course", "DepartmentID", "dbo.Department", "DepartmentID", cascadeDelete: true);
            AddForeignKey("dbo.Department", "InstructorID", "dbo.Person", "ID");
            AddForeignKey("dbo.OfficeAssignment", "InstructorID", "dbo.Person", "ID");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
