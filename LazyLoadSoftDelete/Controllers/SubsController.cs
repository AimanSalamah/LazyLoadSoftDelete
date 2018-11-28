using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LazyLoadSoftDelete.Models;

namespace LazyLoadSoftDelete.Controllers
{
    public class SubsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subs
        public ActionResult Index()
        {
            var subs = db.Subs.Include(s => s.Main);
            return View(subs.ToList());
        }

        // GET: Subs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub sub = db.Subs.Find(id);
            if (sub == null)
            {
                return HttpNotFound();
            }
            return View(sub);
        }

        // GET: Subs/Create
        public ActionResult Create()
        {
            ViewBag.MainID = new SelectList(db.Mains, "ID", "Name");
            return View();
        }

        // POST: Subs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MainID")] Sub sub)
        {
            if (ModelState.IsValid)
            {
                db.Subs.Add(sub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainID = new SelectList(db.Mains, "ID", "Name", sub.MainID);
            return View(sub);
        }

        // GET: Subs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub sub = db.Subs.Find(id);
            if (sub == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainID = new SelectList(db.Mains, "ID", "Name", sub.MainID);
            return View(sub);
        }

        // POST: Subs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MainID")] Sub sub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainID = new SelectList(db.Mains, "ID", "Name", sub.MainID);
            return View(sub);
        }

        // GET: Subs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub sub = db.Subs.Find(id);
            if (sub == null)
            {
                return HttpNotFound();
            }
            return View(sub);
        }

        // POST: Subs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sub sub = db.Subs.Find(id);
            db.Subs.Remove(sub);
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
