using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _99X_CBS.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = " 99X-Career Balance Sheet ";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = " contact ";

			return View();
		}

		public ActionResult Notification()
		{
			ViewBag.Message = " Notifications ";
			NotificationHub.NotificationHub.NotifyAll("Test", "/");
			return View();
		}
	}
}