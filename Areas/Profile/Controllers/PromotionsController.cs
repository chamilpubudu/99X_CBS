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
    public class PromotionsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Promotions
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))
            {
                return View(db.CBS_Promotions.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_Promotions.Where(x => x.Approved == true && x.EmpID == userEmpId).ToList());
            }
        }

        // GET: Profile/Promotions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Promotions cBS_Promotions = db.CBS_Promotions.Find(id);
            if (cBS_Promotions == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Promotions.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Promotions);
        }

        // GET: Profile/Promotions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Promotions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Date,Promoted_To,Previous_Designation,EmpID,Approved,EditedBy,TargetRowID")] CBS_Promotions cBS_Promotions)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))
                {
                    cBS_Promotions.Approved = true;
                }
                else
                {
                    cBS_Promotions.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_Promotions.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_Promotions_Manage", "Promotions change requested", "Admin/DataApprove#CBS_Promotions");
                }
                db.CBS_Promotions.Add(cBS_Promotions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Promotions.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Promotions);
        }

        // GET: Profile/Promotions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Promotions cBS_Promotions = db.CBS_Promotions.Find(id);
            if (cBS_Promotions == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Promotions.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Promotions);
        }

        // POST: Profile/Promotions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Date,Promoted_To,Previous_Designation,EmpID,Approved,EditedBy,TargetRowID")] CBS_Promotions cBS_Promotions)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))
                {
                    cBS_Promotions.Approved = true;
                    db.Entry(cBS_Promotions).State = EntityState.Modified;
                }
                else
                {
                    cBS_Promotions.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_Promotions.Approved = false;
                    cBS_Promotions.TargetRowID = cBS_Promotions.ID;
                    cBS_Promotions.EditedBy = User.Identity.Name;
                    cBS_Promotions.ID = 0;
                    db.CBS_Promotions.Add(cBS_Promotions);
                    NotificationHub.NotificationHub.GroupNotify("CBS_Promotions_Manage", "Promotions change requested", "Admin/DataApprove#CBS_Promotions");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Promotions.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Promotions);
        }

        // GET: Profile/Promotions/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_Promotions_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Promotions cBS_Promotions = db.CBS_Promotions.Find(id);
            if (cBS_Promotions == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_Promotions.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_Promotions);
        }

        // POST: Profile/Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_Promotions_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Promotions cBS_Promotions = db.CBS_Promotions.Find(id);
            db.CBS_Promotions.Remove(cBS_Promotions);
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
