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
    public class MonstersSlayenController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: MonstersSlayen
        public ActionResult Index()
        {
            return View(db.MonstersSlayens.ToList());
        }

        // GET: MonstersSlayen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonstersSlayen monstersSlayen = db.MonstersSlayens.Find(id);
            if (monstersSlayen == null)
            {
                return HttpNotFound();
            }
            return View(monstersSlayen);
        }

        // GET: MonstersSlayen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonstersSlayen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KillCount")] MonstersSlayen monstersSlayen)
        {
            if (ModelState.IsValid)
            {
                db.MonstersSlayens.Add(monstersSlayen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monstersSlayen);
        }

        // GET: MonstersSlayen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonstersSlayen monstersSlayen = db.MonstersSlayens.Find(id);
            if (monstersSlayen == null)
            {
                return HttpNotFound();
            }
            return View(monstersSlayen);
        }

        // POST: MonstersSlayen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KillCount")] MonstersSlayen monstersSlayen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monstersSlayen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monstersSlayen);
        }

        // GET: MonstersSlayen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonstersSlayen monstersSlayen = db.MonstersSlayens.Find(id);
            if (monstersSlayen == null)
            {
                return HttpNotFound();
            }
            return View(monstersSlayen);
        }

        // POST: MonstersSlayen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonstersSlayen monstersSlayen = db.MonstersSlayens.Find(id);
            db.MonstersSlayens.Remove(monstersSlayen);
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
