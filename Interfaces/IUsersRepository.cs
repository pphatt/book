using comic.Models;
using comic.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace comic.Interfaces;

public interface IUsersRepository
{
    Task<IEnumerable<ManageUsersViewModel>> GetAll();
    Task<ManageUsersViewModel> GetByIdAsync(string id);
    Task<User> GetByIdWithoutRoleAsync(string id);
    public Task<IEnumerable<IdentityRole>> GetAllRoles();
    bool Add(User user);
    // bool Update(Product product);
    bool Delete(User user);
    bool Update(User user);
    bool Save();
}