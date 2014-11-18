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
    public class BenefitsController : Controller
    {
        private Entities db = new Entities();

        // GET: /Profile/Benefits/
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))
            {
                return View(db.CBS_Benefits.ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_Benefits.Where(x => x.EmpID == userEmpId).ToList());
            }
        }

        // GET: /Profile/Benefits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Benefits cbs_benefits = db.CBS_Benefits.Find(id);
            if (cbs_benefits == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_benefits.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_benefits);
        }

        // GET: /Profile/Benefits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Profile/Benefits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Employee_Name,Date,Name,EmpID,Approved,EditedBy,TargetRowID")] CBS_Benefits cbs_benefits)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))
                {
                    cbs_benefits.Approved = true;
                }
                else
                {
                    cbs_benefits.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cbs_benefits.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_Attendances_Manage", "Attendance change requested", "Admin/DataApprove#CBS_Attendances");//Need to change
                }
                db.CBS_Benefits.Add(cbs_benefits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_benefits.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_benefits);
        }

        // GET: /Profile/Benefits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CBS_Benefits cbs_benefits = db.CBS_Benefits.Find(id);
            if (cbs_benefits == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_benefits.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_benefits);
        }

        // POST: /Profile/Benefits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Employee_Name,Date,Name,EmpID,Approved,EditedBy,TargetRowID")] CBS_Benefits cbs_benefits)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))
                {
                    cbs_benefits.Approved = true;
                    db.Entry(cbs_benefits).State = EntityState.Modified;
                }
                else
                {
                    cbs_benefits.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cbs_benefits.Approved = false;
                    cbs_benefits.TargetRowID = cbs_benefits.ID;
                    cbs_benefits.EditedBy = User.Identity.Name;
                    cbs_benefits.ID = 0;
                    db.CBS_Benefits.Add(cbs_benefits);
                    NotificationHub.NotificationHub.GroupNotify("CBS_Attendances_Manage", "Attendance change requested", "Admin/DataApprove#CBS_Attendances"); // need to change the entire else block
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_benefits.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_benefits);
        }

        // GET: /Profile/Benefits/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_Attendances_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CBS_Benefits cbs_benefits = db.CBS_Benefits.Find(id);
            if (cbs_benefits == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_benefits.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_benefits);
        }

        // POST: /Profile/Benefits/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_Attendances_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Benefits cbs_benefits = db.CBS_Benefits.Find(id);
            db.CBS_Benefits.Remove(cbs_benefits);
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
