using System;
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
    public class Add_to_listController : Controller
    {
        private TestDbEntities db = new TestDbEntities();

        // GET: Add_to_list
        public ActionResult Index()
        {
            return View(db.google_map.ToList());
        }

        // GET: Add_to_list/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            google_map google_map = db.google_map.Find(id);
            if (google_map == null)
            {
                return HttpNotFound();
            }
            return View(google_map);
        }

        // GET: Add_to_list/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Add_to_list/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rating,Address,Lat,Long,Zoom,Phone")] google_map google_map)
        {
            if (ModelState.IsValid)
            {
                db.google_map.Add(google_map);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(google_map);
        }

        // GET: Add_to_list/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            google_map google_map = db.google_map.Find(id);
            if (google_map == null)
            {
                return HttpNotFound();
            }
            return View(google_map);
        }

        // POST: Add_to_list/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rating,Address,Lat,Long,Zoom,Phone")] google_map google_map)
        {
            if (ModelState.IsValid)
            {
                db.Entry(google_map).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(google_map);
        }

        // GET: Add_to_list/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            google_map google_map = db.google_map.Find(id);
            if (google_map == null)
            {
                return HttpNotFound();
            }
            return View(google_map);
        }

        // POST: Add_to_list/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            google_map google_map = db.google_map.Find(id);
            db.google_map.Remove(google_map);
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
