using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace AssistedProject_11.Controllers
{
    public class HomeController : Controller
    {
        private const object ResponseCacheLocation;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.GetType, NoStore = true)]
        public ActionResult Error() => View(view: new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        public ContentResult StudentAsString()
        {
            return Content("The name of the student is Walter Smith and he is in Grade 7.");
        }

        public ViewResult StudentAsView()
        {
            ViewData["message"] = "The name of the student is <b>Walter Smith</b> and he is in Grade 7.";
            return View();
        }

        public RedirectResult StudentAsRedirectResult()
        {
            return new RedirectResult("https://www.bing.com/search?q=walter+smith");
        }

        public RedirectToRouteResult StudentAsRedirectToRouteResult()
        {
            return new RedirectToRouteResult(new { Controller = "Home", action = "StudentAsView" });
        }

        public FileResult StudentAsFileResult()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"./wwwroot/StudentData.txt");
            string fileName = "StudentData.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public JsonResult StudentAsJSONResult()
        {
            String data = System.IO.File.ReadAllText(@"./wwwroot/StudentData.json");
            JObject json = JObject.Parse(data);
            return Json(json);
        }

        public ViewResult StudentList()
        {
            return View();
        }
    }
}
