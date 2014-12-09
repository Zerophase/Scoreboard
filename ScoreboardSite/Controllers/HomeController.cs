using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreboardSite.DAL;
using ScoreboardSite.ViewModels;

namespace ScoreboardSite.Controllers
{
	public class HomeController : Controller
	{
		private SchoolContext db = new SchoolContext();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			// Show student statistics with LINQ
			//IQueryable<EnrollmentDateGroup> data = from student in db.Students
			//	group student by student.EnrollmentDate
			//	into dateGroup
			//	select new EnrollmentDateGroup()
			//	{
			//		EnrollmentDate = dateGroup.Key,
			//		StudentCount = dateGroup.Count()
			//	};

			// SQL version of the above LINQ code
			string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount " +
			               "FROM Person " +
			               "WHERE Discriminator = 'Student' " +
			               "GROUP BY EnrollmentDate";
			IEnumerable<EnrollmentDateGroup> data = db.Database.SqlQuery<EnrollmentDateGroup>(query);
			
			return View(data.ToList());
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}