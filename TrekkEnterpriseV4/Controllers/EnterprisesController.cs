using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrekkEnterpriseV4.DAL;
using TrekkEnterpriseV4.Models;

namespace TrekkEnterpriseV4.Controllers
{
    public class EnterprisesController : Controller
    {
        private EnterpriseContext db = new EnterpriseContext();

        // GET: Enterprises
        [Authorize]
        public ActionResult Index()
        {
            var enterprises = db.Enterprises.Include(e => e.Client).Include(e => e.Parent);
            return View(enterprises.ToList());
        }

        // GET: Enterprises/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enterprise enterprise = db.Enterprises.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            return View(enterprise);
        }

        // GET: Enterprises/Create
        [Authorize]
        public ActionResult Create()
        {
            // get entry code
            Enterprise enterprise = new Enterprise();
            Helpers helper = new Helpers();
            enterprise.AccessCode = helper.GenerateEntryCode();    

                                                       
            enterprise.Enabled = true;
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Name");
            ViewBag.ParentID = new SelectList(db.Parents, "ID", "Name");
            return View(enterprise);
        }

        // POST: Enterprises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClientID,ParentID,AccessCode,IsAndroid,ApkName,Route,Enabled,DateModified,DateCreated,DownloadCount")] Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                
                // avoiding null value DateTime exception
                enterprise.DateCreated = DateTime.Now;
                enterprise.DateModified = DateTime.Now;

                db.Enterprises.Add(enterprise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Name", enterprise.ClientID);
            ViewBag.ParentID = new SelectList(db.Parents, "ID", "Name", enterprise.ParentID);
            return View(enterprise);
        }

        // GET: Enterprises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enterprise enterprise = db.Enterprises.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Name", enterprise.ClientID);
            ViewBag.ParentID = new SelectList(db.Parents, "ID", "Name", enterprise.ParentID);
            return View(enterprise);
        }

        // POST: Enterprises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClientID,ParentID,AccessCode,IsAndroid,ApkName,Route,Enabled,DateModified,DateCreated,DownloadCount")] Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enterprise).State = EntityState.Modified;
                enterprise.DateModified = DateTime.Now;
                enterprise.DateCreated = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Name", enterprise.ClientID);
            ViewBag.ParentID = new SelectList(db.Parents, "ID", "Name", enterprise.ParentID);
            return View(enterprise);
        }

        // GET: Enterprises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enterprise enterprise = db.Enterprises.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            return View(enterprise);
        }

        // POST: Enterprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enterprise enterprise = db.Enterprises.Find(id);
            db.Enterprises.Remove(enterprise);
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
