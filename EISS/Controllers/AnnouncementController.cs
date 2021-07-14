using EIS.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
 
    public class AnnouncementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
