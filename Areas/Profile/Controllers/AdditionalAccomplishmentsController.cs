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
    public class AdditionalAccomplishmentsController : Controller
    {
        private Entities db = new Entities();

        // GET: /Profile/AdditionalAccomplishments/
        public ActionResult Index()
        {
            return View(db.CBS_AdditionalAccomplishments.ToList());
        }

        // GET: /Profile/AdditionalAccomplishments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_AdditionalAccomplishments cbs_additionalaccomplishments = db.CBS_AdditionalAccomplishments.Find(id);
            if (cbs_additionalaccomplishments == null)
            {
                return HttpNotFound();
            }
            return View(cbs_additionalaccomplishments);
        }

        // GET: /Profile/AdditionalAccomplishments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Profile/AdditionalAccomplishments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Employee_Name,Accomplishment_Date,AccomplishmentName,EmpID,Approved,EditedBy,TargetRowID")] CBS_AdditionalAccomplishments cbs_additionalaccomplishments)
        {
            if (ModelState.IsValid)
            {
                db.CBS_AdditionalAccomplishments.Add(cbs_additionalaccomplishments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cbs_additionalaccomplishments);
        }

        // GET: /Profile/AdditionalAccomplishments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_AdditionalAccomplishments cbs_additionalaccomplishments = db.CBS_AdditionalAccomplishments.Find(id);
            if (cbs_additionalaccomplishments == null)
            {
                return HttpNotFound();
            }
            return View(cbs_additionalaccomplishments);
        }

        // POST: /Profile/AdditionalAccomplishments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Employee_Name,Accomplishment_Date,AccomplishmentName,EmpID,Approved,EditedBy,TargetRowID")] CBS_AdditionalAccomplishments cbs_additionalaccomplishments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cbs_additionalaccomplishments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cbs_additionalaccomplishments);
        }

        // GET: /Profile/AdditionalAccomplishments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_AdditionalAccomplishments cbs_additionalaccomplishments = db.CBS_AdditionalAccomplishments.Find(id);
            if (cbs_additionalaccomplishments == null)
            {
                return HttpNotFound();
            }
            return View(cbs_additionalaccomplishments);
        }

        // POST: /Profile/AdditionalAccomplishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_AdditionalAccomplishments cbs_additionalaccomplishments = db.CBS_AdditionalAccomplishments.Find(id);
            db.CBS_AdditionalAccomplishments.Remove(cbs_additionalaccomplishments);
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
