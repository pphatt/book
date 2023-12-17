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
using Microsoft.AspNetCore.Identity;

namespace comic.Controllers;

[Route("/admin/manage-users")]
public class ManageUsersController : Controller
{
    private readonly IUsersRepository _usersRepository;

    public ManageUsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
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
}