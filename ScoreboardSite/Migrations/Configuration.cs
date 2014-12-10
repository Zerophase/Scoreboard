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
					TotalTimeToCompletion = TimeSpan.FromHours(5)
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(10)
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(23)
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(8)
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(3)
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(7)
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(15)
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(12)
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(9)
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(20)
				}
			};

			completionTimes.ForEach(c => context.CompletionTimes.AddOrUpdate(a => a.TotalTimeToCompletion, c));
			context.SaveChanges();

			var deathCounts = new List<DeathCount>
			{
				new DeathCount
				{
					TotalDeaths = 10
				},
				new DeathCount
				{
					TotalDeaths = 1
				},
				new DeathCount
				{
					TotalDeaths = 3
				},
				new DeathCount
				{
					TotalDeaths = 5
				},
				new DeathCount
				{
					TotalDeaths = 4
				},
				new DeathCount
				{
					TotalDeaths = 20
				},
				new DeathCount
				{
					TotalDeaths = 0
				},
				new DeathCount
				{
					TotalDeaths = 11
				},
				new DeathCount
				{
					TotalDeaths = 6
				},
				new DeathCount
				{
					TotalDeaths = 30
				}
			};

			deathCounts.ForEach(c => context.DeathCounts.AddOrUpdate(a => a.TotalDeaths, c));
			context.SaveChanges();

			var totalAchievements = new List<TotalAchievements>
			{
				new TotalAchievements
				{
					AchievementCount = 50
				},
				new TotalAchievements
				{
					AchievementCount = 25
				},
				new TotalAchievements
				{
					AchievementCount = 1
				},
				new TotalAchievements
				{
					AchievementCount = 15
				},
				new TotalAchievements
				{
					AchievementCount = 20
				},
				new TotalAchievements
				{
					AchievementCount = 30
				},
				new TotalAchievements
				{
					AchievementCount = 10
				},
				new TotalAchievements
				{
					AchievementCount = 65
				},
				new TotalAchievements
				{
					AchievementCount = 13
				},
				new TotalAchievements
				{
					AchievementCount = 7
				}
			};

			totalAchievements.ForEach(c => context.TotalAchievements.AddOrUpdate(a => a.AchievementCount, c));
			context.SaveChanges();

			var overAllScores = new List<OverallScore>
			{
				new OverallScore
				{
					TotalScore = 75
				},
				new OverallScore
				{
					TotalScore = 30
				},
				new OverallScore
				{
					TotalScore = 15
				},
				new OverallScore
				{
					TotalScore = 10
				},
				new OverallScore
				{
					TotalScore = 12
				},
				new OverallScore
				{
					TotalScore = 45
				},
				new OverallScore
				{
					TotalScore = 19
				},
				new OverallScore
				{
					TotalScore = 50
				},
				new OverallScore
				{
					TotalScore = 2
				},
				new OverallScore
				{
					TotalScore = 1
				}
			};

			overAllScores.ForEach(c => context.OverallScores.AddOrUpdate(a => a.TotalScore, c));
			context.SaveChanges();

			var monstersSlayens = new List<MonstersSlayen>
			{
				new MonstersSlayen
				{
					KillCount = 1000
				},
				new MonstersSlayen
				{
					KillCount = 800
				},
				new MonstersSlayen
				{
					KillCount = 700
				},
				new MonstersSlayen
				{
					KillCount = 500
				},
				new MonstersSlayen
				{
					KillCount = 200
				},
				new MonstersSlayen
				{
					KillCount = 100
				},
				new MonstersSlayen
				{
					KillCount = 150
				},
				new MonstersSlayen
				{
					KillCount = 400
				},
				new MonstersSlayen
				{
					KillCount = 900
				},
				new MonstersSlayen
				{
					KillCount = 300
				}
			};

			monstersSlayens.ForEach(c => context.MonstersSlayens.AddOrUpdate(a => a.KillCount, c));
			context.SaveChanges();
        }
    }
}
