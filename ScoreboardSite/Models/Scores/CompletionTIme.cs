using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScoreboardSite.Models.Scores
{
	public class CompletionTime : Score
	{
		[Display(Name = "Completion Time")]
		[Column("CompletionTime")]
		public TimeSpan TotalTimeToCompletion { get; set; }
	}
}