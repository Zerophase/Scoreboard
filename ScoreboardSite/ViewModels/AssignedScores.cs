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
		public IEnumerable<Score> Scores { get; set; }
		public IEnumerable<Player> Players { get; set; } 
	}
}