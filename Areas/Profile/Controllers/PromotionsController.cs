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
    public class PromotionsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Promotions
        public ActionResult Index()
        {
            return View(db.CBS_Promotions.ToList());
        }

        // GET: Profile/Promotions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Promotions cBS_Promotions = db.CBS_Promotions.Find(id);
            if (cBS_Promotions == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Promotions);
        }

        // GET: Profile/Promotions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Promotions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Date,Promoted_To,Previous_Designation,EmpID,Approved,EditedBy,TargetRowID")] CBS_Promotions cBS_Promotions)
        {
            if (ModelState.IsValid)
            {
                db.CBS_Promotions.Add(cBS_Promotions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_Promotions);
        }

        // GET: Profile/Promotions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Promotions cBS_Promotions = db.CBS_Promotions.Find(id);
            if (cBS_Promotions == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Promotions);
        }

        // POST: Profile/Promotions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Date,Promoted_To,Previous_Designation,EmpID,Approved,EditedBy,TargetRowID")] CBS_Promotions cBS_Promotions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_Promotions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_Promotions);
        }

        // GET: Profile/Promotions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Promotions cBS_Promotions = db.CBS_Promotions.Find(id);
            if (cBS_Promotions == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Promotions);
        }

        // POST: Profile/Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Promotions cBS_Promotions = db.CBS_Promotions.Find(id);
            db.CBS_Promotions.Remove(cBS_Promotions);
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
