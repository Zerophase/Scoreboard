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
    public class OverallScoreController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: OverallScore
        public ActionResult Index()
        {
            return View(db.OverallScores.ToList());
        }

        // GET: OverallScore/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallScore overallScore = db.OverallScores.Find(id);
            if (overallScore == null)
            {
                return HttpNotFound();
            }
            return View(overallScore);
        }

        // GET: OverallScore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OverallScore/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TotalScore")] OverallScore overallScore)
        {
            if (ModelState.IsValid)
            {
                db.OverallScores.Add(overallScore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(overallScore);
        }

        // GET: OverallScore/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallScore overallScore = db.OverallScores.Find(id);
            if (overallScore == null)
            {
                return HttpNotFound();
            }
            return View(overallScore);
        }

        // POST: OverallScore/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TotalScore")] OverallScore overallScore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(overallScore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(overallScore);
        }

        // GET: OverallScore/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallScore overallScore = db.OverallScores.Find(id);
            if (overallScore == null)
            {
                return HttpNotFound();
            }
            return View(overallScore);
        }

        // POST: OverallScore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OverallScore overallScore = db.OverallScores.Find(id);
            db.OverallScores.Remove(overallScore);
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
