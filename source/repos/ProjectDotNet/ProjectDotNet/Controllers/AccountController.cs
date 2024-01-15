using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectDotNet.Data;
using ProjectDotNet.Models;

namespace ProjectDotNet.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckLogin([Bind("Email,Password")] Accounts accounts)
        {
          
          
                var getAccount = await _context.Accounts.FirstOrDefaultAsync(u => u.Email == accounts.Email && u.Password == accounts.Password);
                if (getAccount != null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.ErrorMessage = "Your email or password is not defind";
                return View("Login");
                
            

        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password")] Accounts accounts)
        {
            try
            {
                _context.Add(accounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return View(accounts);
            }

        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
