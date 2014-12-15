using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScoreboardSite.Models
{
	public class Friends
	{
		[Key, ForeignKey("Players")]
		[Column(Order = 10)]
		public virtual int PlayerID { get; set; }
		[Key, ForeignKey("Players")]
		[Column(Order = 20)]
		public virtual int PlayerID2 { get; set; }

		public virtual ICollection<Player> Players { get; set; }
	}
}