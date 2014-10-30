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
    public class FuelAllowancesController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/FuelAllowances
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))
            {
                return View(db.CBS_FuelAllowances.ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_FuelAllowances.Where(x => x.EmpID == userEmpId).ToList());
            }
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

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_FuelAllowances.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))
                {
                    cBS_FuelAllowances.Approved = true;
                }
                else
                {
                    cBS_FuelAllowances.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_FuelAllowances.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_FuelAllowances_Manage", "FuelAllowances change requested", "Admin/DataApprove#CBS_FuelAllowances");
                }
                db.CBS_FuelAllowances.Add(cBS_FuelAllowances);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_FuelAllowances.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_FuelAllowances.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))
                {
                    cBS_FuelAllowances.Approved = true;
                    db.Entry(cBS_FuelAllowances).State = EntityState.Modified;
                }
                else
                {
                    cBS_FuelAllowances.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_FuelAllowances.Approved = false;
                    cBS_FuelAllowances.TargetRowID = cBS_FuelAllowances.ID;
                    cBS_FuelAllowances.EditedBy = User.Identity.Name;
                    cBS_FuelAllowances.ID = 0;
                    db.CBS_FuelAllowances.Add(cBS_FuelAllowances);
                    NotificationHub.NotificationHub.GroupNotify("CBS_FuelAllowances_Manage", "FuelAllowances change requested", "Admin/DataApprove#CBS_FuelAllowances");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_FuelAllowances.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_FuelAllowances);
        }

        // GET: Profile/FuelAllowances/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_FuelAllowances_Manage")]
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

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_FuelAllowances.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_FuelAllowances);
        }

        // POST: Profile/FuelAllowances/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_FuelAllowances_Manage")]
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
