using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreboardSite.Models;
using ScoreboardSite.Models.Scores;

namespace ScoreboardSite.ViewModels
{
	public class AssignedScores
	{
		public string AccountName { get; set; }
		public int? OverallScore { get; set; }
		public TimeSpan? CompletionTime { get; set; }
		public int? DeathCount { get; set; }
		public int? MonstersSlayen { get; set; }
		public int? TotalAchievements { get; set; }
	}
}