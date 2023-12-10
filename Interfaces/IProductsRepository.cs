using comic.Models;

namespace comic.Interfaces;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<IEnumerable<Product>> GetByQuantity(int quantity);
    Task<Product> GetByIdAsync(int id);
}