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
			return View();
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