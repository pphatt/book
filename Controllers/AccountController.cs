using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comic.Data;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ComicContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ComicContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                //Password is incorrect
                TempData["Error"] = "Invalid login credentials";
                return View(loginViewModel);
            }

            //User not found
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginViewModel);
        }
        
        public IActionResult Register()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            
            if(user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }

            var newUser = new User()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.UserName,
            };
            
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}