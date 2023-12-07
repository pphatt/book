using System.Text.Json.Serialization;
using System.Text.Json;
using comic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace comic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductAPITestController : Controller
{
    private readonly ComicContext _context;

    public ProductAPITestController(ComicContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _context.Products
            .Include(p => p.Authors)
            .Include(p => p.Images)
            .Include(p => p.Tags)
            .ToList();

        //var productDtos = products.Select(p => new Product
        //{
        //    ProductId = p.ProductId,
        //    Name = p.Name,
        //    Description = p.Description,
        //    Price = p.Price,
        //    Inventory = p.Inventory,
        //    CategoryId = p.CategoryId,
        //    CreatedAt = p.CreatedAt,
        //    UpdatedAt = p.UpdatedAt,
        //    // Map other properties...
        //    Images = p.Images.Select(i => new Product.ImageDto
        //    {
        //        // Map image properties...
        //    }).ToList()
        //}).ToList();

        var jsonOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            // Other serialization options...
        };

        return new JsonResult(products, jsonOptions);
    }
}
