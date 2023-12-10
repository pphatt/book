using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comic.Models;
using comic.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace comic.Controllers
{
    public class AccountController : Controller
    {
        private readonly ComicContext _context;

        public AccountController(
            ComicContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        // [HttpPost]
        // public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        // {
        //     if (!ModelState.IsValid) return View(loginViewModel);
        //
        //     var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
        //
        //     if (user != null)
        //     {
        //         //User is found, check password
        //         var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
        //         if (passwordCheck)
        //         {
        //             //Password correct, sign in
        //             var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
        //             if (result.Succeeded)
        //             {
        //                 return RedirectToAction("Index", "Home");
        //             }
        //         }
        //
        //         //Password is incorrect
        //         TempData["Error"] = "Wrong credentials. Please try again";
        //         return View(loginViewModel);
        //     }
        //
        //     //User not found
        //     TempData["Error"] = "Wrong credentials. Please try again";
        //     return View(loginViewModel);
        // }
    }
}