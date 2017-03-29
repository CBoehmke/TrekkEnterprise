using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrekkEnterpriseV4.DAL;
using TrekkEnterpriseV4.Models;

namespace TrekkEnterpriseV4.Controllers
{
    public class DownloadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private EnterpriseContext edb = new EnterpriseContext();

        // GET: Downloads
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Download(string id)
        {
            var enterprise = edb.Enterprises.Where(theID => theID.AccessCode == id).FirstOrDefault();
            if (enterprise == null || !enterprise.Enabled) return RedirectToAction("Index", "Home");
            ViewBag.AccessCode = id;
            ViewBag.IsAndroid = enterprise.IsAndroid;
            ViewBag.ApkName = enterprise.ApkName;

            var android = edb.Enterprises.Where(isAndroid => isAndroid.IsAndroid).FirstOrDefault();
          
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult RecordDownload(string id)
        {
            var user = db.Users.Where(theID => theID.AccessCode == id).FirstOrDefault();
            //var enterprise = edb.Enterprises.Where(downloadCount =
            if (user != null)
            {
                
                user.DateLastDownloaded = DateTime.Now;
                db.SaveChanges();
            }

            return Json(new { result = "success" });
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult RemoteEntryCode()
        {
            var helper = new Helpers();
            return Json(new { code = helper.GenerateEntryCode() });
        }
    }
}