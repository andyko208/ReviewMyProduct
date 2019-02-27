using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Review.Domain.Models;
using ReviewMyProduct.WebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cozy.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var vm = new RegisterViewModel
            {
                Roles = new SelectList(_roleManager.Roles.ToList())
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel mv)
        {
            if (ModelState.IsValid)
            {
                // here we register the user

            }
            return View(mv);
        }
    }
}