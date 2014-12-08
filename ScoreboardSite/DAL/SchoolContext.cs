using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ScoreboardSite.Models;
using ScoreboardSite.Models.Scores;

namespace ScoreboardSite.DAL
{
	public class SchoolContext : DbContext
	{
		public SchoolContext() :
			base("SchoolContext")
		{
			
		}

		public DbSet<Player> Players { get; set; }
		public DbSet<Score> Scores { get; set; } 
		public DbSet<TotalAchievements> TotalAchievements { get; set; }
		public DbSet<CompletionTime> CompletionTimes { get; set; }
		public DbSet<DeathCount> DeathCounts { get; set; }
		public DbSet<MonstersSlayen> MonstersSlayens { get; set; }
		public DbSet<OverallScore> OverallScores { get; set; }

		public DbSet<Person> People { get; set; } 
		public DbSet<Student> Students { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<OfficeAssignment> OfficeAssignments { get; set; } 

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			// How to specify relationship between below classes using fluent API
			// modelBuilder.Entity<Instructor>()
			// .HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor);

			modelBuilder.Entity<Player>()
				.HasMany(s => s.Scores)
				.WithRequired(p => p.Player);

			modelBuilder.Entity<Course>()
				.HasMany(c => c.Instructors)
				.WithMany(i => i.Courses)
				.Map(t => t.MapLeftKey("CourseID").MapRightKey("InstructorID").ToTable("CourseInstructor"));
			modelBuilder.Entity<Department>().MapToStoredProcedures();
		}
	}
}