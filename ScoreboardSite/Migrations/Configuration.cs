using System.Collections.Generic;
using System.Data.SqlClient;
using ScoreboardSite.DAL;
using ScoreboardSite.Models;
using ScoreboardSite.Models.Scores;

namespace ScoreboardSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ScoreboardSite.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ScoreboardSite.DAL.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            var students = new List<Student>
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander", 
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",    
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",     
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas", 
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan",      LastName = "Li",        
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",   
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura",    LastName = "Norman",    
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",  
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };


            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

			var players = new List<Player>
			{
				new Player {AccountName = "RedViking" },
				new Player {AccountName = "Grimlocke"},
				new Player {AccountName = "Yilnis"},
				new Player {AccountName = "Muler"},
				new Player {AccountName = "DeadStrike"},
				new Player {AccountName = "MasterBlaster"},
				new Player {AccountName = "BlueBlaster"},
				new Player {AccountName = "Xavier"},
				new Player {AccountName = "FireBelow"},
				new Player {AccountName = "ManicMonk"}
			};

			players.ForEach(p => context.Players.AddOrUpdate(A => A.AccountName, p));
			context.SaveChanges();

			var completionTimes = new List<CompletionTime>
			{
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(5),
					//PlayerID = players.Find(i => i.AccountName == "RedViking").PlayerID
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(10),
					//PlayerID = players.Find(i => i.AccountName == "Grimlocke").PlayerID
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(23),
					//PlayerID = players.Find(i => i.AccountName == "Yilnis").PlayerID
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(8),
					//PlayerID = players.Find(i => i.AccountName == "Muler").PlayerID
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(3),
					//PlayerID = players.Find(i => i.AccountName == "DeadStrike").PlayerID
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(7),
					//PlayerID = players.Find(i => i.AccountName == "MasterBlaster").PlayerID
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(15),
					//PlayerID = players.Find(i => i.AccountName == "BlueBlaster").PlayerID
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(12),
					//PlayerID = players.Find(i => i.AccountName == "Xavier").PlayerID
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(9),
					//PlayerID = players.Find(i => i.AccountName == "FireBelow").PlayerID
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(20),
					//PlayerID = players.Find(i => i.AccountName == "ManicMonk").PlayerID
				}
			};

			completionTimes.ForEach(c => context.CompletionTimes.AddOrUpdate(a => a.TotalTimeToCompletion, c));
			context.SaveChanges();

			var deathCounts = new List<DeathCount>
			{
				new DeathCount
				{
					TotalDeaths = 10,
					//PlayerID = players.Find(i => i.AccountName == "RedViking").PlayerID
				},
				new DeathCount
				{
					TotalDeaths = 1,
					//PlayerID = players.Find(i => i.AccountName == "Grimlocke").PlayerID
				},
				new DeathCount
				{
					TotalDeaths = 3,
					//PlayerID = players.Find(i => i.AccountName == "Yilnis").PlayerID
				},
				new DeathCount
				{
					TotalDeaths = 5,
					//PlayerID = players.Find(i => i.AccountName == "Muler").PlayerID
				},
				new DeathCount
				{
					TotalDeaths = 4,
					//PlayerID = players.Find(i => i.AccountName == "DeadStrike").PlayerID
				},
				new DeathCount
				{
					TotalDeaths = 20,
					//PlayerID = players.Find(i => i.AccountName == "MasterBlaster").PlayerID
				},
				new DeathCount
				{
					TotalDeaths = 0,
					//PlayerID = players.Find(i => i.AccountName == "BlueBlaster").PlayerID
				},
				new DeathCount
				{
					TotalDeaths = 11,
					//PlayerID = players.Find(i => i.AccountName == "Xavier").PlayerID
				},
				new DeathCount
				{
					TotalDeaths = 6,
					//PlayerID = players.Find(i => i.AccountName == "FireBelow").PlayerID
				},
				new DeathCount
				{
					TotalDeaths = 30,
					//PlayerID = players.Find(i => i.AccountName == "ManicMonk").PlayerID
				}
			};

			deathCounts.ForEach(c => context.DeathCounts.AddOrUpdate(a => a.TotalDeaths, c));
			context.SaveChanges();

			var totalAchievements = new List<TotalAchievements>
			{
				new TotalAchievements
				{
					AchievementCount = 50,
					//PlayerID = players.Find(i => i.AccountName == "RedViking").PlayerID
				},
				new TotalAchievements
				{
					AchievementCount = 25,
					//PlayerID = players.Find(i => i.AccountName == "Grimlocke").PlayerID
				},
				new TotalAchievements
				{
					AchievementCount = 1,
					//PlayerID = players.Find(i => i.AccountName == "Yilnis").PlayerID
				},
				new TotalAchievements
				{
					AchievementCount = 15,
					//PlayerID = players.Find(i => i.AccountName == "Muler").PlayerID
				},
				new TotalAchievements
				{
					AchievementCount = 20,
					//PlayerID = players.Find(i => i.AccountName == "DeadStrike").PlayerID
				},
				new TotalAchievements
				{
					AchievementCount = 30,
					//PlayerID = players.Find(i => i.AccountName == "MasterBlaster").PlayerID
				},
				new TotalAchievements
				{
					AchievementCount = 10,
					//PlayerID = players.Find(i => i.AccountName == "BlueBlaster").PlayerID
				},
				new TotalAchievements
				{
					AchievementCount = 65,
					//PlayerID = players.Find(i => i.AccountName == "Xavier").PlayerID
				},
				new TotalAchievements
				{
					AchievementCount = 13,
					//PlayerID = players.Find(i => i.AccountName == "FireBelow").PlayerID
				},
				new TotalAchievements
				{
					AchievementCount = 7,
					//PlayerID = players.Find(i => i.AccountName == "ManicMonk").PlayerID
				}
			};

			totalAchievements.ForEach(c => context.TotalAchievements.AddOrUpdate(a => a.AchievementCount, c));
			context.SaveChanges();

			var overAllScores = new List<OverallScore>
			{
				new OverallScore
				{
					TotalScore = 75,
					//PlayerID = players.Find(i => i.AccountName == "RedViking").PlayerID
				},
				new OverallScore
				{
					TotalScore = 30,
					//PlayerID = players.Find(i => i.AccountName == "Grimlocke").PlayerID
				},
				new OverallScore
				{
					TotalScore = 15,
					//PlayerID = players.Find(i => i.AccountName == "Yilnis").PlayerID
				},
				new OverallScore
				{
					TotalScore = 10,
					//PlayerID = players.Find(i => i.AccountName == "Muler").PlayerID
				},
				new OverallScore
				{
					TotalScore = 12,
					//PlayerID = players.Find(i => i.AccountName == "DeadStrike").PlayerID
				},
				new OverallScore
				{
					TotalScore = 45,
					//PlayerID = players.Find(i => i.AccountName == "MasterBlaster").PlayerID
				},
				new OverallScore
				{
					TotalScore = 19,
					//PlayerID = players.Find(i => i.AccountName == "BlueBlaster").PlayerID
				},
				new OverallScore
				{
					TotalScore = 50,
					//PlayerID = players.Find(i => i.AccountName == "Xavier").PlayerID
				},
				new OverallScore
				{
					TotalScore = 2,
					//PlayerID = players.Find(i => i.AccountName == "FireBelow").PlayerID
				},
				new OverallScore
				{
					TotalScore = 1,
					//PlayerID = players.Find(i => i.AccountName == "ManicMonk").PlayerID
				}
			};

			overAllScores.ForEach(c => context.OverallScores.AddOrUpdate(a => a.TotalScore, c));
			context.SaveChanges();

			var monstersSlayens = new List<MonstersSlayen>
			{
				new MonstersSlayen
				{
					KillCount = 1000,
					//PlayerID = players.Find(i => i.AccountName == "RedViking").PlayerID
				},
				new MonstersSlayen
				{
					KillCount = 800,
					//PlayerID = players.Find(i => i.AccountName == "Grimlocke").PlayerID
				},
				new MonstersSlayen
				{
					KillCount = 700,
					//PlayerID = players.Find(i => i.AccountName == "Yilnis").PlayerID
				},
				new MonstersSlayen
				{
					KillCount = 500,
					//PlayerID = players.Find(i => i.AccountName == "Muler").PlayerID
				},
				new MonstersSlayen
				{
					KillCount = 200,
					//PlayerID = players.Find(i => i.AccountName == "DeadStrike").PlayerID
				},
				new MonstersSlayen
				{
					KillCount = 100,
					//PlayerID = players.Find(i => i.AccountName == "MasterBlaster").PlayerID
				},
				new MonstersSlayen
				{
					KillCount = 150,
					//PlayerID = players.Find(i => i.AccountName == "BlueBlaster").PlayerID
				},
				new MonstersSlayen
				{
					KillCount = 400,
					//PlayerID = players.Find(i => i.AccountName == "Xavier").PlayerID
				},
				new MonstersSlayen
				{
					KillCount = 900,
					//PlayerID = players.Find(i => i.AccountName == "FireBelow").PlayerID
				},
				new MonstersSlayen
				{
					KillCount = 300,
					//PlayerID = players.Find(i => i.AccountName == "ManicMonk").PlayerID
				}
			};

			monstersSlayens.ForEach(c => context.MonstersSlayens.AddOrUpdate(a => a.KillCount, c));
			context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie", 
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",    
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Roger",   LastName = "Harui",       
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Candace", LastName = "Kapoor",      
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Roger",   LastName = "Zheng",      
                    HireDate = DateTime.Parse("2004-02-12") }
            };
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "English",     Budget = 350000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID, 
                    Location = "Smith 17" },
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "Harui").ID, 
                    Location = "Gowan 27" },
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID, 
                    Location = "Thompson 304" },
            };
            officeAssignments.ForEach(s => context.OfficeAssignments.AddOrUpdate(p => p.InstructorID, s));
            context.SaveChanges();

            AddOrUpdateInstructor(context, "Chemistry", "Kapoor");
            AddOrUpdateInstructor(context, "Chemistry", "Harui");
            AddOrUpdateInstructor(context, "Microeconomics", "Zheng");
            AddOrUpdateInstructor(context, "Macroeconomics", "Zheng");

            AddOrUpdateInstructor(context, "Calculus", "Fakhouri");
            AddOrUpdateInstructor(context, "Trigonometry", "Harui");
            AddOrUpdateInstructor(context, "Composition", "Abercrombie");
            AddOrUpdateInstructor(context, "Literature", "Abercrombie");

            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").ID, 
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID, 
                    Grade = Grade.A 
                },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID, 
                    Grade = Grade.C 
                 },                            
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID, 
                    Grade = Grade.B
                 },
                 new Enrollment { 
                     StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                     StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B         
                 },
                new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Li").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Justice").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B         
                 }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Student.ID == e.StudentID &&
                         s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }

        void AddOrUpdateInstructor(SchoolContext context, string courseTitle, string instructorName)
        {
            var crs = context.Courses.SingleOrDefault(c => c.Title == courseTitle);
            var inst = crs.Instructors.SingleOrDefault(i => i.LastName == instructorName);
            if (inst == null)
                crs.Instructors.Add(context.Instructors.Single(i => i.LastName == instructorName));
        }
        
    }
}
