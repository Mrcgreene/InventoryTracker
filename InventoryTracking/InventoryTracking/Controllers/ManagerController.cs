using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryTracking.Models;
using System.Net.Mail;

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
        public ActionResult Edit(int? id, ItemsModel items)
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

                if (itemsModel.itemQuantity <= itemsModel.refillLevel)
                {
                    var fromAddress = new MailAddress("marx414@gmail.com", "From Mr Robot");
                    var toAddress = new MailAddress("marx414@gmail.com", "Store Manager");
                    const string fromPassword = "chavez.1";
                    const string subject = "Low Inventory, Please place order immediately";
                    const string body = "Please check your store's inventory, item(s) have reached refill level, place order.";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                }

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
