using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryTracking.Models;

namespace InventoryTracking.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            return View(db.items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(ItemsModel item)
        {
            try
            {
                // TODO: Add insert logic here
                db.items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult Search(int skuNumber)
        //{

        //    return View(db.items.ToList());
        //}

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Search(string name, ItemsModel item)
        {
            try
            {
                //var returnedItem = (from i in db.items
                //                    where i.name.Equals(item.name)
                //                    select i).ToList();
                //return View("Index", returnedItem);

                List<ItemsModel> listOfItems = new List<ItemsModel>();

                foreach (ItemsModel items in db.items)
                {
                    if (items.name.Equals(name))
                    {
                        listOfItems.Add(items); 
                    }
                }
                return View(listOfItems);
                

                // TODO: Add update logic here

                return RedirectToAction("Search");
            }
            catch
            {
                return View();
            }
        }





        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Items/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
