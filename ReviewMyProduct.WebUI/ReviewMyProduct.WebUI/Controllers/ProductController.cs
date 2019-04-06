using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Review.Data.Implementation.EFCore;
using Review.Domain.Models;
using Review.Service.Services;

namespace ReviewMyProduct.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductService _productService;
        private readonly EFCoreProductRepository _ProdRepo;

        public ProductController(UserManager<AppUser> userManager, IProductService productService)
        {
            _userManager = userManager;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // List of product, type: Book
        public IActionResult Books()
        {
            var books = _productService.GetByType("Book");
            return View(books);
        }

        // List of product, type: Clothing
        public IActionResult Clothing()
        {
            var clothings = _productService.GetByType("Clothing");
            return View(clothings);
        }

        // List of product, type: Furniture
        public IActionResult Furnitures()
        {
            var furnitures = _productService.GetByType("Furniture");
            return View(furnitures);
        }

        public IActionResult Detail(int id)
        {
            return View(_ProdRepo.GetById(id));
        }
    }
}