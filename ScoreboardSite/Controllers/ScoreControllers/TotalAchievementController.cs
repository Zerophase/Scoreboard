using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScoreboardSite.DAL;
using ScoreboardSite.Models.Scores;

namespace ScoreboardSite.Controllers.ScoreControllers
{
    public class TotalAchievementController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: TotalAchievement
        public ActionResult Index()
        {
            return View(db.TotalAchievements.ToList());
        }

        // GET: TotalAchievement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalAchievements totalAchievements = db.TotalAchievements.Find(id);
            if (totalAchievements == null)
            {
                return HttpNotFound();
            }
            return View(totalAchievements);
        }

        // GET: TotalAchievement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TotalAchievement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AchievementCount")] TotalAchievements totalAchievements)
        {
            if (ModelState.IsValid)
            {
                db.TotalAchievements.Add(totalAchievements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(totalAchievements);
        }

        // GET: TotalAchievement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalAchievements totalAchievements = db.TotalAchievements.Find(id);
            if (totalAchievements == null)
            {
                return HttpNotFound();
            }
            return View(totalAchievements);
        }

        // POST: TotalAchievement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AchievementCount")] TotalAchievements totalAchievements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totalAchievements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(totalAchievements);
        }

        // GET: TotalAchievement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalAchievements totalAchievements = db.TotalAchievements.Find(id);
            if (totalAchievements == null)
            {
                return HttpNotFound();
            }
            return View(totalAchievements);
        }

        // POST: TotalAchievement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TotalAchievements totalAchievements = db.TotalAchievements.Find(id);
            db.TotalAchievements.Remove(totalAchievements);
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
