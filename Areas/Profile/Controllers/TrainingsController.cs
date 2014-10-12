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
    public class TrainingsController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/Trainings
        public ActionResult Index()
        {
            return View(db.CBS_Trainings.ToList());
        }

        // GET: Profile/Trainings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Trainings cBS_Trainings = db.CBS_Trainings.Find(id);
            if (cBS_Trainings == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Trainings);
        }

        // GET: Profile/Trainings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Trainings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Year,Course_Name,Training_Provider,External,Category,Training_Month,Time_Duration,Cost_Money,EmpID,Approved,EditedBy,TargetRowID")] CBS_Trainings cBS_Trainings)
        {
            if (ModelState.IsValid)
            {
                db.CBS_Trainings.Add(cBS_Trainings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_Trainings);
        }

        // GET: Profile/Trainings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Trainings cBS_Trainings = db.CBS_Trainings.Find(id);
            if (cBS_Trainings == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Trainings);
        }

        // POST: Profile/Trainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Year,Course_Name,Training_Provider,External,Category,Training_Month,Time_Duration,Cost_Money,EmpID,Approved,EditedBy,TargetRowID")] CBS_Trainings cBS_Trainings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_Trainings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_Trainings);
        }

        // GET: Profile/Trainings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Trainings cBS_Trainings = db.CBS_Trainings.Find(id);
            if (cBS_Trainings == null)
            {
                return HttpNotFound();
            }
            return View(cBS_Trainings);
        }

        // POST: Profile/Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Trainings cBS_Trainings = db.CBS_Trainings.Find(id);
            db.CBS_Trainings.Remove(cBS_Trainings);
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
