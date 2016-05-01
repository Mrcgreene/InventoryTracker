using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryTracking.Models;

namespace InventoryTracking.Controllers
{
    public class ManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Manager
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View(db.items.ToList());              //is expecting and need to pass in a list here
            }
            return View();
        }

        // GET: Manager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsModel itemsModel = db.items.Find(id);
            if (itemsModel == null)
            {
                return HttpNotFound();
            }
            return View(itemsModel);
        }

        // GET: Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,sku,name,itemQuantity,itemPrice,storeID")] ItemsModel itemsModel)
        {
            if (ModelState.IsValid)
            {
                db.items.Add(itemsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemsModel);
        }

        // GET: Manager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsModel itemsModel = db.items.Find(id);
            if (itemsModel == null)
            {
                return HttpNotFound();
            }
            return View(itemsModel);
        }

        // POST: Manager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,sku,name,itemQuantity,itemPrice,storeID")] ItemsModel itemsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemsModel);
        }

        // GET: Manager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsModel itemsModel = db.items.Find(id);
            if (itemsModel == null)
            {
                return HttpNotFound();
            }
            return View(itemsModel);
        }

        // POST: Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemsModel itemsModel = db.items.Find(id);
            db.items.Remove(itemsModel);
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
