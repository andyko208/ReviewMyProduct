using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        // Home page, where user encounters first 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyComments()
        {
            var userId = _userManager.GetUserId(User);
            var comments = _commentService.GetByUserId(userId);

            return View(comments);
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