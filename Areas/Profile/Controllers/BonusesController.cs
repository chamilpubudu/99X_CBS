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
    public class BonusesController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Bonuses
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))
            {
                return View(db.CBS_Bonuses.ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_Bonuses.Where(x => x.EmpID == userEmpId).ToList());
            }
        }

        // GET: Profile/Bonuses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Bonuses cBS_Bonuses = db.CBS_Bonuses.Find(id);
            if (cBS_Bonuses == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Bonuses.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Bonuses);
        }

        // GET: Profile/Bonuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Bonuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Date,Bonus_Type,Bonus_Amount,EmpID,Approved,EditedBy,TargetRowID")] CBS_Bonuses cBS_Bonuses)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))
                {
                    cBS_Bonuses.Approved = true;
                }
                else
                {
                    cBS_Bonuses.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_Bonuses.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_Bonuses_Manage", "Bonuses change requested", "Admin/DataApprove#CBS_Bonuses");
                }
                db.CBS_Bonuses.Add(cBS_Bonuses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Bonuses.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Bonuses);
        }

        // GET: Profile/Bonuses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Bonuses cBS_Bonuses = db.CBS_Bonuses.Find(id);
            if (cBS_Bonuses == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Bonuses.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Bonuses);
        }

        // POST: Profile/Bonuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Date,Bonus_Type,Bonus_Amount,EmpID,Approved,EditedBy,TargetRowID")] CBS_Bonuses cBS_Bonuses)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))
                {
                    cBS_Bonuses.Approved = true;
                    db.Entry(cBS_Bonuses).State = EntityState.Modified;
                }
                else
                {
                    cBS_Bonuses.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_Bonuses.Approved = false;
                    cBS_Bonuses.TargetRowID = cBS_Bonuses.ID;
                    cBS_Bonuses.EditedBy = User.Identity.Name;
                    cBS_Bonuses.ID = 0;
                    db.CBS_Bonuses.Add(cBS_Bonuses);
                    NotificationHub.NotificationHub.GroupNotify("CBS_Bonuses_Manage", "Bonuses change requested", "Admin/DataApprove#CBS_Bonuses");
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Bonuses.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Bonuses);
        }

        // GET: Profile/Bonuses/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_Bonuses_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Bonuses cBS_Bonuses = db.CBS_Bonuses.Find(id);
            if (cBS_Bonuses == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Bonuses.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Bonuses);
        }

        // POST: Profile/Bonuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_Bonuses_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Bonuses cBS_Bonuses = db.CBS_Bonuses.Find(id);
            db.CBS_Bonuses.Remove(cBS_Bonuses);
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
