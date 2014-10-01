using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _99X_CBS.Models;

namespace _99X_CBS.Areas.Admin.Controllers
{
    public class ReportSettingsController : Controller
    {
        private Entities db = new Entities();

        // GET: /Admin/ReportSettings/
        public ActionResult Index()
        {
            return View(db.CBS_ReportFormat.ToList());
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "ID,Section,Enabled,SectionCode")] CBS_ReportFormat cbs_reportformat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cbs_reportformat).State = EntityState.Modified;
                db.SaveChanges();                
            }
            return RedirectToAction("Index");
        }

        // GET: /Admin/ReportSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_ReportFormat cbs_reportformat = db.CBS_ReportFormat.Find(id);
            if (cbs_reportformat == null)
            {
                return HttpNotFound();
            }
            return View(cbs_reportformat);
        }

        // GET: /Admin/ReportSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/ReportSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Section,Enabled,SectionCode")] CBS_ReportFormat cbs_reportformat)
        {
            if (ModelState.IsValid)
            {
                db.CBS_ReportFormat.Add(cbs_reportformat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cbs_reportformat);
        }

        // GET: /Admin/ReportSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_ReportFormat cbs_reportformat = db.CBS_ReportFormat.Find(id);
            if (cbs_reportformat == null)
            {
                return HttpNotFound();
            }
            return View(cbs_reportformat);
        }

        // POST: /Admin/ReportSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Section,Enabled,SectionCode")] CBS_ReportFormat cbs_reportformat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cbs_reportformat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cbs_reportformat);
        }

        // GET: /Admin/ReportSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CBS_ReportFormat cbs_reportformat = db.CBS_ReportFormat.Find(id);
            if (cbs_reportformat == null)
            {
                return HttpNotFound();
            }
            return View(cbs_reportformat);
        }

        // POST: /Admin/ReportSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CBS_ReportFormat cbs_reportformat = db.CBS_ReportFormat.Find(id);
            db.CBS_ReportFormat.Remove(cbs_reportformat);
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
