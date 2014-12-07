﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScoreboardSite.DAL;
using ScoreboardSite.Models;

namespace ScoreboardSite.Controllers
{
    public class CourseController : Controller
    {
        private SchoolContext db = new SchoolContext();

	    public ActionResult Index(int? SelectedDepartment)
	    {
		    var departments = db.Departments.OrderBy(q => q.Name).ToList();
		    ViewBag.SelectedDepartment = new SelectList(departments, "DepartmentID", "Name", SelectedDepartment);
		    int departmentID = SelectedDepartment.GetValueOrDefault();

		    IQueryable<Course> courses =
			    db.Courses.Where(c => !SelectedDepartment.HasValue || c.DepartmentID == departmentID)
				    .OrderBy(d => d.CourseID)
				    .Include(d => d.Department);
		    // Use this to check the SQL generated
			//var sql = courses.ToString();
		    return View(courses.ToList());
	    }

        // GET: Course
		//public ActionResult Index()
		//{
		//	// Eager loading
		//	//var courses = db.Courses.Include(c => c.Department);
		//	//return View(courses.ToList());

		//	// to see SQL queries set a break point here
		//	var courses = db.Courses;
		//	var sql = courses.ToString();
		//	return View(courses.ToList());
		//}

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
	        PopulateDepartmentsDropDownList();
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits,DepartmentID")] Course course)
        {
	        try
	        {
				if (ModelState.IsValid)
				{
					db.Courses.Add(course);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
	        }
	        catch (RetryLimitExceededException /*dex*/)
	        {
		        // Log the error (uncomment dex variable name and add a line here to write a log.)
				ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
	        }


	        PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }

	    public ActionResult UpdateCourseCredits()
	    {
		    return View();
	    }

	    [HttpPost]
	    public ActionResult UpdateCourseCredits(int? multiplier)
	    {
		    if (multiplier != null)
		    {
			    ViewBag.RowsAffected = db.Database.ExecuteSqlCommand("UPDATE Course SET Credits = Credits * {0}", multiplier);
		    }
		    return View();
	    }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
	        PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
	        if (id == null)
	        {
		        return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);
	        }
	        var courseToUpdate = db.Courses.Find(id);
	        if (TryUpdateModel(courseToUpdate, "",
				new string[]{"Title", "Credits", "DepartmentID"}))
	        {
		        try
		        {
			        db.Entry(courseToUpdate).State = EntityState.Modified;
			        db.SaveChanges();

			        return RedirectToAction("Index");
		        }
		        catch (RetryLimitExceededException /* dex*/)
		        {
			        // Log the error (Uncomment dex variable name and add a line here to write a log.
					ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system admin.");
			        throw;
		        }
	        }
	        PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
            return View(courseToUpdate);
        }

	    private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
	    {
		    var departmentsQuery = from d in db.Departments
			    orderby d.Name
			    select d;
		    ViewBag.DepartmentID = new SelectList(departmentsQuery, "DepartmentID", "Name", selectedDepartment);
	    }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
