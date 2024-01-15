using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectDotNet.Data;
using ProjectDotNet.Models;

namespace ProjectDotNet.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var viewModel = new ShopViewModel
            {
                Products = await _context.Products.Include(p => p.Category).OrderByDescending(p => p.Id).ToListAsync(),
                Categories = await _context.Categories.ToListAsync()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ShowCategory(int? id)
        {
            var viewModel = new ShopViewModel
            {
                Products = await _context.Products.Where(p => p.CategoryId == id).Include(p => p.Category).OrderByDescending(p => p.Id).ToListAsync(),
                Categories = await _context.Categories.ToListAsync()
            };
            return View(viewModel);
        }
    }
}
