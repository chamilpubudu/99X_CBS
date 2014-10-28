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
    public class AwardsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Awards
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Awards_Manage"))
            {
                return View(db.CBS_Awards.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_Awards.Where(x => x.Approved == true && x.EmpID == userEmpId).ToList());
            }
        }

        // GET: Profile/Awards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Awards cBS_Awards = db.CBS_Awards.Find(id);
            if (cBS_Awards == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Awards);
        }

        // GET: Profile/Awards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Awards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Award_Date,Award,EmpID,Approved,EditedBy,TargetRowID")] CBS_Awards cBS_Awards)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Awards_Manage"))
                {
                    cBS_Awards.Approved = true;
                }
                else
                {
                    cBS_Awards.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_Awards.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_Awards_Manage", "Awards change requested", "Admin/DataApprove#CBS_Awards");
                }
                db.CBS_Awards.Add(cBS_Awards);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_Awards);
        }

        // GET: Profile/Awards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Awards cBS_Awards = db.CBS_Awards.Find(id);
            if (cBS_Awards == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Awards);
        }

        // POST: Profile/Awards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Award_Date,Award,EmpID,Approved,EditedBy,TargetRowID")] CBS_Awards cBS_Awards)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Awards_Manage"))
                {
                    cBS_Awards.Approved = true;
                    db.Entry(cBS_Awards).State = EntityState.Modified;
                }
                else
                {
                    cBS_Awards.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_Awards.Approved = false;
                    cBS_Awards.TargetRowID = cBS_Awards.ID;
                    cBS_Awards.EditedBy = User.Identity.Name;
                    cBS_Awards.ID = 0;
                    db.CBS_Awards.Add(cBS_Awards);
                    NotificationHub.NotificationHub.GroupNotify("CBS_Awards_Manage", "Awards change requested", "Admin/DataApprove#CBS_Awards");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_Awards);
        }

        // GET: Profile/Awards/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_Awards_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Awards cBS_Awards = db.CBS_Awards.Find(id);
            if (cBS_Awards == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Awards);
        }

        // POST: Profile/Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_Awards_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Awards cBS_Awards = db.CBS_Awards.Find(id);
            db.CBS_Awards.Remove(cBS_Awards);
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
