using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ScoreboardSite.DAL;
using ScoreboardSite.Migrations;
using ScoreboardSite.Models;
using ScoreboardSite.Models.Scores;
using ScoreboardSite.ViewModels;
using WebGrease.Css.Extensions;

namespace ScoreboardSite.Controllers
{
    public class PlayerController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Player
		public ActionResult Index(string DisCriminators, string RegionDiscriminator, 
			bool? Friends)
		{
			var discriminatorsReturned = db.Database.SqlQuery<ScoreVM>(
				"SELECT DISTINCT Discriminator FROM dbo.Score");
			ViewBag.CurrentScoreSelection = DisCriminators;
			// Cannot figure out how to add spaces to this
			ViewBag.DisCriminators = new SelectList(discriminatorsReturned, "Discriminator", "Discriminator", DisCriminators);


			string scoreColumn = "";
			string scoreIdColumn = "";
			string orderBy = "";
			scoreColumn = setUpScoreColumn(DisCriminators, ref scoreIdColumn, ref orderBy);

			var regionDiscriminatorsReturned = db.Database.SqlQuery<Region>(
				"SELECT RegionID, RegionName FROM dbo.Region");
			ViewBag.RegionDiscriminator = new SelectList(regionDiscriminatorsReturned, "RegionName", "RegionName", RegionDiscriminator);

			var friendSqlQuery1 = "";
			var friendSqlQuery2 = "";
			setupFriendSqlQuerys(Friends, scoreColumn, ref friendSqlQuery1, ref friendSqlQuery2);

			var playerOrderQuery = "";
			setUpPlayerOrderQuery(RegionDiscriminator, friendSqlQuery1, ref playerOrderQuery, 
				scoreColumn, scoreIdColumn);
			
			playerOrderQuery += " ORDER BY " + scoreColumn + " " + orderBy;

			IEnumerable<AssignedScores> data;
			data = assignedScoreses(RegionDiscriminator, friendSqlQuery1, playerOrderQuery, 
				scoreIdColumn, friendSqlQuery2, scoreColumn, orderBy);
				

			if (!string.IsNullOrEmpty(friendSqlQuery1))
				return View(data.ToList());
			else if (!string.IsNullOrEmpty(DisCriminators))
				return View(data.ToList());
			else if (!string.IsNullOrEmpty(RegionDiscriminator))
			{
				var player = from p in db.Players
					join r in db.Regions on p.Region equals r
					where (r.RegionName == RegionDiscriminator)
					select new AssignedScores
					{
						AccountName = p.AccountName,
						RegionName = r.RegionName
					};
				return View(player.ToList());
			}
			else
			{
				var player = from p in db.Players
					join r in db.Regions on p.Region equals r
					select new AssignedScores
					{
						AccountName = p.AccountName,
						RegionName = r.RegionName
					};
				return View(player.ToList());
			}
		}

	    private IEnumerable<AssignedScores> assignedScoreses(string RegionDiscriminator, string friendSqlQuery1, string playerOrderQuery,
		    string scoreIdColumn, string friendSqlQuery2, string scoreColumn, string orderBy)
	    {
		    if (string.IsNullOrEmpty(friendSqlQuery1))
		    {
			    return db.Database.SqlQuery<AssignedScores>(playerOrderQuery);
		    }
		    else
		    {
			    var scoreCheck = "";
			    if (!string.IsNullOrEmpty(scoreIdColumn))
			    {
				    scoreCheck = " AND " + scoreIdColumn + " = s.ID ";
			    }
			    var completeFirstPart = friendSqlQuery1 + scoreCheck +
			                            "INNER JOIN Region r " +
			                            "ON p.Region_RegionID = r.RegionID " +
			                            "WHERE PlayerName = @Fname ";

			    var completeSecondPart = friendSqlQuery2 + scoreCheck +
			                             "INNER JOIN Region r " +
			                             "ON p.Region_RegionID = r.RegionID " +
			                             "WHERE PlayerName = @Fname ";

			    if (!string.IsNullOrEmpty(RegionDiscriminator))
			    {
				    completeFirstPart += "AND r.RegionName = " +
				                         "'" + RegionDiscriminator + "'";
				    completeSecondPart += "AND r.RegionName = " +
				                          "'" + RegionDiscriminator + "'";
			    }


			    var completedQUery = completeFirstPart + ") AS g " + completeSecondPart + ") AS h ";
			    if (!string.IsNullOrEmpty(scoreColumn))
				    completedQUery += " ORDER BY " + scoreColumn + " " + orderBy;
			    return db.Database.SqlQuery<AssignedScores>(completedQUery);
		    }
		    return null;
	    }

