using comic.Models;

namespace comic.Interfaces;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<IEnumerable<Product>> GetSliceAsync(int offset, int size);
    Task<Product> GetByIdAsync(int id);

    public bool Add(Product product);
}