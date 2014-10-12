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
    public class ValueInnovationsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/ValueInnovations
        public ActionResult Index()
        {
            return View(db.CBS_ValueInnovations.ToList());
        }

        // GET: Profile/ValueInnovations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_ValueInnovations cBS_ValueInnovations = db.CBS_ValueInnovations.Find(id);
            if (cBS_ValueInnovations == null)
            {
                return HttpNotFound();
            }
            return View(cBS_ValueInnovations);
        }

        // GET: Profile/ValueInnovations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/ValueInnovations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Innovation_Date,Value_Innovation,EmpID,Approved,EditedBy,TargetRowID")] CBS_ValueInnovations cBS_ValueInnovations)
        {
            if (ModelState.IsValid)
            {
                db.CBS_ValueInnovations.Add(cBS_ValueInnovations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_ValueInnovations);
        }

        // GET: Profile/ValueInnovations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_ValueInnovations cBS_ValueInnovations = db.CBS_ValueInnovations.Find(id);
            if (cBS_ValueInnovations == null)
            {
                return HttpNotFound();
            }
            return View(cBS_ValueInnovations);
        }

        // POST: Profile/ValueInnovations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Innovation_Date,Value_Innovation,EmpID,Approved,EditedBy,TargetRowID")] CBS_ValueInnovations cBS_ValueInnovations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_ValueInnovations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_ValueInnovations);
        }

        // GET: Profile/ValueInnovations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_ValueInnovations cBS_ValueInnovations = db.CBS_ValueInnovations.Find(id);
            if (cBS_ValueInnovations == null)
            {
                return HttpNotFound();
            }
            return View(cBS_ValueInnovations);
        }

        // POST: Profile/ValueInnovations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_ValueInnovations cBS_ValueInnovations = db.CBS_ValueInnovations.Find(id);
            db.CBS_ValueInnovations.Remove(cBS_ValueInnovations);
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
