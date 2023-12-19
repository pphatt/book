using comic.Interfaces;
using comic.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
            .Include(p => p.Publisher)
            .Include(p => p.StoreOwner)
            .Include(p => p.Category)
            .OrderBy(p => p.ProductId);

        return await products.ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetSliceAsync(int offset, int size)
    {
        var products = _context.Products
            .Include(p => p.Authors)
            .Include(p => p.Images)
            .Include(p => p.Tags)
            .Include(p => p.Publisher)
            .Include(p => p.StoreOwner)
            .Include(p => p.Category)
            .OrderBy(p => p.ProductId);

        return await products.Skip(offset).Take(size).ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.Authors)
            .Include(p => p.Images)
            .Include(p => p.Tags)
            .Include(p => p.Publisher)
            .Include(p => p.StoreOwner)
            .Include(p => p.Category)
            .Include(p => p.Images)
            .FirstOrDefaultAsync(m => m.ProductId == id);

        if (product == null)
        {
            throw new Exception();
        }

        return product;
    }
    
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        var categories = _context.Categories
            .OrderBy(c => c.CategoryId);

        return await categories.ToListAsync();
    }
    
    public async Task<IEnumerable<Publisher>> GetAllPublisher()
    {
        var publisher = _context.Publishers
            .OrderBy(c => c.PublisherId);

        return await publisher.ToListAsync();
    }
    
    public async Task<IEnumerable<Tag>> GetAllTag()
    {
        var tags = _context.Tags
            .OrderBy(c => c.TagId);

        return await tags.ToListAsync();
    }
    
    public async Task<IEnumerable<StoreOwner>> GetAllStoreOwner()
    {
        var storeOwner = _context.StoreOwners
            .OrderBy(c => c.StoreOwnerId);

        return await storeOwner.ToListAsync();
    }

    public int AddNewPublisher(Publisher publisher)
    {
        _context.Add(publisher);
        Save();

        return publisher.PublisherId;
    }
    
    public int AddNewStoreOwner(StoreOwner storeOwner)
    {
        _context.Add(storeOwner);
        Save();

        return storeOwner.StoreOwnerId;
    }
    
    public bool Add(Product product)
    {
        _context.Add(product);

        return Save();
    }
    
    public bool DeleteImages(int productId)
    {
        var product = _context.Products.Include(p => p.Images).FirstOrDefault(p => p.ProductId == productId);

        if (product != null)
        {
            _context.Images.RemoveRange(product.Images);
            _context.Entry(product).State = EntityState.Detached;
        }
        
        return Save();
    }
    
    public bool Delete(Product product)
    {
        _context.Remove(product);
        return Save();
    }
    
    public bool Update(Product product)
    {
        _context.Update(product);
        
        return Save();
    }
    
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}