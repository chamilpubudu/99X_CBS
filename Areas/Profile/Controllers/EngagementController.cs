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
    public class EngagementController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Engagement
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))
            {
                return View(db.CBS_Engagement.ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_Engagement.Where(x => x.EmpID == userEmpId).ToList());
            }
        }

        // GET: Profile/Engagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Engagement cBS_Engagement = db.CBS_Engagement.Find(id);
            if (cBS_Engagement == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Engagement.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Engagement);
        }

        // GET: Profile/Engagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Engagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Date,Event,EmpID,Approved,EditedBy,TargetRowID")] CBS_Engagement cBS_Engagement)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))
                {
                    cBS_Engagement.Approved = true;
                }
                else
                {
                    cBS_Engagement.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_Engagement.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_Engagement_Manage", "Engagement change requested", "Admin/DataApprove#CBS_Engagement");
                }
                db.CBS_Engagement.Add(cBS_Engagement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Engagement.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Engagement);
        }

        // GET: Profile/Engagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Engagement cBS_Engagement = db.CBS_Engagement.Find(id);
            if (cBS_Engagement == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Engagement.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Engagement);
        }

        // POST: Profile/Engagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Date,Event,EmpID,Approved,EditedBy,TargetRowID")] CBS_Engagement cBS_Engagement)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))
                {
                    cBS_Engagement.Approved = true;
                    db.Entry(cBS_Engagement).State = EntityState.Modified;
                }
                else
                {
                    cBS_Engagement.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_Engagement.Approved = false;
                    cBS_Engagement.TargetRowID = cBS_Engagement.ID;
                    cBS_Engagement.EditedBy = User.Identity.Name;
                    cBS_Engagement.ID = 0;
                    db.CBS_Engagement.Add(cBS_Engagement);
                    NotificationHub.NotificationHub.GroupNotify("CBS_Engagement_Manage", "Engagement change requested", "Admin/DataApprove#CBS_Engagement");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Engagement.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Engagement);
        }

        // GET: Profile/Engagement/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_Engagement_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Engagement cBS_Engagement = db.CBS_Engagement.Find(id);
            if (cBS_Engagement == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Engagement.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            
            return View(cBS_Engagement);
        }

        // POST: Profile/Engagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_Engagement_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Engagement cBS_Engagement = db.CBS_Engagement.Find(id);
            db.CBS_Engagement.Remove(cBS_Engagement);
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
