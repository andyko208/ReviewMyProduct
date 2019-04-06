using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Review.Domain.Models;
using Review.Service.Services;
using ReviewMyProduct.WebUI.ViewModels;

namespace ReviewMyProduct.WebUI.Controllers
{
    [Authorize(Roles = "administrator")]
    public class AdministratorController : Controller
    {
        private readonly IProductService _productService;
        private readonly IHostingEnvironment _environment;

        public AdministratorController(IProductService productService, IHostingEnvironment environment)
        {
            _productService = productService;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateProductViewModel vm)
        {
            // if(ModelState.IsValid) add annotations later [Required] in model for attributes
            Product newProduct = vm.Product;
            IFormFile image = vm.Image;

            // upload image
            if (image != null && image.Length > 0)
            {
                // _environment.WebRootPath --> ~/webroot/images/homes
                string storageFolder = Path.Combine(_environment.WebRootPath, "images/products");

                // 000-1234-dsaf-asgsa.jpg
                string newImageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";

                // ~/wwwroot/images/home/000-1234-dsaf-asgsa.jpg
                string fullPath = Path.Combine(storageFolder, newImageName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // append new image location to new Home
                newProduct.ImageURL = $"/images/products/{newImageName}";
            }
            // newProduct.CommentId = 0; not sure about this yet 4/4
            // save newHome
            _productService.Create(newProduct);


            return RedirectToAction("Index");
        }
    }
}