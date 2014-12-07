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
    public class CompletionTimeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: CompletionTime
        public ActionResult Index()
        {
            return View(db.CompletionTimes.ToList());
        }

        // GET: CompletionTime/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			CompletionTime completionTime = db.CompletionTimes.Find(id);
            if (completionTime == null)
            {
                return HttpNotFound();
            }
            return View(completionTime);
        }

        // GET: CompletionTime/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompletionTime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TotalTimeToCompletion")] CompletionTime completionTime)
        {
            if (ModelState.IsValid)
            {
				db.CompletionTimes.Add(completionTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(completionTime);
        }

        // GET: CompletionTime/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			CompletionTime completionTime = db.CompletionTimes.Find(id);
            if (completionTime == null)
            {
                return HttpNotFound();
            }
            return View(completionTime);
        }

        // POST: CompletionTime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TotalTimeToCompletion")] CompletionTime completionTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(completionTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(completionTime);
        }

        // GET: CompletionTime/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			CompletionTime completionTime = db.CompletionTimes.Find(id);
            if (completionTime == null)
            {
                return HttpNotFound();
            }
            return View(completionTime);
        }

        // POST: CompletionTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			CompletionTime completionTime = db.CompletionTimes.Find(id);
			db.CompletionTimes.Remove(completionTime);
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
