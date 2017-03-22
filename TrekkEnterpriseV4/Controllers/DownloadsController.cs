using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrekkEnterpriseV4.Models;

namespace TrekkEnterpriseV4.Controllers
{
    public class DownloadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Downloads
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Download(string id)
        {
            var user = db.Users.Where(theID => theID.AccessCode == id).FirstOrDefault();
            if (user == null || !user.Enabled) return RedirectToAction("Index", "Home");
            ViewBag.EntryCode = id;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult RecordDownload(string id)
        {
            var user = db.Users.Where(theID => theID.AccessCode == id).FirstOrDefault();
            if (user != null)
            {
                user.DownloadCount = user.DownloadCount + 1;
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