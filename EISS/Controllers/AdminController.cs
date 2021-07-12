using EIS.Context;
using EIS.Models;
using EISS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<IActionResult> DeleteUser(string id)
        {
                if(id == null)
                {
                    return RedirectToAction("Index");
                }
                var deleteUser = await _userManager.FindByIdAsync(id);
                var identityResult = await _userManager.DeleteAsync(deleteUser);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Users");
                }
                TempData["Errors"] = identityResult.Errors;
                return RedirectToAction("Users");
        }

        public IActionResult UpdateUser(int id)
        {
            var user = _userManager.Users.FirstOrDefault(I => I.Id == id);
            if(user != null)
            {
                UserUpdateViewModel model = new UserUpdateViewModel
                {
                    UserName = user.UserName,
                    Name = user.Name,
                    Surname = user.Surname,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Users");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateViewModel model)
        {
            var updateUser = _userManager.Users.Where(I => I.Id == model.Id).FirstOrDefault();

            updateUser.Name = model.Name;
            updateUser.UserName = model.UserName;
            updateUser.Surname = model.Surname;
            updateUser.PhoneNumber = model.PhoneNumber;
            updateUser.Email = model.Email;

            var identityResult = await _userManager.UpdateAsync(updateUser);

            if (identityResult.Succeeded)
            {
                return RedirectToAction("Users");
            }
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
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
        public IActionResult UpdateRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(I => I.Id == id);

            if(role != null) { 
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(model);
            }
            else
            {
                return RedirectToAction("Roles");
            }
        }
        [HttpPost]
        public async Task <IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var updatedRole = _roleManager.Roles.Where(I => I.Id == model.Id).FirstOrDefault();
            updatedRole.Name = model.Name;
            var identityResult = await _roleManager.UpdateAsync(updatedRole);
            if (identityResult.Succeeded)
            {
                return RedirectToAction("Roles");
            }
            foreach(var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var deletedRole = _roleManager.Roles.FirstOrDefault(I => I.Id == id);
            var identityResult = await _roleManager.DeleteAsync(deletedRole);
            if (identityResult.Succeeded)
            {
                return RedirectToAction("Index");
            }
            TempData["Errors"] = identityResult.Errors;
            return RedirectToAction("Roles");
        }

        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(I => I.Id == id);

            TempData["UserId"] = user.Id;

            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> models = new List<RoleAssignViewModel>();
            foreach(var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleId = item.Id;
                model.Name = item.Name;
                model.Exist = userRoles.Contains(item.Name);
                models.Add(model);
            }
            return View(models);

        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> models)
        {
            var userId = (int)TempData["UserId"];

            var user = _userManager.Users.FirstOrDefault(I => I.Id == userId);

            foreach(var item in models)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("Users");
        }
    }
}
