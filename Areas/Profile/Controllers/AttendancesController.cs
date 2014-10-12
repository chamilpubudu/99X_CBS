﻿using System;
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
    public class AttendancesController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Attendances
        public ActionResult Index()
        {
            return View(db.CBS_Attendances.ToList());
        }

        // GET: Profile/Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Attendances cBS_Attendances = db.CBS_Attendances.Find(id);
            if (cBS_Attendances == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Attendances);
        }

        // GET: Profile/Attendances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Date,Average_InTime,Average_OutTime,Weekends_Worked,Medical_Leaves_Taken,Casual_Leaves_Taken,Annual_Leaves_Taken,Lieu_Leaves_Taken,Number_of_Days_Reported_to_Work,EmpID,Approved,EditedBy,TargetRowID")] CBS_Attendances cBS_Attendances)
        {
            if (ModelState.IsValid)
            {
                db.CBS_Attendances.Add(cBS_Attendances);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_Attendances);
        }

        // GET: Profile/Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Attendances cBS_Attendances = db.CBS_Attendances.Find(id);
            if (cBS_Attendances == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Attendances);
        }

        // POST: Profile/Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Date,Average_InTime,Average_OutTime,Weekends_Worked,Medical_Leaves_Taken,Casual_Leaves_Taken,Annual_Leaves_Taken,Lieu_Leaves_Taken,Number_of_Days_Reported_to_Work,EmpID,Approved,EditedBy,TargetRowID")] CBS_Attendances cBS_Attendances)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_Attendances).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_Attendances);
        }

        // GET: Profile/Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Attendances cBS_Attendances = db.CBS_Attendances.Find(id);
            if (cBS_Attendances == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Attendances);
        }

        // POST: Profile/Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Attendances cBS_Attendances = db.CBS_Attendances.Find(id);
            db.CBS_Attendances.Remove(cBS_Attendances);
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
