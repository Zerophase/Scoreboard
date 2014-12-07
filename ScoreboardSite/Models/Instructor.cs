using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScoreboardSite.Models
{
	public class Instructor : Person
	{
		[DataType(DataType.Date), Display(Name = "Hire Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime HireDate { get; set; }

		public virtual ICollection<Course> Courses { get; set; }
		public virtual OfficeAssignment OfficeAssignment { get; set; }
	}
}