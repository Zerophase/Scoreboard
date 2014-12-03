using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ScoreboardSite.DAL;
using ScoreboardSite.Models;

namespace ScoreboardSite.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Student
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
			// How to sort
	        ViewBag.CurrentSort = sortOrder;
	        ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
	        ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";
	        var students = from s in db.Students
						   select s;

			// paging
	        if (searchString != null)
	        {
		        page = 1;
	        }
	        else
	        {
		        searchString = currentFilter;
	        }

	        ViewBag.CurrentFilter = searchString;

			// search for specific entry from text box.
	        if (!String.IsNullOrEmpty(searchString))
	        {
		        students = students.Where(s => s.LastName.Contains(searchString) ||
		                                       s.FirstMidName.Contains(searchString));
	        }

	        switch (sortOrder)
	        {
				case "name_desc" :
			        students = students.OrderByDescending(s => s.LastName);
			        break;
				case "Date":
			        students = students.OrderBy(s => s.EnrollmentDate);
			        break;
				case "date_desc":
			        students = students.OrderByDescending(s => s.EnrollmentDate);
			        break;
				default:
			        students = students.OrderBy(s => s.LastName);
			        break;
	        }

			/// Paging
	        int pageSize = 3;
	        int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// How to keep properties hidden just don't include Secret in the include field on
		// the create method of the Controller
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstMidName,EnrollmentDate")] Student student)
        {
	        try
	        {
				if (ModelState.IsValid)
				{
					db.Students.Add(student);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
	        }
	        catch (RetryLimitExceededException /*dex*/)
	        {
		        //Log the error (uncomment dex vaariable name and add a line here to write a log
				ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
	        }
           

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
	        if (id == null)
	        {
		        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
	        }
	        var studentToUpdate = db.Students.Find(id);
	        if (TryUpdateModel(studentToUpdate, "",
		        new string[] {"LastName", "FirstName", "EnrollmentDate"}))
	        {
		        try
		        {
			        db.Entry(studentToUpdate).State = EntityState.Modified;
			        db.SaveChanges();

			        return RedirectToAction("Index");
		        }
				catch (RetryLimitExceededException /* dex */)
				{
					//Log the error (uncomment dex variable name and add a line here to write a log.
					ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
				}
	        }
            return View(studentToUpdate);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
	        if (saveChangesError.GetValueOrDefault())
		        ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists contact your network admin.";
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
	        try
	        {
				// Slow
				//Student student = db.Students.Find(id);
				//db.Students.Remove(student);

				// Fast
		        Student studentToDelete = new Student() {ID = id};
		        db.Entry(studentToDelete).State = EntityState.Deleted;
				db.SaveChanges();
	        }
			catch (RetryLimitExceededException /*dex*/)
	        {
				//Log the error (uncomment dex variable name and add a line here to write a log.
				return RedirectToAction("Delete", new { id = id, saveChangesError = true });
	        }
           
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
