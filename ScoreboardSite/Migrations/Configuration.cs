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
				new Player {AccountName = "RedViking", Password = "JimboJones", Region = new Region()},
				new Player {AccountName = "Grimlocke", Password = "password", Region = new Region()},
				new Player {AccountName = "Yilnis", Password = "Miskatonic", Region = new Region()},
				new Player {AccountName = "Muler", Password = "JohnRambo", Region = new Region()},
				new Player {AccountName = "DeadStrike", Password = "MikeFontano", Region = new Region()},
				new Player {AccountName = "MasterBlaster", Password = "DanGilMore", Region = new Region()},
				new Player {AccountName = "BlueBlaster", Password = "liveMore", Region = new Region()},
				new Player {AccountName = "Xavier", Password = "Redday", Region = new Region()},
				new Player {AccountName = "FireBelow", Password = "Nopes", Region = new Region()},
				new Player {AccountName = "ManicMonk", Password = "haxor", Region = new Region()}
			};

			players.ForEach(p => context.Players.AddOrUpdate(A => A.AccountName, p));
			players.ForEach(p => context.Players.AddOrUpdate(A => A.Password, p));
			
			context.SaveChanges();

			var completionTimes = new List<CompletionTime>
			{
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(5), Player = players[0]
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(10), Player = players[1]
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(23), Player = players[2]
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(8), Player = players[3]
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(3), Player = players[4]
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(7), Player = players[5]
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(15), Player = players[6]
				
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(12), Player = players[7]
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(9), Player = players[8]
				},
				new CompletionTime
				{
					TotalTimeToCompletion = TimeSpan.FromHours(20), Player = players[9]
				}
			};

			completionTimes.ForEach(c => context.CompletionTimes.AddOrUpdate(a => a.TotalTimeToCompletion, c));
			context.SaveChanges();

			var deathCounts = new List<DeathCount>
			{
				new DeathCount
				{
					TotalDeaths = 10, Player = players[0]
				},
				new DeathCount
				{
					TotalDeaths = 1, Player = players[1]
				},
				new DeathCount
				{
					TotalDeaths = 3, Player = players[2]
				},
				new DeathCount
				{
					TotalDeaths = 5, Player = players[3]
				},
				new DeathCount
				{
					TotalDeaths = 4, Player = players[4]
				},
				new DeathCount
				{
					TotalDeaths = 20, Player = players[5]
				},
				new DeathCount
				{
					TotalDeaths = 0, Player = players[6]
				},
				new DeathCount
				{
					TotalDeaths = 11, Player = players[7]
				},
				new DeathCount
				{
					TotalDeaths = 6, Player = players[8]
				},
				new DeathCount
				{
					TotalDeaths = 30, Player = players[9]
				}
			};

			deathCounts.ForEach(c => context.DeathCounts.AddOrUpdate(a => a.TotalDeaths, c));
			context.SaveChanges();

			var totalAchievements = new List<TotalAchievements>
			{
				new TotalAchievements
				{
					AchievementCount = 50, Player = players[0]
				},
				new TotalAchievements
				{
					AchievementCount = 25, Player = players[1]
				},
				new TotalAchievements
				{
					AchievementCount = 1, Player = players[2]
				},
				new TotalAchievements
				{
					AchievementCount = 15, Player = players[3]
				},
				new TotalAchievements
				{
					AchievementCount = 20, Player = players[4]
				},
				new TotalAchievements
				{
					AchievementCount = 30, Player = players[5]
				},
				new TotalAchievements
				{
					AchievementCount = 10, Player = players[6]
				},
				new TotalAchievements
				{
					AchievementCount = 65, Player = players[7]
				},
				new TotalAchievements
				{
					AchievementCount = 13, Player = players[8]
				},
				new TotalAchievements
				{
					AchievementCount = 7, Player = players[9]
				}
			};

			totalAchievements.ForEach(c => context.TotalAchievements.AddOrUpdate(a => a.AchievementCount, c));
			context.SaveChanges();

			var overAllScores = new List<OverallScore>
			{
				new OverallScore
				{
					TotalScore = 75, Player = players[0]
				},
				new OverallScore
				{
					TotalScore = 30, Player = players[1]
				},
				new OverallScore
				{
					TotalScore = 15, Player = players[2]
				},
				new OverallScore
				{
					TotalScore = 10, Player = players[3]
				},
				new OverallScore
				{
					TotalScore = 12, Player = players[4]
				},
				new OverallScore
				{
					TotalScore = 45, Player = players[5]
				},
				new OverallScore
				{
					TotalScore = 19, Player = players[6]
				},
				new OverallScore
				{
					TotalScore = 50, Player = players[7]
				},
				new OverallScore
				{
					TotalScore = 2, Player = players[8]
				},
				new OverallScore
				{
					TotalScore = 1, Player = players[9]
				}
			};

			overAllScores.ForEach(c => context.OverallScores.AddOrUpdate(a => a.TotalScore, c));
			context.SaveChanges();

			var monstersSlayens = new List<MonstersSlayen>
			{
				new MonstersSlayen
				{
					KillCount = 1000, Player = players[0]
				},
				new MonstersSlayen
				{
					KillCount = 800, Player = players[1]
				},
				new MonstersSlayen
				{
					KillCount = 700, Player = players[2]
				},
				new MonstersSlayen
				{
					KillCount = 500, Player = players[3]
				},
				new MonstersSlayen
				{
					KillCount = 200, Player = players[4]
				},
				new MonstersSlayen
				{
					KillCount = 100, Player = players[5]
				},
				new MonstersSlayen
				{
					KillCount = 150, Player = players[6]
				},
				new MonstersSlayen
				{
					KillCount = 400, Player = players[7]
				},
				new MonstersSlayen
				{
					KillCount = 900, Player = players[8]
				},
				new MonstersSlayen
				{
					KillCount = 300, Player = players[9]
				}
			};

			monstersSlayens.ForEach(c => context.MonstersSlayens.AddOrUpdate(a => a.KillCount, c));
			context.SaveChanges();
        }
    }
}
