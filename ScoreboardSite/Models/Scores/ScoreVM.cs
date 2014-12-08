using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScoreboardSite.Models.Scores
{
	[NotMapped]
	public class ScoreVM : Score
	{
		public string Discriminator { get; set; }
	}
}