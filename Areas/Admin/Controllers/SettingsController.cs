using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using _99X_CBS.Models;


namespace _99X_CBS.Areas.Admin.Controllers
{
    public class SettingsController : Controller
    {
        Entities db = new Entities();
        //
        // GET: /Admin/Settings/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhoto(String systemName, HttpPostedFileBase photo)
        {

            string UniqueFileName = "logo";
            if (photo != null)
            {

                string path = HttpContext.Server.MapPath(@"\Content\Images\" + UniqueFileName + Path.GetExtension(Path.GetFileName(photo.FileName).Replace(" ", string.Empty)));
                photo.SaveAs(path);

                List<CBS_SystemSettings> CBS_PhotoNameList = db.CBS_SystemSettings.Where(x => x.Name == "Photo Name").ToList();

                if (CBS_PhotoNameList.Count > 0)
                {
                    CBS_SystemSettings cbs_systemsettings2 = CBS_PhotoNameList.ElementAt(0);
                    cbs_systemsettings2.Value = UniqueFileName + Path.GetExtension(Path.GetFileName(photo.FileName).Replace(" ", string.Empty));
                    System.Web.HttpContext.Current.Application["_GlobalAppLogo"] = UniqueFileName + Path.GetExtension(Path.GetFileName(photo.FileName).Replace(" ", string.Empty));
                    db.SaveChanges();
                }
                else
                {

                    CBS_SystemSettings cbs_systemsettings2 = new CBS_SystemSettings();
                    cbs_systemsettings2.Name = "Photo Name";
                    cbs_systemsettings2.Value = UniqueFileName + Path.GetExtension(Path.GetFileName(photo.FileName).Replace(" ", string.Empty));
                    System.Web.HttpContext.Current.Application["_GlobalAppLogo"] = UniqueFileName + Path.GetExtension(Path.GetFileName(photo.FileName).Replace(" ", string.Empty));
                    db.CBS_SystemSettings.Add(cbs_systemsettings2);
                    db.SaveChanges();

                }
            }
            List<CBS_SystemSettings> CBS_SystemNameList = db.CBS_SystemSettings.Where(x => x.Name == "System Name").ToList();

            if (CBS_SystemNameList.Count > 0)
            {
                CBS_SystemSettings cbs_systemsettings1 = CBS_SystemNameList.ElementAt(0);
                cbs_systemsettings1.Value = systemName;
                System.Web.HttpContext.Current.Application["_GlobalAppName"] = systemName;
                db.SaveChanges();

            }
            else
            {

                CBS_SystemSettings cbs_systemsettings1 = new CBS_SystemSettings();
                cbs_systemsettings1.Name = "System Name";
                cbs_systemsettings1.Value = systemName;
                System.Web.HttpContext.Current.Application["_GlobalAppName"] = systemName;
                db.CBS_SystemSettings.Add(cbs_systemsettings1);
                db.SaveChanges();

            }
            return RedirectToAction("Index", "Settings", new { area = "Admin" });
        }
    }
}