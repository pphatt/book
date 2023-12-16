using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comic.Models;
using comic.ViewModels;

namespace comic.Controllers;

[Route("/admin/manage-products")]
public class ManageProductsController : Controller
{
    private readonly IProductsRepository _productsRepository;
    private readonly ComicContext _context;

    public ManageProductsController(IProductsRepository productsRepository, ComicContext context)
    {
        _productsRepository = productsRepository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ManageProducts()
    {
        if (!User.Identity!.IsAuthenticated || !User.IsInRole("admin"))
        {
            return RedirectToAction("Index", "Home");
        }

        return View(await _productsRepository.GetAll());
    }
    
    // // GET: ManageProducts/Details/5
    // public async Task<IActionResult> Details(int? id)
    // {
    //     if (id == null || _context.Products == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var product = await _context.Products
    //         .Include(p => p.Category)
    //         .Include(p => p.Publisher)
    //         .Include(p => p.StoreOwner)
    //         .FirstOrDefaultAsync(m => m.ProductId == id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     return View(product);
    // }
    
    // public IActionResult Create()
    // {
    //     return View();
    // }

    // [HttpPost]
    // public async Task<IActionResult> Create(Product product)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return View(product);
    //     }
    //     
    //     _productsRepository.Add(product);
    //     return RedirectToAction("Index");
    // }
    
    [HttpPost]
    [Route("/admin/manage-products/create")]
    public async Task<IActionResult> Create(TestFilepondImageViewModel vm, List<IFormFile> postedFiles)
    {
        // var test = Request.Form.Files.Count;
        return View();
    }
    
    // GET: ManageProducts/Create
    [Route("/admin/manage-products/create")]
    public IActionResult Create()
    {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId");
        ViewData["StoreOwnerId"] = new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId");
        return View();
    }
    
    // POST: ManageProducts/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Create(
    //     [Bind("ProductId,Name,PublisherId,Description,Price,Inventory,CategoryId,StoreOwnerId,CreatedAt,UpdatedAt")]
    //     Product product)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         _context.Add(product);
    //         await _context.SaveChangesAsync();
    //         return RedirectToAction(nameof(ManageProducts));
    //         return RedirectToAction(nameof(Create));
    //     }
    //
    //     // ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
    //     // ViewData["PublisherId"] =
    //     //     new SelectList(_context.Publishers, "PublisherId", "PublisherId", product.PublisherId);
    //     // ViewData["StoreOwnerId"] =
    //     //     new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", product.StoreOwnerId);
    //     return View(product);
    // }
    
    // // GET: ManageProducts/Edit/5
    // public async Task<IActionResult> Edit(int? id)
    // {
    //     if (id == null || _context.Products == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var product = await _context.Products.FindAsync(id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
    //     ViewData["PublisherId"] =
    //         new SelectList(_context.Publishers, "PublisherId", "PublisherId", product.PublisherId);
    //     ViewData["StoreOwnerId"] =
    //         new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", product.StoreOwnerId);
    //     return View(product);
    // }
    //
    // // POST: ManageProducts/Edit/5
    // // To protect from overposting attacks, enable the specific properties you want to bind to.
    // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Edit(int id,
    //     [Bind("ProductId,Name,PublisherId,Description,Price,Inventory,CategoryId,StoreOwnerId,CreatedAt,UpdatedAt")]
    //     Product product)
    // {
    //     if (id != product.ProductId)
    //     {
    //         return NotFound();
    //     }
    //
    //     if (ModelState.IsValid)
    //     {
    //         try
    //         {
    //             _context.Update(product);
    //             await _context.SaveChangesAsync();
    //         }
    //         catch (DbUpdateConcurrencyException)
    //         {
    //             if (!ProductExists(product.ProductId))
    //             {
    //                 return NotFound();
    //             }
    //             else
    //             {
    //                 throw;
    //             }
    //         }
    //
    //         return RedirectToAction(nameof(ManageProducts));
    //     }
    //
    //     ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
    //     ViewData["PublisherId"] =
    //         new SelectList(_context.Publishers, "PublisherId", "PublisherId", product.PublisherId);
    //     ViewData["StoreOwnerId"] =
    //         new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", product.StoreOwnerId);
    //     return View(product);
    // }
    //
    // // GET: ManageProducts/Delete/5
    // public async Task<IActionResult> Delete(int? id)
    // {
    //     if (id == null || _context.Products == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var product = await _context.Products
    //         .Include(p => p.Category)
    //         .Include(p => p.Publisher)
    //         .Include(p => p.StoreOwner)
    //         .FirstOrDefaultAsync(m => m.ProductId == id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     return View(product);
    // }
    //
    // // POST: ManageProducts/Delete/5
    // [HttpPost, ActionName("Delete")]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> DeleteConfirmed(int id)
    // {
    //     if (_context.Products == null)
    //     {
    //         return Problem("Entity set 'ComicContext.Products'  is null.");
    //     }
    //
    //     var product = await _context.Products.FindAsync(id);
    //     if (product != null)
    //     {
    //         _context.Products.Remove(product);
    //     }
    //
    //     await _context.SaveChangesAsync();
    //     return RedirectToAction(nameof(ManageProducts));
    // }
    //
    // private bool ProductExists(int id)
    // {
    //     return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
    // }
}