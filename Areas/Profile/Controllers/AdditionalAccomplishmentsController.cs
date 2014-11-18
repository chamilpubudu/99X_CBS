using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _99X_CBS.Models;

namespace _99X_CBS.Areas.Profile.Controllers
{
    public class AdditionalAccomplishmentsController : Controller
    {
        private Entities db = new Entities();

        // GET: /Profile/AdditionalAccomplishments/
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_AdditionalAccomplishments_Manage"))
            {
                return View(db.CBS_AdditionalAccomplishments.ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_Attendances.Where(x => x.EmpID == userEmpId).ToList());
            }           
        }

        // GET: /Profile/AdditionalAccomplishments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_AdditionalAccomplishments cbs_additionalaccomplishments = db.CBS_AdditionalAccomplishments.Find(id);
            if (cbs_additionalaccomplishments == null)
            {
                return HttpNotFound();
            }
            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_additionalaccomplishments.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_AdditionalAccomplishments_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(cbs_additionalaccomplishments);
        }

        // GET: /Profile/AdditionalAccomplishments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Profile/AdditionalAccomplishments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Employee_Name,Accomplishment_Date,AccomplishmentName,EmpID,Approved,EditedBy,TargetRowID")] CBS_AdditionalAccomplishments cbs_additionalaccomplishments)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Attendances_Manage"))
                {
                    cbs_additionalaccomplishments.Approved = true;
                }
                else
                {
                    cbs_additionalaccomplishments.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cbs_additionalaccomplishments.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_Attendances_Manage", "Attendance change requested", "Admin/DataApprove#CBS_Attendances");//needs to be changed
                }
                db.CBS_AdditionalAccomplishments.Add(cbs_additionalaccomplishments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_additionalaccomplishments.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_AdditionalAccomplishments_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_additionalaccomplishments);
        }

        // GET: /Profile/AdditionalAccomplishments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_AdditionalAccomplishments cbs_additionalaccomplishments = db.CBS_AdditionalAccomplishments.Find(id);
            if (cbs_additionalaccomplishments == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_additionalaccomplishments.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_AdditionalAccomplishments_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(cbs_additionalaccomplishments);
        }

        // POST: /Profile/AdditionalAccomplishments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Employee_Name,Accomplishment_Date,AccomplishmentName,EmpID,Approved,EditedBy,TargetRowID")] CBS_AdditionalAccomplishments cbs_additionalaccomplishments)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Attendances_Manage"))
                {
                    cbs_additionalaccomplishments.Approved = true;
                    db.Entry(cbs_additionalaccomplishments).State = EntityState.Modified;
                }
                else
                {
                    cbs_additionalaccomplishments.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cbs_additionalaccomplishments.Approved = false;
                    cbs_additionalaccomplishments.TargetRowID = cbs_additionalaccomplishments.ID;
                    cbs_additionalaccomplishments.EditedBy = User.Identity.Name;
                    cbs_additionalaccomplishments.ID = 0;
                    db.CBS_AdditionalAccomplishments.Add(cbs_additionalaccomplishments);
                    NotificationHub.NotificationHub.GroupNotify("CBS_Attendances_Manage", "Attendance change requested", "Admin/DataApprove#CBS_Attendances");//this else condition needs to be changed
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_additionalaccomplishments.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_AdditionalAccomplishments_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_additionalaccomplishments);
        }

        // GET: /Profile/AdditionalAccomplishments/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_AdditionalAccomplishments_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_AdditionalAccomplishments cbs_additionalaccomplishments = db.CBS_AdditionalAccomplishments.Find(id);
            if (cbs_additionalaccomplishments == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_additionalaccomplishments.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_AdditionalAccomplishments_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(cbs_additionalaccomplishments);
        }

        // POST: /Profile/AdditionalAccomplishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_AdditionalAccomplishments_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_AdditionalAccomplishments cbs_additionalaccomplishments = db.CBS_AdditionalAccomplishments.Find(id);
            db.CBS_AdditionalAccomplishments.Remove(cbs_additionalaccomplishments);
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
