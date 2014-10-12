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
    public class PublicAppearencesController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/PublicAppearences
        public ActionResult Index()
        {
            return View(db.CBS_PublicAppearences.ToList());
        }

        // GET: Profile/PublicAppearences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_PublicAppearences cBS_PublicAppearences = db.CBS_PublicAppearences.Find(id);
            if (cBS_PublicAppearences == null)
            {
                return HttpNotFound();
            }
            return View(cBS_PublicAppearences);
        }

        // GET: Profile/PublicAppearences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/PublicAppearences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Appearance_Date,Location,Event_Name,Session_Topic,Number_Of_Participants,EmpID,Approved,EditedBy,TargetRowID")] CBS_PublicAppearences cBS_PublicAppearences)
        {
            if (ModelState.IsValid)
            {
                db.CBS_PublicAppearences.Add(cBS_PublicAppearences);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_PublicAppearences);
        }

        // GET: Profile/PublicAppearences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_PublicAppearences cBS_PublicAppearences = db.CBS_PublicAppearences.Find(id);
            if (cBS_PublicAppearences == null)
            {
                return HttpNotFound();
            }
            return View(cBS_PublicAppearences);
        }

        // POST: Profile/PublicAppearences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Appearance_Date,Location,Event_Name,Session_Topic,Number_Of_Participants,EmpID,Approved,EditedBy,TargetRowID")] CBS_PublicAppearences cBS_PublicAppearences)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_PublicAppearences).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_PublicAppearences);
        }

        // GET: Profile/PublicAppearences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_PublicAppearences cBS_PublicAppearences = db.CBS_PublicAppearences.Find(id);
            if (cBS_PublicAppearences == null)
            {
                return HttpNotFound();
            }
            return View(cBS_PublicAppearences);
        }

        // POST: Profile/PublicAppearences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_PublicAppearences cBS_PublicAppearences = db.CBS_PublicAppearences.Find(id);
            db.CBS_PublicAppearences.Remove(cBS_PublicAppearences);
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
