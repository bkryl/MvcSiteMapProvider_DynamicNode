using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSiteMapProvider_DynamicNode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        [HttpPost]
        public ActionResult Index(int? id)
        {
            MvcSiteMapProvider.SiteMaps.ReleaseSiteMap();

            var urls = new string[] { "ABCD", "ABCD/Info", "EFGH", "EFGH/Info", "IJKL", "IJKL/Info", "MNOP", "MNOP/Info" };
            var random = new Random();

            var index = random.Next(0, urls.Length -1);

            return Redirect(urls[index]);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
