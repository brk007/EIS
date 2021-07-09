using EIS.Context;
using EIS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EIS.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(new RegisterViewModel());
        }
        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.SurName,
                    UserName = model.UserName    
                };
                var result = await _userManager.CreateAsync(user,model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Index");
        }
    }
}
