using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReviewMyProduct.WebUI.Controllers
{
    [Authorize(Roles = "administrator")]
    public class AdministratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}