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
    public class TechnologyExposureController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/TechnologyExposure
        public ActionResult Index()
        {
            return View(db.CBS_TechnologyExposure.ToList());
        }

        // GET: Profile/TechnologyExposure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_TechnologyExposure cBS_TechnologyExposure = db.CBS_TechnologyExposure.Find(id);
            if (cBS_TechnologyExposure == null)
            {
                return HttpNotFound();
            }
            return View(cBS_TechnologyExposure);
        }

        // GET: Profile/TechnologyExposure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/TechnologyExposure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Date,Engagement,Technologies,EmpID,Approved,EditedBy,TargetRowID")] CBS_TechnologyExposure cBS_TechnologyExposure)
        {
            if (ModelState.IsValid)
            {
                db.CBS_TechnologyExposure.Add(cBS_TechnologyExposure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_TechnologyExposure);
        }

        // GET: Profile/TechnologyExposure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_TechnologyExposure cBS_TechnologyExposure = db.CBS_TechnologyExposure.Find(id);
            if (cBS_TechnologyExposure == null)
            {
                return HttpNotFound();
            }
            return View(cBS_TechnologyExposure);
        }

        // POST: Profile/TechnologyExposure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Date,Engagement,Technologies,EmpID,Approved,EditedBy,TargetRowID")] CBS_TechnologyExposure cBS_TechnologyExposure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_TechnologyExposure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_TechnologyExposure);
        }

        // GET: Profile/TechnologyExposure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_TechnologyExposure cBS_TechnologyExposure = db.CBS_TechnologyExposure.Find(id);
            if (cBS_TechnologyExposure == null)
            {
                return HttpNotFound();
            }
            return View(cBS_TechnologyExposure);
        }

        // POST: Profile/TechnologyExposure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_TechnologyExposure cBS_TechnologyExposure = db.CBS_TechnologyExposure.Find(id);
            db.CBS_TechnologyExposure.Remove(cBS_TechnologyExposure);
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
