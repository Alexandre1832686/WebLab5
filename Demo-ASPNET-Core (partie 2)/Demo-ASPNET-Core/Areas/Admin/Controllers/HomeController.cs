﻿using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPNET_Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
