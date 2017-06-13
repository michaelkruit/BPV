using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeltaImpuls.Models;

namespace DeltaImpuls.Controllers
{
    [Authorize]
    public class lsController : Controller
    {
        private datimpulsEntities db = new datimpulsEntities();

        // GET: ls
        public ActionResult Index()
        {
            return View(db.ls.ToList());
        }

        // GET: ls/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ls ls = db.ls.Find(id);
            if (ls == null)
            {
                return HttpNotFound();
            }
            return View(ls);
        }

        // GET: ls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,license")] ls ls)
        {
            if (ModelState.IsValid)
            {
                ls.ID = Guid.NewGuid();
                db.ls.Add(ls);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ls);
        }

        // GET: ls/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ls ls = db.ls.Find(id);
            if (ls == null)
            {
                return HttpNotFound();
            }
            return View(ls);
        }

        // POST: ls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,license")] ls ls)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ls).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ls);
        }

        // GET: ls/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ls ls = db.ls.Find(id);
            if (ls == null)
            {
                return HttpNotFound();
            }
            return View(ls);
        }

        // POST: ls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ls ls = db.ls.Find(id);
            db.ls.Remove(ls);
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
