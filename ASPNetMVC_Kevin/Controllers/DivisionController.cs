using ASPNetMVC_Kevin.Context;
using ASPNetMVC_Kevin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ASPNetMVC_Kevin.Controllers
{
    public class DivisionController : Controller
    {
        MyContext myContext = new MyContext();
        // GET: Division
        public ActionResult Index()
        {
            var divisions = myContext.Divisions.Include("DepartmentIDNav");
            return View(divisions);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var division = myContext.Divisions.Include("DepartmentIDNav").FirstOrDefault(a => a.Id == id);

            if (division == null)
            {
                return HttpNotFound();
            }

            return View(division);
        }
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(myContext.Departments, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Division division)
        {
            if (ModelState.IsValid)
            {
                myContext.Divisions.Add(division);
                myContext.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.DepartmentId = new SelectList(myContext.Departments, "Id", "Name", division.DepartmentIDNav);
            return View(division);
        }

        public ActionResult Edit(int id)
        {
            Division division = myContext.Divisions.Find(id);
            ViewBag.DepartmentId = new SelectList(myContext.Departments, "Id", "Name", division.DepartmentId);
            return View(division);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Division division)
        {
            if (ModelState.IsValid)
            {
                myContext.Entry(division).State = EntityState.Modified;
                myContext.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.DepartmentId = new SelectList(myContext.Departments, "Id", "Name", division.DepartmentId);
            return View(division);
        }

        public ActionResult Delete(int? id)
        {
            var division = myContext.Divisions.Include("DepartmentIDNav").FirstOrDefault(m => m.Id == id);
            return View(division);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var division = myContext.Divisions.Include("DepartmentIDNav").FirstOrDefault(d => d.Id == id);
            myContext.Divisions.Remove(division);
            myContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}