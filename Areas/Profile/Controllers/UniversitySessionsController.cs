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
    public class UniversitySessionsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/UniversitySessions
        public ActionResult Index()
        {
            return View(db.CBS_UniversitySessions.ToList());
        }

        // GET: Profile/UniversitySessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_UniversitySessions cBS_UniversitySessions = db.CBS_UniversitySessions.Find(id);
            if (cBS_UniversitySessions == null)
            {
                return HttpNotFound();
            }
            return View(cBS_UniversitySessions);
        }

        // GET: Profile/UniversitySessions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/UniversitySessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Session_Date,Initiated_By,Location,Number_Of_Participants,Participants,Session_Type,Time_Duration,Topic,To_the_University,EmpID,Approved,EditedBy,TargetRowID")] CBS_UniversitySessions cBS_UniversitySessions)
        {
            if (ModelState.IsValid)
            {
                db.CBS_UniversitySessions.Add(cBS_UniversitySessions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_UniversitySessions);
        }

        // GET: Profile/UniversitySessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_UniversitySessions cBS_UniversitySessions = db.CBS_UniversitySessions.Find(id);
            if (cBS_UniversitySessions == null)
            {
                return HttpNotFound();
            }
            return View(cBS_UniversitySessions);
        }

        // POST: Profile/UniversitySessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Session_Date,Initiated_By,Location,Number_Of_Participants,Participants,Session_Type,Time_Duration,Topic,To_the_University,EmpID,Approved,EditedBy,TargetRowID")] CBS_UniversitySessions cBS_UniversitySessions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_UniversitySessions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_UniversitySessions);
        }

        // GET: Profile/UniversitySessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_UniversitySessions cBS_UniversitySessions = db.CBS_UniversitySessions.Find(id);
            if (cBS_UniversitySessions == null)
            {
                return HttpNotFound();
            }
            return View(cBS_UniversitySessions);
        }

        // POST: Profile/UniversitySessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_UniversitySessions cBS_UniversitySessions = db.CBS_UniversitySessions.Find(id);
            db.CBS_UniversitySessions.Remove(cBS_UniversitySessions);
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
