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
    public class AwardsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Awards
        public ActionResult Index()
        {
            return View(db.CBS_Awards.ToList());
        }

        // GET: Profile/Awards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Awards cBS_Awards = db.CBS_Awards.Find(id);
            if (cBS_Awards == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Awards);
        }

        // GET: Profile/Awards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Awards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Award_Date,Award,EmpID,Approved,EditedBy,TargetRowID")] CBS_Awards cBS_Awards)
        {
            if (ModelState.IsValid)
            {
                db.CBS_Awards.Add(cBS_Awards);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_Awards);
        }

        // GET: Profile/Awards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Awards cBS_Awards = db.CBS_Awards.Find(id);
            if (cBS_Awards == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Awards);
        }

        // POST: Profile/Awards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Award_Date,Award,EmpID,Approved,EditedBy,TargetRowID")] CBS_Awards cBS_Awards)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_Awards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_Awards);
        }

        // GET: Profile/Awards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Awards cBS_Awards = db.CBS_Awards.Find(id);
            if (cBS_Awards == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Awards);
        }

        // POST: Profile/Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Awards cBS_Awards = db.CBS_Awards.Find(id);
            db.CBS_Awards.Remove(cBS_Awards);
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
