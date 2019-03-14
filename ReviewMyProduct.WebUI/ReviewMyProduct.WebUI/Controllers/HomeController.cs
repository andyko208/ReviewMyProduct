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
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductService _productService;

        public HomeController(UserManager<AppUser> userManager, IProductService productService)
        {
            _userManager = userManager;
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            // Create a list by type/country of product and return that certain list
            var product = _productService.GetById(1);
            List<Product> products = new List<Product>();
            products.Append(product);

            return View(products);

            // make user choose options: select products by certain type and provide buttons that to redirect
            // Product product1;
            //if (product1.Type == userinputType)
            //    return product1;
        }

        //[HttpGet]
        //public IActionResult Create() => View();

        //[Authorize(Roles = "Administrator")]
        //[HttpPost]
    }
}