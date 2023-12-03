using System.Diagnostics;
using comic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comic.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ComicContext _context;

    public HomeController(ILogger<HomeController> logger, ComicContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var products = _context.Products
            .Include(p => p.Authors)
            .Include(p => p.Images)
            .Include(p => p.Tags);

        ViewData["HeroProductData"] = await products.Take(10).ToListAsync();

        return View(await products.Take(15).ToListAsync());
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
