using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comic.Data;
using comic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comic.Models;
using comic.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace comic.Controllers;

[Route("/admin/manage-users")]
public class ManageUsersController : Controller
{
    private readonly IUsersRepository _usersRepository;
    private readonly UserManager<User> _userManager;

    public ManageUsersController(IUsersRepository usersRepository, UserManager<User> userManager)
    {
        _usersRepository = usersRepository;
        
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> ManageUsers()
    {
        if (!User.Identity!.IsAuthenticated || !User.IsInRole("admin"))
        {
            return RedirectToAction("Index", "Home");
        }

        return View(await _usersRepository.GetAll());
    }
    
    [HttpGet]
    [Route("/admin/manage-users/create")]
    public async Task<IActionResult> Create()
    {
        var roles = await _usersRepository.GetAllRoles();

        ViewData["RoleId"] = new SelectList(roles, nameof(IdentityRole.Name), nameof(IdentityRole.Name));
        
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/admin/manage-users/create")]
    public async Task<IActionResult> Create(CreateUserViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View("ManageUsers");
        }

        var newAdminUser = new User
        {
            UserName = vm.UserName,
            Email = vm.Email,
            EmailConfirmed = true,
        };

        var result = await _userManager.CreateAsync(newAdminUser, vm.Password);

        if (result.Succeeded)
        {
            if (vm.RoleId == "admin")
            {
                await _userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }
            else
            {
                await _userManager.AddToRoleAsync(newAdminUser, UserRoles.User);
            }

            return RedirectToAction("ManageUsers");
        }
        
        return View("ManageUsers");
    }
}