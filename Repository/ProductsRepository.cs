using comic.Interfaces;
using comic.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace comic.Repository;

public class ProductsRepository : IProductsRepository
{
    private readonly ComicContext _context;

    public ProductsRepository(ComicContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var products = _context.Products
            .Include(p => p.Authors)
            .Include(p => p.Images)
            .Include(p => p.Tags)
            .OrderBy(p => p.ProductId);

        return await products.ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByQuantity(int quantity)
    {
        var products = _context.Products
            .Include(p => p.Authors)
            .Include(p => p.Images)
            .Include(p => p.Tags)
            .OrderBy(p => p.ProductId);

        return await products.Take(quantity).ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Publisher)
            .Include(p => p.Authors)
            .Include(p => p.Images)
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(m => m.ProductId == id);

        if (product == null)
        {
            throw new Exception();
        }

        // Product found, return it
        return product;
    }
}