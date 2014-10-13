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
    public class EmployeesController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Employees
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Employees_Manage"))
            {
                return View(db.CBS_Employees.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userId = User.Identity.GetUserId();
                return View(db.CBS_Employees.Where(x => x.Approved == true && x.EmpID == userId).ToList());
            }
        }

        // GET: Profile/Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Employees cBS_Employees = db.CBS_Employees.Find(id);
            if (cBS_Employees == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Employees);
        }

        // GET: Profile/Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Designation,Date_Joined,Career_Started_On,Appraisal_Score,EmpID,Approved,EditedBy,TargetRowID")] CBS_Employees cBS_Employees)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Employees_Manage"))
                {
                    cBS_Employees.Approved = true;
                }
                else
                {
                    cBS_Employees.Approved = false;
                }
                db.CBS_Employees.Add(cBS_Employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_Employees);
        }

        // GET: Profile/Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Employees cBS_Employees = db.CBS_Employees.Find(id);
            if (cBS_Employees == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Employees);
        }

        // POST: Profile/Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Designation,Date_Joined,Career_Started_On,Appraisal_Score,EmpID,Approved,EditedBy,TargetRowID")] CBS_Employees cBS_Employees)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Employees_Manage"))
                {
                    cBS_Employees.Approved = true;
                    db.Entry(cBS_Employees).State = EntityState.Modified;
                }
                else
                {
                    cBS_Employees.Approved = false;
                    cBS_Employees.TargetRowID = cBS_Employees.ID;
                    cBS_Employees.EditedBy = User.Identity.Name;
                    cBS_Employees.ID = 0;
                    db.CBS_Employees.Add(cBS_Employees);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_Employees);
        }

        // GET: Profile/Employees/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_Employees_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Employees cBS_Employees = db.CBS_Employees.Find(id);
            if (cBS_Employees == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Employees);
        }

        // POST: Profile/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_Employees_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Employees cBS_Employees = db.CBS_Employees.Find(id);
            db.CBS_Employees.Remove(cBS_Employees);
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
