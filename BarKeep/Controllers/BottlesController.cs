using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarKeep.DAL;
using BarKeep.Models;

namespace BarKeep.Controllers
{
    public class BottlesController : Controller
    {
        private BarKeepContext db = new BarKeepContext();
        //EDIT: Bottles
        public ActionResult Inventory([Bind(Include = "ID,Name,BottleType,Volume,Cost,Price,Par,Notes,OnHand")] Bottle bottle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Inventory");
            }

            return View(db.Bottles.ToList());
            
        }



        // GET: Bottles
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : ""
;         
            var bottles = from s in db.Bottles
                          select s;

            switch (sortOrder)
            {
                case "name_desc":
                    bottles = bottles.OrderByDescending(s => s.Name);
                    break;
                default:
                    bottles = bottles.OrderByDescending(s => s.Price);
                    break;
            }
            return View(db.Bottles.ToList());

        }

        // GET: Bottles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottle bottle = db.Bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
        }

        // GET: Bottles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bottles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,BottleType,Volume,Cost,Price,Par,Notes,OnHand")] Bottle bottle)
        {
            if (ModelState.IsValid)
            {
                db.Bottles.Add(bottle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            


            return View(bottle);
        }

        // GET: Bottles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottle bottle = db.Bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
        }


        

        // POST: Bottles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,BottleType,Volume,Cost,Price,Par,Notes,OnHand")] Bottle bottle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bottle);
        }

        // GET: Bottles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottle bottle = db.Bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
        }

        // POST: Bottles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bottle bottle = db.Bottles.Find(id);
            db.Bottles.Remove(bottle);
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
