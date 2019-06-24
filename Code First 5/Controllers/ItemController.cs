using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Code_First_5.Models;
using System.Data.Entity;

namespace Code_First_5.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        private Cmns obj = new Cmns();
        public ActionResult Index()
        {
            return View(obj.Items.ToList());
        }
        public ActionResult Details(int? Id)
        {
            Item item = obj.Items.Find(Id);
            return View(item);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,ItemName,ItemCount")] Item item)
        {
            obj.Items.Add(item);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            Item item = obj.Items.Find(Id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ItemName,ItemCount")] Item item)
        {
            obj.Entry(item).State = EntityState.Modified;
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? Id)
        {
            Item item = obj.Items.Find(Id);
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
           Item item = obj.Items.Find(Id);
            obj.Items.Remove(item);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}