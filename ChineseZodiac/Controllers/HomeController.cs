using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
			//ViewData ["Message"] = "Welcome to ASP.NET MVC on Mono!";
			return View ();
		}
				
		public ActionResult About ()
		{
			return View ();
		}
	}
}

