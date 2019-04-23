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
        private readonly IRatingService _ratingService;

        public ProductController(UserManager<AppUser> userManager, IProductService productService, 
            ICommentService commentService, IRatingService ratingService)
        {
            _userManager = userManager;
            _productService = productService;
            _commentService = commentService;
            _ratingService = ratingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // List of product, type: Book
        public IActionResult Books()
        {
            var books = _productService.GetByType("Books");
            return View(books);
        }

        // List of product, type: Clothing
        public IActionResult Clothings()
        {
            var clothings = _productService.GetByType("Clothings");
            return View(clothings);
        }

        // List of product, type: Furniture
        public IActionResult Furnitures()
        {
            var furnitures = _productService.GetByType("Furnitures");
            return View(furnitures);
        }

        // Specific details of a certain product
        [HttpGet]
        public IActionResult Details(int id, CreateCommentViewModel vm)
        {
            vm.Product = _productService.GetById(id);
            vm.Comments = _commentService.GetByProductId(id);

            //need to display the input buttons so that datas can be passed on here
            var upCount = 0;
            var downCount = 0;
            foreach (var comment in vm.Comments)
            {
                foreach (var rating in _ratingService.GetByCommentId(comment.Id))
                {
                    if (rating.ThumbsUp)
                        upCount++;
                    else
                    {
                        downCount++;
                    }
                }
                //comment.Thumbsup = upCount;
                //comment.ThumbsDown = downCount;
            }
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
                //newComment.UserName = _userManager.GetUserName(User);
                _commentService.Create(newComment);
            }

            return View(vm);
            //return RedirectToAction("Details");
        }

        public IActionResult ThumbsUp(int id, CreateCommentViewModel vm)
        {
            if(User.Identity.IsAuthenticated)
            {
                // if rating found by userId exist as ThumbsUp = true(1) already
                if (true)
                {
                    Rating newRating = new Rating();
                    newRating.ThumbsUp = true;
                    newRating.CommentId = id;
                    newRating.UserId = _userManager.GetUserId(User);
                    _ratingService.Create(newRating);
                }
            }
            return View();
        }

        public IActionResult ThumbsDown(int id, CreateCommentViewModel vm)
        {
            if (User.Identity.IsAuthenticated)
            {
                // if rating found by userId exist as ThumbsUp = false(0) already
                if (true)
                {
                    Rating newRating = new Rating();
                    newRating.ThumbsUp = false;
                    newRating.CommentId = id;
                    newRating.UserId = _userManager.GetUserId(User);
                    _ratingService.Create(newRating);
                }
            }
            return View();
        }
        

    // When I have to create another page for comments/rating
    //public IActionResult ViewComment(int id)
    //{
    //    var comments = _commentService.GetByProductId(id);
    //    return View(comments);
    //}
}
}