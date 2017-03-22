using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrekkEnterpriseV4.Models;

namespace TrekkEnterpriseV4.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: All Roles
        [Authorize]
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        // create a new role
        [Authorize(Roles = "SuperUser")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        // Create a new role
        [HttpPost]
        public ActionResult Create(Microsoft.AspNet.Identity.EntityFramework.IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


                
    

    }
}