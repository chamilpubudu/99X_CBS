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
    public class SalaryInformationController : Controller
    {
        private Entities db = new Entities();

        // GET: /Profile/SalaryInformation/
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_SalaryInformation_Manage"))
            {
                return View(db.CBS_SalaryInformation.ToList());
            }
            else
            {
                String userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_SalaryInformation.Where(x => x.EmpID == userEmpId).ToList());
            }
        }

        // GET: /Profile/SalaryInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_SalaryInformation cbs_salaryinformation = db.CBS_SalaryInformation.Find(id);
            if (cbs_salaryinformation == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_salaryinformation.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_SalaryInformation_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_salaryinformation);

        }

        // GET: /Profile/SalaryInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Profile/SalaryInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Employee_Name,Date,CurrentSalaryAmount,EPF,ETF,EmpID,Approved,EditedBy,TargetRowID")] CBS_SalaryInformation cbs_salaryinformation)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Attendances_Manage"))
                {
                    cbs_salaryinformation.Approved = true;
                }

                else
                {
                    cbs_salaryinformation.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cbs_salaryinformation.Approved = false;
                    NotificationHub.NotificationHub.GroupNotify("CBS_Attendances_Manage", "Attendance change requested", "Admin/DataApprove#CBS_Attendances"); //Need to change here
                }
                db.CBS_SalaryInformation.Add(cbs_salaryinformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_salaryinformation.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_SalaryInformation_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_salaryinformation);
        }

        // GET: /Profile/SalaryInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_SalaryInformation cbs_salaryinformation = db.CBS_SalaryInformation.Find(id);
            if (cbs_salaryinformation == null)
            {
                return HttpNotFound();
            }
            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_salaryinformation.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_SalaryInformation_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(cbs_salaryinformation);
        }

        // POST: /Profile/SalaryInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Employee_Name,Date,CurrentSalaryAmount,EPF,ETF,EmpID,Approved,EditedBy,TargetRowID")] CBS_SalaryInformation cbs_salaryinformation)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_SalaryInformation_Manage"))
                {
                    cbs_salaryinformation.Approved = true;
                    db.Entry(cbs_salaryinformation).State = EntityState.Modified;
                }
                else
                {
                    cbs_salaryinformation.EmpID = CurrentUser.GetEmpID(this.Session, this.User);
                    cbs_salaryinformation.Approved = false;
                    cbs_salaryinformation.TargetRowID = cbs_salaryinformation.ID;
                    cbs_salaryinformation.EditedBy = User.Identity.Name;
                    cbs_salaryinformation.ID = 0;
                    db.CBS_SalaryInformation.Add(cbs_salaryinformation);
                    //NotificationHub.NotificationHub.GroupNotify("CBS_Attendances_Manage", "Attendance change requested", "Admin/DataApprove#CBS_Attendances");
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_salaryinformation.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_SalaryInformation_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_salaryinformation);
        }

        // GET: /Profile/SalaryInformation/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_SalaryInformation_Manage")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_SalaryInformation cbs_salaryinformation = db.CBS_SalaryInformation.Find(id);
            if (cbs_salaryinformation == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_salaryinformation.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_SalaryInformation_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_salaryinformation);
        }

        // POST: /Profile/SalaryInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Manager, CBS_SalaryInformation_Manage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_SalaryInformation cbs_salaryinformation = db.CBS_SalaryInformation.Find(id);
            db.CBS_SalaryInformation.Remove(cbs_salaryinformation);
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
