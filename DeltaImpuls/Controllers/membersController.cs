﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeltaImpuls.Models;
using PagedList;

namespace DeltaImpuls.Controllers
{
    /// <summary>
    /// Controller that shows the wished members
    /// It also handels creating, editing and deleting members
    /// It shows the settings page
    /// </summary>
    [Authorize]
    public class membersController : Controller
    {
        private datimpulsEntities db = new datimpulsEntities();

        // GET: members
        public ActionResult Index(string searchString, Guid? locationFilter, Guid? categorieFilter, int? page)
        {
            var member = db.member.Include(m => m.categorie).Include(m => m.lj).Include(m => m.location).Include(m => m.ls);
            
            var seniorAmount = member.Where(m => m.categorie.age > 17).Count();
            var juniorAmount = member.Where(m => m.categorie.age < 18).Count();

            ViewBag.SearchValue = searchString;
            ViewBag.CurrentLocation = locationFilter;
            ViewBag.CurrentCategorie = categorieFilter;
            ViewBag.SeniorAmount = seniorAmount;
            ViewBag.JuniorAmount = juniorAmount;
            ViewBag.location_ID = new SelectList(db.location, "ID", "city");
            ViewBag.categorie_id = new SelectList(db.categorie, "ID", "name");

            if (locationFilter.HasValue)
            {
                member = member.Where(m => m.location_ID == locationFilter);
                seniorAmount = member.Where(m => m.categorie.age > 17).Where(m => m.location_ID == locationFilter).Count();
                ViewBag.SeniorAmount = seniorAmount;

                juniorAmount = member.Where(m => m.categorie.age < 18).Where(m => m.location_ID == locationFilter).Count();
                ViewBag.JuniorAmount = juniorAmount;
            }

            if (categorieFilter.HasValue)
            {
                member = member.Where(m => m.categorie_id == categorieFilter);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                member = member.Where(m =>
                m.firstname.Contains(searchString)
                || m.lastname.Contains(searchString)
                );
            }

            if(searchString != null)
            {
                page = 1;
            }

            int pageSize = 10;
            int pageNumber = page ?? 1;

            return View(member.OrderBy(m => m.firstname).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Settings()
        {
            return View();
        }

        // GET: members/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: members/Create
        public ActionResult Create()
        {
            ViewBag.categorie_id = new SelectList(db.categorie, "ID", "name");
            ViewBag.lj_id = new SelectList(db.lj, "ID", "license");
            ViewBag.location_ID = new SelectList(db.location, "ID", "city");
            ViewBag.ls_id = new SelectList(db.ls, "ID", "license");
            return View();
        }

        // POST: members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstname,lastname,insertion,bondsnr,cg,paratt,dateborn,gender,membersince,adres,postcode,city,phonennumber,mobilenumber,email,categorie_id,location_ID,lj_id,ls_id")] member member)
        {
            if (ModelState.IsValid)
            {
                member.ID = Guid.NewGuid();
                db.member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categorie_id = new SelectList(db.categorie, "ID", "name", member.categorie_id);
            ViewBag.lj_id = new SelectList(db.lj, "ID", "license", member.lj_id);
            ViewBag.location_ID = new SelectList(db.location, "ID", "city", member.location_ID);
            ViewBag.ls_id = new SelectList(db.ls, "ID", "license", member.ls_id);
            return View(member);
        }

        // GET: members/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.categorie_id = new SelectList(db.categorie, "ID", "name", member.categorie_id);
            ViewBag.lj_id = new SelectList(db.lj, "ID", "license", member.lj_id);
            ViewBag.location_ID = new SelectList(db.location, "ID", "city", member.location_ID);
            ViewBag.ls_id = new SelectList(db.ls, "ID", "license", member.ls_id);
            return View(member);
        }

        // POST: members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstname,lastname,insertion,bondsnr,cg,paratt,dateborn,gender,membersince,adres,postcode,city,phonennumber,mobilenumber,email,categorie_id,location_ID,lj_id,ls_id")] member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categorie_id = new SelectList(db.categorie, "ID", "name", member.categorie_id);
            ViewBag.lj_id = new SelectList(db.lj, "ID", "license", member.lj_id);
            ViewBag.location_ID = new SelectList(db.location, "ID", "city", member.location_ID);
            ViewBag.ls_id = new SelectList(db.ls, "ID", "license", member.ls_id);
            return View(member);
        }

        // GET: members/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            member member = db.member.Find(id);
            db.member.Remove(member);
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
