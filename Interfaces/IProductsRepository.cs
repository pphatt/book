﻿using comic.Models;

namespace comic.Interfaces;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<IEnumerable<Product>> GetSliceAsync(int offset, int size);
    Task<Product> GetByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllCategories();
    Task<IEnumerable<Publisher>> GetAllPublisher();
    Task<IEnumerable<Tag>> GetAllTag();
    Task<IEnumerable<StoreOwner>> GetAllStoreOwner();
    int AddNewPublisher(Publisher publisher);
    bool Add(Product product);
    // bool Update(Product product);
    bool Delete(Product product);
    bool Save();
}