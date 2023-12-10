using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comic.Models;

namespace comic.Controllers;

public class ProductsController : Controller
{
    private readonly IProductsRepository _productsRepository;

    public ProductsController(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    [Route("/Products/{id:int}")]
    public async Task<IActionResult> Index(int id)
    {
        return View(await _productsRepository.GetByIdAsync(id));
    }
}