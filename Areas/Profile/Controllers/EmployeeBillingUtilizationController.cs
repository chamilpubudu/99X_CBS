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
    public class EmployeeBillingUtilizationController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/EmployeeBillingUtilization
        public ActionResult Index()
        {
            return View(db.CBS_EmployeeBillingUtilization.ToList());
        }

        // GET: Profile/EmployeeBillingUtilization/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_EmployeeBillingUtilization cBS_EmployeeBillingUtilization = db.CBS_EmployeeBillingUtilization.Find(id);
            if (cBS_EmployeeBillingUtilization == null)
            {
                return HttpNotFound();
            }
            return View(cBS_EmployeeBillingUtilization);
        }

        // GET: Profile/EmployeeBillingUtilization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/EmployeeBillingUtilization/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,From_Date,To_Date,Project,Billing_Utilization,EmpID,Approved,EditedBy,TargetRowID")] CBS_EmployeeBillingUtilization cBS_EmployeeBillingUtilization)
        {
            if (ModelState.IsValid)
            {
                db.CBS_EmployeeBillingUtilization.Add(cBS_EmployeeBillingUtilization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_EmployeeBillingUtilization);
        }

        // GET: Profile/EmployeeBillingUtilization/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_EmployeeBillingUtilization cBS_EmployeeBillingUtilization = db.CBS_EmployeeBillingUtilization.Find(id);
            if (cBS_EmployeeBillingUtilization == null)
            {
                return HttpNotFound();
            }
            return View(cBS_EmployeeBillingUtilization);
        }

        // POST: Profile/EmployeeBillingUtilization/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,From_Date,To_Date,Project,Billing_Utilization,EmpID,Approved,EditedBy,TargetRowID")] CBS_EmployeeBillingUtilization cBS_EmployeeBillingUtilization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_EmployeeBillingUtilization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_EmployeeBillingUtilization);
        }

        // GET: Profile/EmployeeBillingUtilization/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_EmployeeBillingUtilization cBS_EmployeeBillingUtilization = db.CBS_EmployeeBillingUtilization.Find(id);
            if (cBS_EmployeeBillingUtilization == null)
            {
                return HttpNotFound();
            }
            return View(cBS_EmployeeBillingUtilization);
        }

        // POST: Profile/EmployeeBillingUtilization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_EmployeeBillingUtilization cBS_EmployeeBillingUtilization = db.CBS_EmployeeBillingUtilization.Find(id);
            db.CBS_EmployeeBillingUtilization.Remove(cBS_EmployeeBillingUtilization);
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
