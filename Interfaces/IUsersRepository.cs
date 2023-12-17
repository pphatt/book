using comic.Models;
using comic.ViewModels;

namespace comic.Interfaces;

public interface IUsersRepository
{
    Task<IEnumerable<ManageUsersViewModel>> GetAll();
    // Task<IEnumerable<User>> GetSliceAsync(int offset, int size);
    // Task<User> GetByIdAsync(int id);
    bool Add(User user);
    // bool Update(Product product);
    // bool Delete(Product product);
    bool Save();
}