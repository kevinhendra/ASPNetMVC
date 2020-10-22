using ASPNetMVC_Kevin.Context;
using ASPNetMVC_Kevin.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
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


    }
}