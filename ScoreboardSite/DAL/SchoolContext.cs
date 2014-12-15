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

		public DbSet<Region> Regions { get; set; }
		public DbSet<Friends> Friends { get; set; } 

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();



			modelBuilder.Entity<Player>()
				.HasMany(s => s.Scores)
				.WithRequired(p => p.Player);

		}
	}
}