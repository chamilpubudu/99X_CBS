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
    public class UniversitySessionsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/UniversitySessions
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_UniversitySessions_Manage"))
            {
                return View(db.CBS_UniversitySessions.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_UniversitySessions.Where(x => x.Approved == true && x.EmpID == userEmpId).ToList());
            }
        }

        // GET: Profile/UniversitySessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_UniversitySessions cBS_UniversitySessions = db.CBS_UniversitySessions.Find(id);
            if (cBS_UniversitySessions == null)
            {
                return HttpNotFound();
            }
            return View(cBS_UniversitySessions);
        }

        // GET: Profile/UniversitySessions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/UniversitySessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Session_Date,Initiated_By,Location,Number_Of_Participants,Participants,Session_Type,Time_Duration,Topic,To_the_University,EmpID,Approved,EditedBy,TargetRowID")] CBS_UniversitySessions cBS_UniversitySessions)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_UniversitySessions_Manage"))
                {
                    cBS_UniversitySessions.Approved = true;
                }
                else
                {
                    cBS_UniversitySessions.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_UniversitySessions_Manage", "UniversitySessions change requested", "Admin/DataApprove#CBS_UniversitySessions");
                }
                db.CBS_UniversitySessions.Add(cBS_UniversitySessions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_UniversitySessions);
        }

        // GET: Profile/UniversitySessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_UniversitySessions cBS_UniversitySessions = db.CBS_UniversitySessions.Find(id);
            if (cBS_UniversitySessions == null)
            {
                return HttpNotFound();
            }
            return View(cBS_UniversitySessions);
        }

        // POST: Profile/UniversitySessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Session_Date,Initiated_By,Location,Number_Of_Participants,Participants,Session_Type,Time_Duration,Topic,To_the_University,EmpID,Approved,EditedBy,TargetRowID")] CBS_UniversitySessions cBS_UniversitySessions)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_UniversitySessions_Manage"))
                {
                    cBS_UniversitySessions.Approved = true;
                    db.Entry(cBS_UniversitySessions).State = EntityState.Modified;
                }
                else
                {
                    cBS_UniversitySessions.Approved = false;
                    cBS_UniversitySessions.TargetRowID = cBS_UniversitySessions.ID;
                    cBS_UniversitySessions.EditedBy = User.Identity.Name;
                    cBS_UniversitySessions.ID = 0;
                    db.CBS_UniversitySessions.Add(cBS_UniversitySessions);
                    NotificationHub.NotificationHub.GroupNotify("CBS_UniversitySessions_Manage", "UniversitySessions change requested", "Admin/DataApprove#CBS_UniversitySessions");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_UniversitySessions);
        }

        // GET: Profile/UniversitySessions/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_UniversitySessions_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_UniversitySessions cBS_UniversitySessions = db.CBS_UniversitySessions.Find(id);
            if (cBS_UniversitySessions == null)
            {
                return HttpNotFound();
            }
            return View(cBS_UniversitySessions);
        }

        // POST: Profile/UniversitySessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_UniversitySessions_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_UniversitySessions cBS_UniversitySessions = db.CBS_UniversitySessions.Find(id);
            db.CBS_UniversitySessions.Remove(cBS_UniversitySessions);
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
