using EIS.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EIS.Models;

[Authorize]
public class AnnouncementController : Controller
    {
        private readonly EISContext _announcementManager;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AnnouncementViewModel model)
        {
        _announcementManager.Add(model);
        _announcementManager.SaveChanges();
        return RedirectToAction("Index");
        }
        public AnnouncementController(EISContext announcementManager)
        {
        _announcementManager = announcementManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        
        public IActionResult Edit(int id)
        {
        var announcement = _announcementManager.AspNetAnnouncements.FirstOrDefault(I => I.Id == id);
        if (announcement != null) { 
        AnnouncementViewModel models = new AnnouncementViewModel
        {
            Name = announcement.Name,
            Description = announcement.Description,
        };
        return View(announcement);
        }
        else
        {
           return RedirectToAction("Index");
        }

        }
        public async Task<IActionResult> Delete(int id)
        {
        var announcement = await _announcementManager.AspNetAnnouncements.FindAsync(id);
        if(announcement == null)
        {
            return View();
        }
        _announcementManager.AspNetAnnouncements.Remove(announcement);
        await _announcementManager.SaveChangesAsync();
        return RedirectToAction("Index");
        }
}
