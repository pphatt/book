using System.Diagnostics;
using comic.Interfaces;
using comic.Models;
using comic.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comic.Controllers;

public class HomeController : Controller
{
    private readonly IProductsRepository _productsRepository;

    public HomeController(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["HeroProductData"] = await _productsRepository.GetSliceAsync(0, 10);

        ViewData["CarouselOne"] = await _productsRepository.GetSliceAsync(0, 15);

        ViewData["CarouselTwo"] = await _productsRepository.GetSliceAsync(0, 15);

        return View(await _productsRepository.GetSliceAsync(0, 24));
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