using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScoreboardSite.Models.Scores
{
	public class DeathCount : Score
	{
		[Display(Name = "Death Count")]
		[Column("DeathCount")]
		public int TotalDeaths { get; set; }
	}
}