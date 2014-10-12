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
    public class TravelsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Travels
        public ActionResult Index()
        {
            return View(db.CBS_Travels.ToList());
        }

        // GET: Profile/Travels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Travels cBS_Travels = db.CBS_Travels.Find(id);
            if (cBS_Travels == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Travels);
        }

        // GET: Profile/Travels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Travels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Started_Date,Number_Of_Days,Country,City,Allowance_In_SLR,Purpose,EmpID,Approved,EditedBy,TargetRowID")] CBS_Travels cBS_Travels)
        {
            if (ModelState.IsValid)
            {
                db.CBS_Travels.Add(cBS_Travels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_Travels);
        }

        // GET: Profile/Travels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Travels cBS_Travels = db.CBS_Travels.Find(id);
            if (cBS_Travels == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Travels);
        }

        // POST: Profile/Travels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Started_Date,Number_Of_Days,Country,City,Allowance_In_SLR,Purpose,EmpID,Approved,EditedBy,TargetRowID")] CBS_Travels cBS_Travels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_Travels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_Travels);
        }

        // GET: Profile/Travels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Travels cBS_Travels = db.CBS_Travels.Find(id);
            if (cBS_Travels == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Travels);
        }

        // POST: Profile/Travels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Travels cBS_Travels = db.CBS_Travels.Find(id);
            db.CBS_Travels.Remove(cBS_Travels);
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
