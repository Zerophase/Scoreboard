using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScoreboardSite.Models.Scores
{
	public class Score
	{
		public int ID { get; set; }

		public virtual Player Player { get; set; }
	}
}