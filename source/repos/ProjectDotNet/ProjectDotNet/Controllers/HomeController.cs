using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectDotNet.Data;
using ProjectDotNet.Models;


namespace ProjectDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                Products = await _context.Products.Include(p => p.Category).OrderByDescending(p => p.Id).ToListAsync(),
                ChannelProducts = await _context.Products.Where(p => p.CategoryId == 6).Include(p => p.Category).OrderByDescending(p => p.Id).ToListAsync(),
                DiorProducts = await _context.Products.Where(p => p.CategoryId == 7).Include(p => p.Category).OrderByDescending(p => p.Id).ToListAsync(),
                GucciProducts = await _context.Products.Where(p => p.CategoryId == 3).Include(p => p.Category).OrderByDescending(p => p.Id).ToListAsync()
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}