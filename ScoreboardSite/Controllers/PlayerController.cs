using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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
		public ActionResult Index(string DisCriminators)
        {
			var discriminatorsReturned = db.Database.SqlQuery<ScoreVM>(
				"SELECT DISTINCT Discriminator FROM dbo.Score");

			
											 

			ViewBag.DisCriminators = new SelectList(discriminatorsReturned, "Discriminator", "Discriminator", DisCriminators);

			string scoreColumn = "";
			string scoreIdColumn = "";
			string orderBy = "";
			string ascend = "ASC";
			string descend = "DESC";
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
			//var sortOrder = db.Database<Score>("SELECT")
			var playerOrderQuery = "SELECT AccountName, " + scoreColumn + " FROM dbo.Player AS p " +
				"INNER JOIN dbo.Score AS s ON s.Player_PlayerID = p.PlayerID " +
				"WHERE " + scoreIdColumn + " = s.ID" + " ORDER BY " + scoreColumn + " " + orderBy;

			IEnumerable<AssignedScores> data = db.Database.SqlQuery<AssignedScores>(playerOrderQuery);
			if(!string.IsNullOrEmpty(DisCriminators))
				return View(data.ToList());
			else
			{
				var player = from p in db.Players
					select p.AccountName;
				IEnumerable<AssignedScores> players = db.Database.SqlQuery<AssignedScores>(player.ToString());
				return View(players.ToList());
			}
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
