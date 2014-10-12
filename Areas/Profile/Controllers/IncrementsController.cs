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
    public class IncrementsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Increments
        public ActionResult Index()
        {
            return View(db.CBS_Increments.ToList());
        }

        // GET: Profile/Increments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Increments cBS_Increments = db.CBS_Increments.Find(id);
            if (cBS_Increments == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Increments);
        }

        // GET: Profile/Increments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Increments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Effective_Date,Increment_Amount,EmpID,Approved,EditedBy,TargetRowID")] CBS_Increments cBS_Increments)
        {
            if (ModelState.IsValid)
            {
                db.CBS_Increments.Add(cBS_Increments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_Increments);
        }

        // GET: Profile/Increments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Increments cBS_Increments = db.CBS_Increments.Find(id);
            if (cBS_Increments == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Increments);
        }

        // POST: Profile/Increments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Effective_Date,Increment_Amount,EmpID,Approved,EditedBy,TargetRowID")] CBS_Increments cBS_Increments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_Increments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_Increments);
        }

        // GET: Profile/Increments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Increments cBS_Increments = db.CBS_Increments.Find(id);
            if (cBS_Increments == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Increments);
        }

        // POST: Profile/Increments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Increments cBS_Increments = db.CBS_Increments.Find(id);
            db.CBS_Increments.Remove(cBS_Increments);
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
