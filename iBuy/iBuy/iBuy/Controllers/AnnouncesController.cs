using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iBuy.DAL;
using iBuy.Models;

namespace iBuy.Controllers
{
    public class AnnouncesController : Controller
    {
        private AnnounceContext db = new AnnounceContext();

        // GET: Announces
        public ActionResult Index()
        {
            return View(db.Announces.ToList());
        }

        // GET: Announces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announce announce = db.Announces.Find(id);
            if (announce == null)
            {
                return HttpNotFound();
            }
           
            return View(announce);
        }

        // GET: Announces/Create
        public ActionResult Create()
        {
            ViewBag.CityList = new MyDropDownList().getCity();
            ViewBag.CategorieList = new MyDropDownList().getCategory();
            return View();
        }

        // POST: Announces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Title,Price,Date,Isprof,Type")] Announce announce, FormCollection value)
        {
            if (ModelState.IsValid)
            {

                Debug.WriteLine("the selected id is : " + value["icityid"] + "  and type is" + value["icityid"].GetType());
                announce.Category = db.Categories.Find(Int32.Parse(value["icategorieid"]));
                announce.Address = db.Addresses.Find(Int32.Parse(value["icityid"]));
                db.Announces.Add(announce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(announce);
        }

        // GET: Announces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announce announce = db.Announces.Find(id);
            if (announce == null)
            {
                return HttpNotFound();
            }
            return View(announce);
        }

        // POST: Announces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Title,Price,Date,Isprof,Type")] Announce announce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announce);
        }

        // GET: Announces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announce announce = db.Announces.Find(id);
            if (announce == null)
            {
                return HttpNotFound();
            }
            return View(announce);
        }

        // POST: Announces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Announce announce = db.Announces.Find(id);
            db.Announces.Remove(announce);
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
