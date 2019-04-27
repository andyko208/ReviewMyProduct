using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Review.Data.Context;
using Review.Domain.Models;
using Review.Service.Services;
using ReviewMyProduct.WebUI.ViewModels;

namespace ReviewMyProduct.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public HomeController(UserManager<AppUser> userManager, IProductService productService,
            ICommentService commentService)
        {
            _userManager = userManager;
            _productService = productService;
            _commentService = commentService;

        }

        public async Task<IActionResult> Index(string productType, string searchString)
        {
            var context = new ReviewDbContext();

            var products = from p in context.Products
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
                return View(await products.ToListAsync());
            }

            return View();
        }

        public IActionResult MyComments(MyCommentsViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                vm.Comments = _commentService.GetByUserId(userId);
                ICollection<Product> products = new List<Product>();
                foreach (var comment in vm.Comments)
                {
                    var product = _productService.GetById(comment.productId);
                    products.Add(product);
                }
                vm.Products = products;
            }
            return View(vm);
        }

        public IActionResult DeleteComments(int id)
        {
            var comment = _commentService.GetById(id);
            return View(comment);
        }

        [HttpPost]
        public IActionResult DeleteComments(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentService.DeleteById(comment.Id);
            }
            return RedirectToAction("MyComments", "home");
        }
    }
}