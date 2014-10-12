using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _99X_CBS.Models;

namespace _99X_CBS.Areas.Profile.Controllers
{
    public class FuelAllowancesController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/FuelAllowances
        public ActionResult Index()
        {
            return View(db.CBS_FuelAllowances.ToList());
        }

        // GET: Profile/FuelAllowances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_FuelAllowances cBS_FuelAllowances = db.CBS_FuelAllowances.Find(id);
            if (cBS_FuelAllowances == null)
            {
                return HttpNotFound();
            }
            return View(cBS_FuelAllowances);
        }

        // GET: Profile/FuelAllowances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/FuelAllowances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Fueling_Date,Number_Of_Liters,Amount,EmpID,Approved,EditedBy,TargetRowID")] CBS_FuelAllowances cBS_FuelAllowances)
        {
            if (ModelState.IsValid)
            {
                db.CBS_FuelAllowances.Add(cBS_FuelAllowances);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_FuelAllowances);
        }

        // GET: Profile/FuelAllowances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_FuelAllowances cBS_FuelAllowances = db.CBS_FuelAllowances.Find(id);
            if (cBS_FuelAllowances == null)
            {
                return HttpNotFound();
            }
            return View(cBS_FuelAllowances);
        }

        // POST: Profile/FuelAllowances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Fueling_Date,Number_Of_Liters,Amount,EmpID,Approved,EditedBy,TargetRowID")] CBS_FuelAllowances cBS_FuelAllowances)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_FuelAllowances).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_FuelAllowances);
        }

        // GET: Profile/FuelAllowances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_FuelAllowances cBS_FuelAllowances = db.CBS_FuelAllowances.Find(id);
            if (cBS_FuelAllowances == null)
            {
                return HttpNotFound();
            }
            return View(cBS_FuelAllowances);
        }

        // POST: Profile/FuelAllowances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_FuelAllowances cBS_FuelAllowances = db.CBS_FuelAllowances.Find(id);
            db.CBS_FuelAllowances.Remove(cBS_FuelAllowances);
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
