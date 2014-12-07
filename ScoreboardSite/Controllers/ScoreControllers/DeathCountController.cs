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
    public class DeathCountController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: DeathCount
        public ActionResult Index()
        {
            return View(db.DeathCounts.ToList());
        }

        // GET: DeathCount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeathCount deathCount = db.DeathCounts.Find(id);
            if (deathCount == null)
            {
                return HttpNotFound();
            }
            return View(deathCount);
        }

        // GET: DeathCount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeathCount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TotalDeaths")] DeathCount deathCount)
        {
            if (ModelState.IsValid)
            {
                db.DeathCounts.Add(deathCount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deathCount);
        }

        // GET: DeathCount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeathCount deathCount = db.DeathCounts.Find(id);
            if (deathCount == null)
            {
                return HttpNotFound();
            }
            return View(deathCount);
        }

        // POST: DeathCount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TotalDeaths")] DeathCount deathCount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deathCount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deathCount);
        }

        // GET: DeathCount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeathCount deathCount = db.DeathCounts.Find(id);
            if (deathCount == null)
            {
                return HttpNotFound();
            }
            return View(deathCount);
        }

        // POST: DeathCount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeathCount deathCount = db.DeathCounts.Find(id);
            db.DeathCounts.Remove(deathCount);
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
