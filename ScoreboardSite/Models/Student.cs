using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScoreboardSite.Models
{
	public class Student : Person
	{
		// Can use this in place of the Required attribute.
		//[StringLength(50, MinimumLength = 1)]
		// Tells database which characters are accepted
		// Prevents an entry entirely made up of blank spaces
		//[RegularExpression(@"^[a-zA-Z''-']*$")]

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Enrollment Date")]
		public DateTime EnrollmentDate { get; set; }
		public string Email { get; set; }
		// How to keep properties hidden just don't include Secret in the include field on
		// the create method of the Controller
		public string Secret { get; set; }

		public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}