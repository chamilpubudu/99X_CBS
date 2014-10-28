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
    public class ValueInnovationsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/ValueInnovations
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
            {
                return View(db.CBS_ValueInnovations.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_ValueInnovations.Where(x => x.Approved == true && x.EmpID == userEmpId).ToList());
            }

        }

        // GET: Profile/ValueInnovations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_ValueInnovations cBS_ValueInnovations = db.CBS_ValueInnovations.Find(id);
            if (cBS_ValueInnovations == null)
            {
                return HttpNotFound();
            }

            if (cBS_ValueInnovations.EmpID != CurrentUser.GetEmpID(this.Session, this.User) || User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_ValueInnovations);
        }

        // GET: Profile/ValueInnovations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/ValueInnovations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Innovation_Date,Value_Innovation,EmpID,Approved,EditedBy,TargetRowID")] CBS_ValueInnovations cBS_ValueInnovations)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
                {
                    cBS_ValueInnovations.Approved = true;
                }
                else
                {
                    cBS_ValueInnovations.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_ValueInnovations.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_ValueInnovations_Manage", "ValueInnovations change requested", "Admin/DataApprove#CBS_ValueInnovations");
                }
                db.CBS_ValueInnovations.Add(cBS_ValueInnovations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (cBS_ValueInnovations.EmpID != CurrentUser.GetEmpID(this.Session, this.User) || User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_ValueInnovations);
        }

        // GET: Profile/ValueInnovations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_ValueInnovations cBS_ValueInnovations = db.CBS_ValueInnovations.Find(id);
            if (cBS_ValueInnovations == null)
            {
                return HttpNotFound();
            }

            if (cBS_ValueInnovations.EmpID != CurrentUser.GetEmpID(this.Session, this.User) || User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_ValueInnovations);
        }

        // POST: Profile/ValueInnovations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Innovation_Date,Value_Innovation,EmpID,Approved,EditedBy,TargetRowID")] CBS_ValueInnovations cBS_ValueInnovations)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
                {
                    cBS_ValueInnovations.Approved = true;
                    db.Entry(cBS_ValueInnovations).State = EntityState.Modified;
                }
                else
                {
                    cBS_ValueInnovations.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_ValueInnovations.Approved = false;
                    cBS_ValueInnovations.TargetRowID = cBS_ValueInnovations.ID;
                    cBS_ValueInnovations.EditedBy = User.Identity.Name;
                    cBS_ValueInnovations.ID = 0;
                    db.CBS_ValueInnovations.Add(cBS_ValueInnovations);
                    NotificationHub.NotificationHub.GroupNotify("CBS_ValueInnovations_Manage", "ValueInnovations change requested", "Admin/DataApprove#CBS_ValueInnovations");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (cBS_ValueInnovations.EmpID != CurrentUser.GetEmpID(this.Session, this.User) || User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_ValueInnovations);
        }

        // GET: Profile/ValueInnovations/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_ValueInnovations_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_ValueInnovations cBS_ValueInnovations = db.CBS_ValueInnovations.Find(id);
            if (cBS_ValueInnovations == null)
            {
                return HttpNotFound();
            }

            if (cBS_ValueInnovations.EmpID != CurrentUser.GetEmpID(this.Session, this.User) || User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_ValueInnovations);
        }

        // POST: Profile/ValueInnovations/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_ValueInnovations_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_ValueInnovations cBS_ValueInnovations = db.CBS_ValueInnovations.Find(id);
            db.CBS_ValueInnovations.Remove(cBS_ValueInnovations);
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
