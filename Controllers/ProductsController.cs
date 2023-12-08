using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comic.Models;

namespace comic.Controllers;

public class ProductsController : Controller
{
    private readonly ComicContext _context;

    public ProductsController(ComicContext context)
    {
        _context = context;
    }

    [Route("/Products/{id:int}")]
    public async Task<IActionResult> Index(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Publisher)
            .Include(p => p.Authors)
            .Include(p => p.Images)
            .Include(p => p.Tags)
            // .OrderBy(p => p.ProductId)
            .FirstOrDefaultAsync(m => m.ProductId == id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
}