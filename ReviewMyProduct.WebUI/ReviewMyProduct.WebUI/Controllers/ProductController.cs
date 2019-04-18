using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Review.Data.Context;
using Review.Data.Implementation.EFCore;
using Review.Domain.Models;
using Review.Service.Services;
using ReviewMyProduct.WebUI.ViewModels;

namespace ReviewMyProduct.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public ProductController(UserManager<AppUser> userManager, IProductService productService, 
            ICommentService commentService)
        {
            _userManager = userManager;
            _productService = productService;
            _commentService = commentService;
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

        // Specific details of a certain product
        public IActionResult Details(int id, CreateCommentViewModel vm)
        {
            vm.Product = _productService.GetById(id);
            //Product currentProduct = _productService.GetById(id);
            // return View(currentProduct);
            vm.Comments = _commentService.GetByProductId(id);
            return View(vm);
        }

        [HttpGet]
        public IActionResult CreateComment() => View();

        [Authorize]
        [HttpPost]
        public IActionResult CreateComment(int id, CreateCommentViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Comment newComment = vm.Comment;
                
                newComment.UserId = _userManager.GetUserId(User);
                newComment.WrittenDate = DateTime.Now;
                newComment.productId = id;
                _commentService.Create(newComment);
            }

            return View(vm);
            //return RedirectToAction("Details");
        }

        // When I have to create another page for comments/rating
        //public IActionResult ViewComment(int id)
        //{
        //    var comments = _commentService.GetByProductId(id);
        //    return View(comments);
        //}

    }
}