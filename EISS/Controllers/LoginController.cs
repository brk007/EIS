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
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.CookieRemember, true);

                if (identityResult.IsLockedOut)
                {
                    ModelState.AddModelError("", "Hesabınız kilitlendi");
                    return View("Index", model);
                }

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı");
            }
            return View("Index", model);
        }
    }
}
