using Microsoft.AspNetCore.Mvc;
using Moment2.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Moment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Home page
        public IActionResult Index()
        {
            string nrOfPost = "0";
            // test av veiwData and viewBag
            ViewData["Message"] = "Vällkommen!";
            ViewBag.text = "Det här är min första MVC  applikation!";
            var jsonStr = System.IO.File.ReadAllText("posts.json");  // Convert data from json to str 
            var jsonObj = JsonConvert.DeserializeObject<List<Post>>(jsonStr); // Convert from str to Obj
            if (jsonObj != null)
            {
                nrOfPost = Convert.ToString(jsonObj.Count);
            }
            HttpContext.Session.SetString("nrOfPost", nrOfPost);


            ViewBag.error = HttpContext.Session.GetString("error"); // Print error from Detaile page
            return View();

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
