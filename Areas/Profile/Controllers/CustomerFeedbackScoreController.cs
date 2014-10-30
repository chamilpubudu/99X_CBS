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
    public class CustomerFeedbackScoreController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/CustomerFeedbackScore
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))
            {
                return View(db.CBS_CustomerFeedbackScore.ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_CustomerFeedbackScore.Where(x =>x.EmpID == userEmpId).ToList());
            }
        }

        // GET: Profile/CustomerFeedbackScore/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_CustomerFeedbackScore cBS_CustomerFeedbackScore = db.CBS_CustomerFeedbackScore.Find(id);
            if (cBS_CustomerFeedbackScore == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_CustomerFeedbackScore.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_CustomerFeedbackScore);
        }

        // GET: Profile/CustomerFeedbackScore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/CustomerFeedbackScore/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Feedback_Date,Score,Comments,EmpID,Approved,EditedBy,TargetRowID")] CBS_CustomerFeedbackScore cBS_CustomerFeedbackScore)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))
                {
                    cBS_CustomerFeedbackScore.Approved = true;
                }
                else
                {
                    cBS_CustomerFeedbackScore.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_CustomerFeedbackScore.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_CustomerFeedbackScore_Manage", "CustomerFeedbackScore change requested", "Admin/DataApprove#CBS_CustomerFeedbackScore");
                }
                db.CBS_CustomerFeedbackScore.Add(cBS_CustomerFeedbackScore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_CustomerFeedbackScore.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_CustomerFeedbackScore);
        }

        // GET: Profile/CustomerFeedbackScore/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_CustomerFeedbackScore cBS_CustomerFeedbackScore = db.CBS_CustomerFeedbackScore.Find(id);
            if (cBS_CustomerFeedbackScore == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_CustomerFeedbackScore.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_CustomerFeedbackScore);
        }

        // POST: Profile/CustomerFeedbackScore/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Feedback_Date,Score,Comments,EmpID,Approved,EditedBy,TargetRowID")] CBS_CustomerFeedbackScore cBS_CustomerFeedbackScore)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))
                {
                    cBS_CustomerFeedbackScore.Approved = true;
                    db.Entry(cBS_CustomerFeedbackScore).State = EntityState.Modified;
                }
                else
                {
                    cBS_CustomerFeedbackScore.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cBS_CustomerFeedbackScore.Approved = false;
                    cBS_CustomerFeedbackScore.TargetRowID = cBS_CustomerFeedbackScore.ID;
                    cBS_CustomerFeedbackScore.EditedBy = User.Identity.Name;
                    cBS_CustomerFeedbackScore.ID = 0;
                    db.CBS_CustomerFeedbackScore.Add(cBS_CustomerFeedbackScore);
                    NotificationHub.NotificationHub.GroupNotify("CBS_CustomerFeedbackScore_Manage", "CustomerFeedbackScore change requested", "Admin/DataApprove#CBS_CustomerFeedbackScore");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_CustomerFeedbackScore.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_CustomerFeedbackScore);
        }

        // GET: Profile/CustomerFeedbackScore/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_CustomerFeedbackScore_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_CustomerFeedbackScore cBS_CustomerFeedbackScore = db.CBS_CustomerFeedbackScore.Find(id);
            if (cBS_CustomerFeedbackScore == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cBS_CustomerFeedbackScore.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cBS_CustomerFeedbackScore);
        }

        // POST: Profile/CustomerFeedbackScore/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_CustomerFeedbackScore_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_CustomerFeedbackScore cBS_CustomerFeedbackScore = db.CBS_CustomerFeedbackScore.Find(id);
            db.CBS_CustomerFeedbackScore.Remove(cBS_CustomerFeedbackScore);
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
