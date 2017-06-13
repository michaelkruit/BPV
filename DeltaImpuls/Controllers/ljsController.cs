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
    public class ljsController : Controller
    {
        private datimpulsEntities db = new datimpulsEntities();

        // GET: ljs
        public ActionResult Index()
        {
            return View(db.lj.ToList());
        }

        // GET: ljs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lj lj = db.lj.Find(id);
            if (lj == null)
            {
                return HttpNotFound();
            }
            return View(lj);
        }

        // GET: ljs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ljs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,license")] lj lj)
        {
            if (ModelState.IsValid)
            {
                lj.ID = Guid.NewGuid();
                db.lj.Add(lj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lj);
        }

        // GET: ljs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lj lj = db.lj.Find(id);
            if (lj == null)
            {
                return HttpNotFound();
            }
            return View(lj);
        }

        // POST: ljs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,license")] lj lj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lj);
        }

        // GET: ljs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lj lj = db.lj.Find(id);
            if (lj == null)
            {
                return HttpNotFound();
            }
            return View(lj);
        }

        // POST: ljs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            lj lj = db.lj.Find(id);
            db.lj.Remove(lj);
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
