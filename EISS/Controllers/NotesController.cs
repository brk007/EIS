using EIS.Context;
using EISS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EIS.Controllers
{
    public class NotesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(NotesViewModel model, string note)
        {
            var updateNote = _userManager.Users.Where(I => I.Id == model.Id).FirstOrDefault();
            note = model.Note;
            var identityResult = await _userManager.UpdateAsync(updateNote);

            if (identityResult.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(NotesViewModel model, string note)
        {
            var updateNote = _userManager.Users.Where(I => I.Id == model.Id).FirstOrDefault();

            if (ModelState.IsValid)
            {
                model.Id = updateNote.Id;
                model.Note = note;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}
