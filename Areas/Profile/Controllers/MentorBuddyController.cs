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
    public class MentorBuddyController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/MentorBuddy
        public ActionResult Index()
        {
            return View(db.CBS_MentorBuddy.ToList());
        }

        // GET: Profile/MentorBuddy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_MentorBuddy cBS_MentorBuddy = db.CBS_MentorBuddy.Find(id);
            if (cBS_MentorBuddy == null)
            {
                return HttpNotFound();
            }
            return View(cBS_MentorBuddy);
        }

        // GET: Profile/MentorBuddy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/MentorBuddy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Date,Mentor_or_Buddy_Type,Mentor_or_Buddy,EmpID,Approved,EditedBy,TargetRowID")] CBS_MentorBuddy cBS_MentorBuddy)
        {
            if (ModelState.IsValid)
            {
                db.CBS_MentorBuddy.Add(cBS_MentorBuddy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cBS_MentorBuddy);
        }

        // GET: Profile/MentorBuddy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_MentorBuddy cBS_MentorBuddy = db.CBS_MentorBuddy.Find(id);
            if (cBS_MentorBuddy == null)
            {
                return HttpNotFound();
            }
            return View(cBS_MentorBuddy);
        }

        // POST: Profile/MentorBuddy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Date,Mentor_or_Buddy_Type,Mentor_or_Buddy,EmpID,Approved,EditedBy,TargetRowID")] CBS_MentorBuddy cBS_MentorBuddy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cBS_MentorBuddy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_MentorBuddy);
        }

        // GET: Profile/MentorBuddy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_MentorBuddy cBS_MentorBuddy = db.CBS_MentorBuddy.Find(id);
            if (cBS_MentorBuddy == null)
            {
                return HttpNotFound();
            }
            return View(cBS_MentorBuddy);
        }

        // POST: Profile/MentorBuddy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_MentorBuddy cBS_MentorBuddy = db.CBS_MentorBuddy.Find(id);
            db.CBS_MentorBuddy.Remove(cBS_MentorBuddy);
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
