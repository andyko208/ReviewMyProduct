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
        private readonly SignInManager<AppUser> _signInManager;
        private readonly List<IdentityRole> _roles;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            _roles = _roleManager.Roles.ToList();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var vm = new RegisterViewModel
            {
                //Roles = new SelectList(_roleManager.Roles.ToList())
                Role = "user"
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // here we register the user
                var user = new AppUser
                {
                    Email = vm.Email,
                    UserName = vm.Email
                };

                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    // apply roles to user
                    await _userManager.AddToRoleAsync(user, vm.Role);

                    // lets try to log in the user right away
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            // vm.Roles = new SelectList(_roles);

            return View(vm);
        }

        [HttpGet]
        public IActionResult SignIn() => View();

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);

                if(result.Succeeded)
                {
                    // get user
                    var user = await _userManager.FindByEmailAsync(vm.Email);

                    // identify what role has
                    var isUser = await _userManager.IsInRoleAsync(user, "user");

                    // redirect to right controller (based on role)
                    if(isUser)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Administrator");
                    }
                }
                else
                {
                    ModelState.AddModelError("SignIn", "Username or Password incorrect");
                }
            }
            return View(vm);
        }
    }
}