using comic.Interfaces;
using comic.Models;
using comic.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace comic.Repository;

public class UserRepository : IUsersRepository
{
    private readonly ComicContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRepository(ComicContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        
        _userManager = userManager;
        
        _roleManager = roleManager;
    }

    public async Task<IEnumerable<ManageUsersViewModel>> GetAll()
    {
        // var user = await _userManager.Users.ToListAsync();
        // var role = await _roleManager.Roles.ToListAsync();
        
        var users = await _userManager.Users.ToListAsync();
        var userRolesViewModel = new List<ManageUsersViewModel>();
        
        foreach (var user in users)
        {
            var thisViewModel = new ManageUsersViewModel();
            
            thisViewModel.Id = user.Id;
            thisViewModel.Email = user.Email;
            thisViewModel.UserName = user.UserName;
            thisViewModel.Roles = new List<string>(await _userManager.GetRolesAsync(user));
            
            userRolesViewModel.Add(thisViewModel);
        }
        
        return userRolesViewModel;
    }
    
    public bool Add(User user)
    {
        _context.Add(user);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}