using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Ticket_System_Design.Models;

namespace Ticket_System_Design.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER))//Seesion會員登入資料偵測
            {
                User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER));
                UserLogin.user = user;
                ViewBag.USER = UserLogin.user.UserName;
            }
            else
            {
                ViewBag.USER = null;
                UserLogin.user = null;
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
