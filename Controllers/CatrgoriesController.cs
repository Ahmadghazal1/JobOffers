using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobsOffers.Models;
using WebApplication1.Models;

namespace JobsOffers.Controllers
{
    [Authorize(Roles ="Admins")]
    public class CatrgoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Catrgories
        public ActionResult Index()
        {
            return View(db.Catrgories.ToList());
        }

        // GET: Catrgories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catrgory catrgory = db.Catrgories.Find(id);
            if (catrgory == null)
            {
                return HttpNotFound();
            }
            return View(catrgory);
        }

        // GET: Catrgories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catrgories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CatrgoryName,CategoryDescription")] Catrgory catrgory)
        {
            if (ModelState.IsValid)
            {
                db.Catrgories.Add(catrgory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catrgory);
        }

        // GET: Catrgories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catrgory catrgory = db.Catrgories.Find(id);
            if (catrgory == null)
            {
                return HttpNotFound();
            }
            return View(catrgory);
        }

        // POST: Catrgories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CatrgoryName,CategoryDescription")] Catrgory catrgory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catrgory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catrgory);
        }

        // GET: Catrgories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catrgory catrgory = db.Catrgories.Find(id);
            if (catrgory == null)
            {
                return HttpNotFound();
            }
            return View(catrgory);
        }

        // POST: Catrgories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catrgory catrgory = db.Catrgories.Find(id);
            db.Catrgories.Remove(catrgory);
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
