using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comic.Models;

namespace comic.Controllers
{
    public class AccountController : Controller
    {
        private readonly ComicContext _context;

        public AccountController(ComicContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