	    private void setUpPlayerOrderQuery(string RegionDiscriminator, string friendSqlQuery1, 
			ref string playerOrderQuery, string scoreColumn, string scoreIdColumn)
	    {
		    if (string.IsNullOrEmpty(friendSqlQuery1))
		    {
			    playerOrderQuery = "SELECT AccountName, RegionName, " + scoreColumn + " FROM dbo.Player AS p " +
			                       "INNER JOIN dbo.Score AS s ON s.Player_PlayerID = p.PlayerID " +
			                       "INNER JOIN dbo.Region AS r ON p.Region_RegionID = r.RegionID " +
			                       "WHERE " + scoreIdColumn + " = s.ID ";

			    if (!string.IsNullOrEmpty(RegionDiscriminator))
			    {
				    playerOrderQuery += "AND r.RegionName = " +
				                        "'" + RegionDiscriminator + "'";
			    }
		    }
	    }

	    private void setupFriendSqlQuerys(bool? Friends, string scoreColumn, ref string friendSqlQuery1,
		    ref string friendSqlQuery2)
	    {
		    if (Session["AccountName"] != null)
		    {
			    ViewBag.LoggedInAccount = (string) Session["AccountName"];
			    if (Friends == true)
			    {
				    var scoreCheck = "";
				    if (!string.IsNullOrEmpty(scoreColumn))
					    scoreCheck = ", " + scoreColumn +
					                 " AS " + scoreColumn;
				    ViewBag.Friends = true;
				    friendSqlQuery1 = "DECLARE @Fname NVARCHAR(48) = " + "'" +
				                      ViewBag.LoggedInAccount + "'" +
				                      " SELECT FriendName, RegionName" + scoreCheck + " FROM( " +
				                      "SELECT * FROM FriendRelations " +
				                      "Inner Join Player p " +
				                      "ON p.AccountName = FriendName " +
				                      "INNER JOIN Score s " +
				                      "ON p.PlayerID = s.Player_PlayerID "; //+
				    //"WHERE PlayerName = @Fname"//) AS g "

				    friendSqlQuery2 = "UNION " +
				                      " SELECT PlayerName, RegionName" + scoreCheck +
				                      " FROM( SELECT * FROM FriendRelations " +
				                      "INNER JOIN Player p " +
				                      "ON p.AccountName = PlayerName " +
				                      "Inner JOIN Score s " +
				                      "ON p.PlayerID = s.Player_PlayerID "; // +
				    //"WHERE PlayerName = @Fname"//) AS h " +
			    }
			    else
			    {
				    ViewBag.Friends = false;
			    }
		    }
	    }

	    private string setUpScoreColumn(string DisCriminators, ref string scoreIdColumn,
		    ref string orderBy)
	    {
		    string ascend = "ASC";
		    string descend = "DESC";
		    string scoreColumn = "";
		    switch (DisCriminators)
		    {
			    case "OverallScore":
			    {
				    scoreColumn = "OverallScore";
				    scoreIdColumn = "p.OverallScore_ID";
				    orderBy = descend;
				    break;
			    }
			    case "CompletionTime":
			    {
				    scoreColumn = "CompletionTime";
				    scoreIdColumn = "p.CompletionTime_ID";
				    orderBy = ascend;
				    break;
			    }
			    case "DeathCount":
			    {
				    scoreColumn = "DeathCount";
				    scoreIdColumn = "p.DeathCount_ID";
				    orderBy = ascend;
				    break;
			    }
			    case "MonstersSlayen":
			    {
				    scoreColumn = "MonstersSlayen";
				    scoreIdColumn = "p.MonstersSlayen_ID";
				    orderBy = descend;
				    break;
			    }
			    case "TotalAchievements":
			    {
				    scoreColumn = "TotalAchievements";
				    scoreIdColumn = "p.TotalAchievements_ID";
				    orderBy = descend;
				    break;
			    }
		    }
		    return scoreColumn;
	    }

	    // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,AccountName")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,AccountName")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
