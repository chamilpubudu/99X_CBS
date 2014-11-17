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
    public class BenefitsController : Controller
    {
        private Entities db = new Entities();

        // GET: /Profile/Benefits/
        public ActionResult Index()
        {
            return View(db.CBS_Benefits.ToList());
        }

        // GET: /Profile/Benefits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Benefits cbs_benefits = db.CBS_Benefits.Find(id);
            if (cbs_benefits == null)
            {
                return HttpNotFound();
            }
            return View(cbs_benefits);
        }

        // GET: /Profile/Benefits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Profile/Benefits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Employee_Name,Date,Name,EmpID,Approved,EditedBy,TargetRowID")] CBS_Benefits cbs_benefits)
        {
            if (ModelState.IsValid)
            {
                db.CBS_Benefits.Add(cbs_benefits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cbs_benefits);
        }

        // GET: /Profile/Benefits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Benefits cbs_benefits = db.CBS_Benefits.Find(id);
            if (cbs_benefits == null)
            {
                return HttpNotFound();
            }
            return View(cbs_benefits);
        }

        // POST: /Profile/Benefits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Employee_Name,Date,Name,EmpID,Approved,EditedBy,TargetRowID")] CBS_Benefits cbs_benefits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cbs_benefits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cbs_benefits);
        }

        // GET: /Profile/Benefits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_Benefits cbs_benefits = db.CBS_Benefits.Find(id);
            if (cbs_benefits == null)
            {
                return HttpNotFound();
            }
            return View(cbs_benefits);
        }

        // POST: /Profile/Benefits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_Benefits cbs_benefits = db.CBS_Benefits.Find(id);
            db.CBS_Benefits.Remove(cbs_benefits);
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
