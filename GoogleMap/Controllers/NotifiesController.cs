﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoogleMap.Models;

namespace GoogleMap.Controllers
{
    public class NotifiesController : Controller
    {
        private TestDbEntities db = new TestDbEntities();

        // GET: Notifies
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Notifies.ToList());
        }

        // GET: Notifies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notify notify = db.Notifies.Find(id);
            if (notify == null)
            {
                return HttpNotFound();
            }
            return View(notify);
        }

        // GET: Notifies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notifies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Message,Url,PhoneNumber")] Notify notify)
        {
            if (ModelState.IsValid)
            {
                db.Notifies.Add(notify);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notify);
        }

        // GET: Notifies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notify notify = db.Notifies.Find(id);
            if (notify == null)
            {
                return HttpNotFound();
            }
            return View(notify);
        }

        // POST: Notifies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Message,Url,PhoneNumber")] Notify notify)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notify).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notify);
        }

        // GET: Notifies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notify notify = db.Notifies.Find(id);
            if (notify == null)
            {
                return HttpNotFound();
            }
            return View(notify);
        }

        // POST: Notifies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notify notify = db.Notifies.Find(id);
            db.Notifies.Remove(notify);
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
