using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Review.Domain.Models;
using Review.Service.Services;

namespace ReviewMyProduct.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // Home page, where user encounters first 
        public IActionResult Index()
        {
            return View();
        }
    }
}