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
    public class TrainingsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Trainings
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
            {
                return View(db.CBS_Trainings.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_Trainings.Where(x => x.Approved == true && x.EmpID == userEmpId).ToList());
            }
        }

        // GET: Profile/Trainings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Trainings cBS_Trainings = db.CBS_Trainings.Find(id);
            if (cBS_Trainings == null)
            {
                return HttpNotFound();
            }

            if (cBS_Trainings.EmpID != CurrentUser.GetEmpID(this.Session, this.User) || User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Trainings);
        }

        // GET: Profile/Trainings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Trainings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Year,Course_Name,Training_Provider,External,Category,Training_Month,Time_Duration,Cost_Money,EmpID,Approved,EditedBy,TargetRowID")] CBS_Trainings cBS_Trainings)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
                {
                    cBS_Trainings.Approved = true;
                }
                else
                {
                    cBS_Trainings.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_Trainings.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_Trainings_Manage", "Trainings change requested", "Admin/DataApprove#CBS_Trainings");
                }
                db.CBS_Trainings.Add(cBS_Trainings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (cBS_Trainings.EmpID != CurrentUser.GetEmpID(this.Session, this.User) || User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Trainings);
        }

        // GET: Profile/Trainings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Trainings cBS_Trainings = db.CBS_Trainings.Find(id);
            if (cBS_Trainings == null)
            {
                return HttpNotFound();
            }

            if (cBS_Trainings.EmpID != CurrentUser.GetEmpID(this.Session, this.User) || User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Trainings);
        }

        // POST: Profile/Trainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Year,Course_Name,Training_Provider,External,Category,Training_Month,Time_Duration,Cost_Money,EmpID,Approved,EditedBy,TargetRowID")] CBS_Trainings cBS_Trainings)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
                {
                    cBS_Trainings.Approved = true;
                    db.Entry(cBS_Trainings).State = EntityState.Modified;
                }
                else
                {
                    cBS_Trainings.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_Trainings.Approved = false;
                    cBS_Trainings.TargetRowID = cBS_Trainings.ID;
                    cBS_Trainings.EditedBy = User.Identity.Name;
                    cBS_Trainings.ID = 0;
                    db.CBS_Trainings.Add(cBS_Trainings);
                    NotificationHub.NotificationHub.GroupNotify("CBS_Trainings_Manage", "Trainings change requested", "Admin/DataApprove#CBS_Trainings");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (cBS_Trainings.EmpID != CurrentUser.GetEmpID(this.Session, this.User) || User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Trainings);
        }

        // GET: Profile/Trainings/Delete/5
         [Authorize(Roles = "Admin, Manager, CBS_Trainings_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Trainings cBS_Trainings = db.CBS_Trainings.Find(id);
            if (cBS_Trainings == null)
            {
                return HttpNotFound();
            }

            if (cBS_Trainings.EmpID != CurrentUser.GetEmpID(this.Session, this.User) || User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Trainings);
        }

        // POST: Profile/Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_Trainings_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Trainings cBS_Trainings = db.CBS_Trainings.Find(id);
            db.CBS_Trainings.Remove(cBS_Trainings);
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
