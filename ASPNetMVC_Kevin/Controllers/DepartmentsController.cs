using ASPNetMVC_Kevin.Context;
using ASPNetMVC_Kevin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ASPNetMVC_Kevin.Controllers
{
    public class DepartmentsController : Controller
    {
        MyContext myContext = new MyContext();
        // GET: Departments
        public ActionResult Index()
        {
            return View(myContext.Departments.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(myContext.Departments.Find(id));
        }
        //create viewnya
        public ActionResult Create()
        {
            return View();
        }
        //create aactionnya
        [HttpPost]
        public ActionResult Create(Department department)
        {
            myContext.Departments.Add(department);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }
         public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = myContext.Departments.Find(id);
            if(department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                myContext.Entry(department).State = EntityState.Modified;
                myContext.SaveChanges();
                return RedirectToAction("index");
            }
            return View(department);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = myContext.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Department department = myContext.Departments.Find(id);
            myContext.Departments.Remove(department);
            myContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}