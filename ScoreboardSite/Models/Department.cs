using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScoreboardSite.Models
{
	public class Department
	{
		public int DepartmentID { get; set; }

		[StringLength(50, MinimumLength = 3)]
		public string Name { get; set; }

		[DataType(DataType.Currency), Column(TypeName =  "money")]
		public decimal Budget { get; set; }
 
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }

		// Use this to disable cascade delete on non-nullable foreign keys, if business rules require it.
		// Not sure where to put.
		// modelBuilder.Entity().HasRequired(d => d.Administrator).WithMany().WillCascadeOnDelete(false);
		public int? InstructorID { get; set; }

		public virtual Instructor Administrator { get; set; }
		public virtual ICollection<Course> Courses { get; set; } 
	}
}