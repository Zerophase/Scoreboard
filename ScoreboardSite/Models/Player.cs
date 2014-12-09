﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ScoreboardSite.Models.Scores;

namespace ScoreboardSite.Models
{
	public class Player
	{
		public int PlayerID { get; set; }

		[RegularExpression(@"^[a-zA-Z''-']*$")]
		[StringLength(50, MinimumLength = 4), Display(Name = "Account Name")]
		public string AccountName { get; set; }

		public virtual ICollection<Score> Scores { get; set; }

		public virtual OverallScore OverallScore { get; set; }
		public virtual DeathCount DeathCount { get; set; }
		public virtual CompletionTime CompletionTime { get; set; }
		public virtual MonstersSlayen MonstersSlayen { get; set; }
		public virtual TotalAchievements TotalAchievements { get; set; }
	}
}