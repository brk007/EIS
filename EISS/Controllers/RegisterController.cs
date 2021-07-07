using EIS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EIS.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View(new RegisterViewModel());
        }
        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }
    }
}
