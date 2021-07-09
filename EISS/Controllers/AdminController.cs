using EIS.Context;
using EIS.Models;
using EISS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EIS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
         public AdminController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
            {
            _roleManager = roleManager;
            _userManager = userManager;
            }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View(_roleManager.Roles.ToList());
        }
        public IActionResult Users()
        {
            return View(_userManager.Users.ToList());
        }
        public IActionResult AddRole()
        {
            return View(new RoleViewModel());
        }
        public IActionResult AddUser()
        {
            return View("Index", "Register");
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.Name
                };
                var identityResult = await _roleManager.CreateAsync(role);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                foreach(var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
