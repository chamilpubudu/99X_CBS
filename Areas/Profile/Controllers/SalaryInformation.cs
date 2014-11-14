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
    public class SalaryInformation : Controller
    {
        private Entities db = new Entities();

        // GET: /Profile/SalaryInformation/
        public ActionResult Index()
        {
            return View(db.CBS_SalaryInformation.ToList());
        }

        // GET: /Profile/SalaryInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_SalaryInformation cbs_salaryinformation = db.CBS_SalaryInformation.Find(id);
            if (cbs_salaryinformation == null)
            {
                return HttpNotFound();
            }
            return View(cbs_salaryinformation);
        }

        // GET: /Profile/SalaryInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Profile/SalaryInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Employee_Name,Date,CurrentSalaryAmount,EPF,ETF,EmpID,Approved,EditedBy,TargetRowID")] CBS_SalaryInformation cbs_salaryinformation)
        {
            if (ModelState.IsValid)
            {
                db.CBS_SalaryInformation.Add(cbs_salaryinformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cbs_salaryinformation);
        }

        // GET: /Profile/SalaryInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_SalaryInformation cbs_salaryinformation = db.CBS_SalaryInformation.Find(id);
            if (cbs_salaryinformation == null)
            {
                return HttpNotFound();
            }
            return View(cbs_salaryinformation);
        }

        // POST: /Profile/SalaryInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Employee_Name,Date,CurrentSalaryAmount,EPF,ETF,EmpID,Approved,EditedBy,TargetRowID")] CBS_SalaryInformation cbs_salaryinformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cbs_salaryinformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cbs_salaryinformation);
        }

        // GET: /Profile/SalaryInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_SalaryInformation cbs_salaryinformation = db.CBS_SalaryInformation.Find(id);
            if (cbs_salaryinformation == null)
            {
                return HttpNotFound();
            }
            return View(cbs_salaryinformation);
        }

        // POST: /Profile/SalaryInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_SalaryInformation cbs_salaryinformation = db.CBS_SalaryInformation.Find(id);
            db.CBS_SalaryInformation.Remove(cbs_salaryinformation);
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
