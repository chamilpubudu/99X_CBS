using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _99X_CBS.Areas.Admin.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Admin/Settings/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhoto(String systemName,HttpPostedFileBase photo )
        {
           

            if (photo != null) {
                string path = HttpContext.Server.MapPath(@"\Content\Images\" + photo.FileName);
                photo.SaveAs(path);
            }
            return RedirectToAction("Index", "Settings", new { area = "Admin" });
        }
	}
}