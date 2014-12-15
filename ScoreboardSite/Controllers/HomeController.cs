using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
		public ActionResult Index(string AccountName, string Password)
		{
			var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
				.Select(x => new { x.Key, x.Value.Errors }).ToArray();
			if (ModelState.IsValid)
			{
				if (IsValid(AccountName, Password))
				{
					Session["AccountName"] = AccountName;
					return RedirectToAction("Index", "Player");
				}
			}
			return View();
		}

		private bool passwordFound;
		public bool IsValid(string userName, string password)
		{
			using (var cn = new SqlConnection(@"Data Source=(LocalDb)\v11.0; AttachDBFilename=|DataDirectory|\ScoreboardSite2.mdf Initial Catalog=ScoreboardSite2;Integrated Security=SSPI"))
			{
				string sql = @"SELECT [AccountName] FROM [dbo].[Player] " +
							 @"WHERE [AccountName] = @u AND [Password] = @p";
				var cmd = new SqlCommand(sql, cn);
				cmd.Parameters.Add(new SqlParameter("@u", SqlDbType.NVarChar)).Value = userName ?? " ";
				cmd.Parameters.Add(new SqlParameter("@p", SqlDbType.NVarChar)).Value = password ?? " ";
				cn.Open();
				var reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					passwordFound = true;
				}
				else
				{
					passwordFound = false;
				}

				reader.Dispose();
				cmd.Dispose();

				return passwordFound;
			}
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