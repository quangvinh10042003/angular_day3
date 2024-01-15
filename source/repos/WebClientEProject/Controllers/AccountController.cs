using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
namespace WebClient.Controllers
{
    public class AccountController : Controller
    {
       
        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
           
            return RedirectToAction("login", "Account");
        }

    }
}
