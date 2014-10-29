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
    public class MentorBuddyController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/MentorBuddy
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))
            {
                return View(db.CBS_MentorBuddy.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_MentorBuddy.Where(x => x.Approved == true && x.EmpID == userEmpId).ToList());
            }
        }

        // GET: Profile/MentorBuddy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_MentorBuddy cBS_MentorBuddy = db.CBS_MentorBuddy.Find(id);
            if (cBS_MentorBuddy == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_MentorBuddy.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_MentorBuddy);
        }

        // GET: Profile/MentorBuddy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/MentorBuddy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Date,Mentor_or_Buddy_Type,Mentor_or_Buddy,EmpID,Approved,EditedBy,TargetRowID")] CBS_MentorBuddy cBS_MentorBuddy)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))
                {
                    cBS_MentorBuddy.Approved = true;
                }
                else
                {
                    cBS_MentorBuddy.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_MentorBuddy.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_MentorBuddy_Manage", "MentorBuddy change requested", "Admin/DataApprove#CBS_MentorBuddy");
                }
                db.CBS_MentorBuddy.Add(cBS_MentorBuddy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_MentorBuddy.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_MentorBuddy);
        }

        // GET: Profile/MentorBuddy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_MentorBuddy cBS_MentorBuddy = db.CBS_MentorBuddy.Find(id);
            if (cBS_MentorBuddy == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_MentorBuddy.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_MentorBuddy);
        }

        // POST: Profile/MentorBuddy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Date,Mentor_or_Buddy_Type,Mentor_or_Buddy,EmpID,Approved,EditedBy,TargetRowID")] CBS_MentorBuddy cBS_MentorBuddy)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))
                {
                    cBS_MentorBuddy.Approved = true;
                    db.Entry(cBS_MentorBuddy).State = EntityState.Modified;
                }
                else
                {
                    cBS_MentorBuddy.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_MentorBuddy.Approved = false;
                    cBS_MentorBuddy.TargetRowID = cBS_MentorBuddy.ID;
                    cBS_MentorBuddy.EditedBy = User.Identity.Name;
                    cBS_MentorBuddy.ID = 0;
                    db.CBS_MentorBuddy.Add(cBS_MentorBuddy);
                    NotificationHub.NotificationHub.GroupNotify("CBS_MentorBuddy_Manage", "MentorBuddy change requested", "Admin/DataApprove#CBS_MentorBuddy");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_MentorBuddy.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_MentorBuddy);
        }

        // GET: Profile/MentorBuddy/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_MentorBuddy_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_MentorBuddy cBS_MentorBuddy = db.CBS_MentorBuddy.Find(id);
            if (cBS_MentorBuddy == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_MentorBuddy.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_MentorBuddy);
        }

        // POST: Profile/MentorBuddy/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_MentorBuddy_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_MentorBuddy cBS_MentorBuddy = db.CBS_MentorBuddy.Find(id);
            db.CBS_MentorBuddy.Remove(cBS_MentorBuddy);
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
