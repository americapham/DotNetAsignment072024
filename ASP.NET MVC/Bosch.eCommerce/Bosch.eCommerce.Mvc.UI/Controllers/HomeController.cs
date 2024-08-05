using Bosch.eCommerce.Mvc.UI.Filters;
using Bosch.eCommerce.Mvc.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace Bosch.eCommerce.Mvc.UI.Controllers
{
    [BoschController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [BoschAction]
        public IActionResult Index()
        {
            
            HttpContext.Session.SetInt32("CustomerId", 1);
            //Cookie cookie = new Cookie();
            //cookie.Secure = true;
            //cookie.Expires = DateTime.Now.AddHours(4);
            HttpContext.Response.Cookies.Append("Company", "Bosch Pvt. Ltd.");
            return View();
        }

        public IActionResult Privacy()
        {
            var cookie = HttpContext.Request.Cookies["Company"];
            if (cookie != null)
            {
                ViewBag.CompanyName = cookie;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
