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
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;
      
        public ProductController(AppDbContext context)
        {
            _context = context;
           
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            var ModelView = new ProductViewModel();
            ModelView.Product = products;

            ModelView.Recommendations = await _context.Products
                                                    .Where(p => p.CategoryId == products.CategoryId && p.Id != id)
                                                    .ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return View(ModelView);
        }
    }
}
