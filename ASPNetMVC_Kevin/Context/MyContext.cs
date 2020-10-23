using ASPNetMVC_Kevin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPNetMVC_Kevin.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("ASPNetMVC_Kevin") { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }

    }
}