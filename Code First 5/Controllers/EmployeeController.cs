using Code_First_5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_First_5.Controllers
{
    public class EmployeeController : Controller
    {
        private Cmns obj = new Cmns();
        public ActionResult Index()
        {
            var data = from n in obj.Employees select n;
            return View(data.ToList());

        }
        public ActionResult Details(int? Id)
        {
            Employee employee = obj.Employees.Find(Id);
            return View(employee);
        }
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(obj.Items, "ItemId", "ItemName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            obj.Employees.Add(employee);
            obj.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int Id)
        {
            Employee employee = obj.Employees.Find(Id);
            ViewBag.ItemId = new SelectList(obj.Items, "ItemId", "ItemName", employee.ItemId);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            obj.Entry(employee).State = EntityState.Modified;
            obj.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int? Id)
        {
            Employee employee = obj.Employees.Find(Id);
            return View(employee);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = obj.Employees.Find(id);
            obj.Employees.Remove(employee);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}