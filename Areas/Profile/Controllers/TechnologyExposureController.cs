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
    public class TechnologyExposureController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/TechnologyExposure
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_TechnologyExposure_Manage"))
            {
                return View(db.CBS_TechnologyExposure.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_TechnologyExposure.Where(x => x.Approved == true && x.EmpID == userEmpId).ToList());
            }
        }

        // GET: Profile/TechnologyExposure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_TechnologyExposure cBS_TechnologyExposure = db.CBS_TechnologyExposure.Find(id);
            if (cBS_TechnologyExposure == null)
            {
                return HttpNotFound();
            }
            return View(cBS_TechnologyExposure);
        }

        // GET: Profile/TechnologyExposure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/TechnologyExposure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Date,Engagement,Technologies,EmpID,Approved,EditedBy,TargetRowID")] CBS_TechnologyExposure cBS_TechnologyExposure)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_TechnologyExposure_Manage"))
                {
                    cBS_TechnologyExposure.Approved = true;
                }
                else
                {
                    cBS_TechnologyExposure.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_TechnologyExposure_Manage", "TechnologyExposure change requested", "Admin/DataApprove#CBS_TechnologyExposure");
                }
                db.CBS_TechnologyExposure.Add(cBS_TechnologyExposure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_TechnologyExposure);
        }

        // GET: Profile/TechnologyExposure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_TechnologyExposure cBS_TechnologyExposure = db.CBS_TechnologyExposure.Find(id);
            if (cBS_TechnologyExposure == null)
            {
                return HttpNotFound();
            }
            return View(cBS_TechnologyExposure);
        }

        // POST: Profile/TechnologyExposure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Date,Engagement,Technologies,EmpID,Approved,EditedBy,TargetRowID")] CBS_TechnologyExposure cBS_TechnologyExposure)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_TechnologyExposure_Manage"))
                {
                    cBS_TechnologyExposure.Approved = true;
                    db.Entry(cBS_TechnologyExposure).State = EntityState.Modified;
                }
                else
                {
                    cBS_TechnologyExposure.Approved = false;
                    cBS_TechnologyExposure.TargetRowID = cBS_TechnologyExposure.ID;
                    cBS_TechnologyExposure.EditedBy = User.Identity.Name;
                    cBS_TechnologyExposure.ID = 0;
                    db.CBS_TechnologyExposure.Add(cBS_TechnologyExposure);
                    NotificationHub.NotificationHub.GroupNotify("CBS_TechnologyExposure_Manage", "TechnologyExposure change requested", "Admin/DataApprove#CBS_TechnologyExposure");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_TechnologyExposure);
        }

        // GET: Profile/TechnologyExposure/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_TechnologyExposure_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_TechnologyExposure cBS_TechnologyExposure = db.CBS_TechnologyExposure.Find(id);
            if (cBS_TechnologyExposure == null)
            {
                return HttpNotFound();
            }
            return View(cBS_TechnologyExposure);
        }

        // POST: Profile/TechnologyExposure/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_TechnologyExposure_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_TechnologyExposure cBS_TechnologyExposure = db.CBS_TechnologyExposure.Find(id);
            db.CBS_TechnologyExposure.Remove(cBS_TechnologyExposure);
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
