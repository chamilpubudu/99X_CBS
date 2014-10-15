using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _99X_CBS.Models;
using Microsoft.AspNet.Identity;

namespace _99X_CBS.Areas.Profile.Controllers
{
    [Authorize]
    public class PublicAppearencesController : Controller
    {
        private Entities db = new Entities();

        // GET: Profile/PublicAppearences
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_PublicAppearences_Manage"))
            {
                return View(db.CBS_PublicAppearences.Where(x => x.Approved == true).ToList());
            }
            else
            {
                string userEmpId = CurrentUser.GetEmpID(this.Session, this.User);
                return View(db.CBS_PublicAppearences.Where(x => x.Approved == true && x.EmpID == userEmpId).ToList());
            }
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
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_PublicAppearences_Manage"))
                {
                    cBS_PublicAppearences.Approved = true;
                }
                else
                {
                    cBS_PublicAppearences.Approved = false;
                }
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
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_PublicAppearences_Manage"))
                {
                    cBS_PublicAppearences.Approved = true;
                    db.Entry(cBS_PublicAppearences).State = EntityState.Modified;
                }
                else
                {
                    cBS_PublicAppearences.Approved = false;
                    cBS_PublicAppearences.TargetRowID = cBS_PublicAppearences.ID;
                    cBS_PublicAppearences.EditedBy = User.Identity.Name;
                    cBS_PublicAppearences.ID = 0;
                    db.CBS_PublicAppearences.Add(cBS_PublicAppearences);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cBS_PublicAppearences);
        }

        // GET: Profile/PublicAppearences/Delete/5
        [Authorize(Roles = "Admin, Manager, CBS_PublicAppearences_Manage")]
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
        [Authorize(Roles = "Admin, Manager, CBS_PublicAppearences_Manage")]
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
