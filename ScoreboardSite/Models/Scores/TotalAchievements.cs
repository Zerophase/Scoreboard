using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScoreboardSite.Models.Scores
{
	public class TotalAchievements : Score
	{
		[Column("TotalAchievements"), Display(Name = "Total Achievements")]
		public int AchievementCount { get; set; }
	}
}