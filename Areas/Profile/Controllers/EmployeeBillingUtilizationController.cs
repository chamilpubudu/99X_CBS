using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _99X_CBS.Models;
using Microsoft.AspNet.Identity;

namespace _99X_CBS.Areas.Profile.Controllers
{
    [Authorize]
    public class EmployeeBillingUtilizationController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/EmployeeBillingUtilization
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_EmployeeBillingUtilization_Manage"))
            {
                return View(db.CBS_EmployeeBillingUtilization.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_EmployeeBillingUtilization.Where(x => x.Approved == true && x.EmpID == userEmpId).ToList());
            }
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
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_EmployeeBillingUtilization_Manage"))
                {
                    cBS_EmployeeBillingUtilization.Approved = true;
                }
                else
                {
                    cBS_EmployeeBillingUtilization.Approved = false;
                }
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
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_EmployeeBillingUtilization_Manage"))
                {
                    cBS_EmployeeBillingUtilization.Approved = true;
                    db.Entry(cBS_EmployeeBillingUtilization).State = EntityState.Modified;
                }
                else
                {
                    cBS_EmployeeBillingUtilization.Approved = false;
                    cBS_EmployeeBillingUtilization.TargetRowID = cBS_EmployeeBillingUtilization.ID;
                    cBS_EmployeeBillingUtilization.EditedBy = User.Identity.Name;
                    cBS_EmployeeBillingUtilization.ID = 0;
                    db.CBS_EmployeeBillingUtilization.Add(cBS_EmployeeBillingUtilization);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_EmployeeBillingUtilization);
        }

        // GET: Profile/EmployeeBillingUtilization/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_EmployeeBillingUtilization_Manage")]
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
        [Authorize(Roles = "Admin, Manager, CBS_EmployeeBillingUtilization_Manage")]
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
