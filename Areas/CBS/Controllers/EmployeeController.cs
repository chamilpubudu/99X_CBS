﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using _99X_CBS.Models;

namespace _99X_CBS.Areas.CBS.Controllers
{
    public class EmployeeController : Controller
    {
        private Entities db = new Entities();

        // GET: /Employee/
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager"))
            {
                return View(db.CBS_Employees.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_Employees.Where(x => x.Approved == true && x.EmpID == userEmpId).ToList());
            }
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id, int? year = 0 ,  bool? auth = false)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Employees cbs_employees  = db.CBS_Employees.Find(id);
            if (cbs_employees == null)
            {
                return HttpNotFound();
            }

            //here by using auth variable below , it makes the pdf generation call to bypass the User priviledge checking condition since rotativa uses the anyonymose user call (Application cookie value is null)
            if (!((bool)auth))
            {

                //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
                if (!(cbs_employees.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Employees_Manage"))))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

            }



            //if the year is not provided then sort by the current year
            if (year == 0)
            {
                year = DateTime.Now.Year ;
            }

            List<CBS_Promotions> cbs_PromotionsList                                 = db.CBS_Promotions.Where(x => (x.EmpID == cbs_employees.EmpID) &&( x.Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_Increments> cbs_IncrementsList                                 = db.CBS_Increments.Where(x => (x.EmpID == cbs_employees.EmpID) && (x.Effective_Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_Bonuses> cbs_BonusesList                                       = db.CBS_Bonuses.Where(x => x.EmpID == cbs_employees.EmpID && (x.Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_Awards> cbs_AwardsList                                         = db.CBS_Awards.Where(x => x.EmpID == cbs_employees.EmpID && (x.Award_Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_EmployeeBillingUtilization> cbs_EmployeeBillingUtilizationList = db.CBS_EmployeeBillingUtilization.Where(x => x.EmpID == cbs_employees.EmpID && (x.From_Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_CustomerFeedbackScore> cbs_CustomerFeedbackScoreList           = db.CBS_CustomerFeedbackScore.Where(x => x.EmpID == cbs_employees.EmpID && (x.Feedback_Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_Trainings> cbs_TrainingsList                                   = db.CBS_Trainings.Where(x => x.EmpID == cbs_employees.EmpID && (x.Year == year) && (x.Approved == true)).ToList();
            List<CBS_Travels> cbs_TravelsList                                       = db.CBS_Travels.Where(x => x.EmpID == cbs_employees.EmpID && (x.Started_Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_TechnologyExposure> cbs_TechnologyExposureList                 = db.CBS_TechnologyExposure.Where(x => x.EmpID == cbs_employees.EmpID && (x.Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_MentorBuddy> cbs_MentorBuddyList                               = db.CBS_MentorBuddy.Where(x => x.EmpID == cbs_employees.EmpID && (x.Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_PublicAppearences> cbs_PublicAppearencesList                   = db.CBS_PublicAppearences.Where(x => x.EmpID == cbs_employees.EmpID && (x.Appearance_Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_UniversitySessions> cbs_UniversitySessionsList                 = db.CBS_UniversitySessions.Where(x => x.EmpID == cbs_employees.EmpID && (x.Session_Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_Engagement> cbs_EngagementList                                 = db.CBS_Engagement.Where(x => x.EmpID == cbs_employees.EmpID && (x.Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_ValueInnovations> cbs_ValueInnovationsList                     = db.CBS_ValueInnovations.Where(x => x.EmpID == cbs_employees.EmpID && (x.Innovation_Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_Attendances> cbs_AttendancesList                               = db.CBS_Attendances.Where(x => x.EmpID == cbs_employees.EmpID && (x.Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_FuelAllowances> cbs_FuelAllowancesList                         = db.CBS_FuelAllowances.Where(x => x.EmpID == cbs_employees.EmpID && (x.Fueling_Date.Value.Year == year) && (x.Approved == true)).ToList();
            List<CBS_ReportFormat> cbs_ReportFormatList                             = db.CBS_ReportFormat.ToList();

            CBS_DTO cbs_dto = new CBS_DTO();
            cbs_dto.cbs_employee                        = cbs_employees;
            cbs_dto.cbs_PromotionsList                  = cbs_PromotionsList;
            cbs_dto.cbs_IncrementsList                  = cbs_IncrementsList;
            cbs_dto.cbs_BonusesList                     = cbs_BonusesList;
            cbs_dto.cbs_AwardsList                      = cbs_AwardsList;
            cbs_dto.cbs_EmployeeBillingUtilizationList  = cbs_EmployeeBillingUtilizationList;
            cbs_dto.cbs_CustomerFeedbackScoreList       = cbs_CustomerFeedbackScoreList;
            cbs_dto.cbs_TrainingsList                   = cbs_TrainingsList;
            cbs_dto.cbs_TravelsList                     = cbs_TravelsList;
            cbs_dto.cbs_TechnologyExposureList          = cbs_TechnologyExposureList;
            cbs_dto.cbs_MentorBuddyList                 = cbs_MentorBuddyList;
            cbs_dto.cbs_PublicAppearencesList           = cbs_PublicAppearencesList;
            cbs_dto.cbs_UniversitySessionsList          = cbs_UniversitySessionsList;
            cbs_dto.cbs_EngagementList                  = cbs_EngagementList;
            cbs_dto.cbs_ValueInnovationsList            = cbs_ValueInnovationsList;
            cbs_dto.cbs_AttendancesList                 = cbs_AttendancesList;
            cbs_dto.cbs_FuelAllowancesList              = cbs_FuelAllowancesList;
            cbs_dto.cbs_ReportFormatList                = cbs_ReportFormatList;

            return View(cbs_dto);
        }


        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Employee_Name,Designation,Date_Joined,Career_Started_On,Appraisal_Score,ID")] CBS_Employees cbs_employees)
        {
            if (ModelState.IsValid)
            {
                db.CBS_Employees.Add(cbs_employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_employees.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Employees_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_employees);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Employees cbs_employees = db.CBS_Employees.Find(id);
            if (cbs_employees == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_employees.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Employees_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_employees);
           
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Employee_Name,Designation,Date_Joined,Career_Started_On,Appraisal_Score,ID")] CBS_Employees cbs_employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cbs_employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_employees.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Employees_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_employees);
           
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Employees cbs_employees = db.CBS_Employees.Find(id);
            if (cbs_employees == null)
            {
                return HttpNotFound();
            }

            //Only the current user or the Admin or the Manager or the Manager with the relevent section priviledges can access the page
            if (!(cbs_employees.EmpID == CurrentUser.GetEmpID(this.Session, this.User) || (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Employees_Manage"))))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(cbs_employees);
            
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Employees cbs_employees = db.CBS_Employees.Find(id);
            db.CBS_Employees.Remove(cbs_employees);
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

        // GET: /Employee/GeneratePDF
        public ActionResult GeneratePDF(int id)
        {
            return new Rotativa.ActionAsPdf("Details/"+id , new { year = 2014 , auth = true });
        }


    }
}
