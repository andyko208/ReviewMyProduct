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
            books = books.OrderBy(b => b.Name).ToList();
            return View(books);
        }

        // List of product, type: Clothing
        public IActionResult Clothings()
        {
            var clothings = _productService.GetByType("Clothings");
            clothings = clothings.OrderBy(c => c.Name).ToList();
            return View(clothings);
        }

        // List of product, type: Furniture
        public IActionResult Furnitures()
        {
            var furnitures = _productService.GetByType("Furnitures");
            furnitures = furnitures.OrderBy(f => f.Name).ToList();
            return View(furnitures);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productToUpdate = _productService.GetById(id);

            return View(productToUpdate);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                var context = new ReviewDbContext();
                var dbProducts = context.Products.Where(p => p.Id == product.Id);
                var dbProduct = dbProducts.Single(p => p.Id == product.Id);
                dbProduct.Name = product.Name;
                dbProduct.Type = product.Type;
                dbProduct.Description = product.Description;
                dbProduct.ImageURL = product.ImageURL;
                dbProduct.ShopURL = product.ShopURL;
                context.SaveChanges();
                return RedirectToAction(product.Type);
            }
            return View(product);
        }

        // Specific details of a certain product
        [HttpGet]
        public IActionResult Details(int id, CreateCommentViewModel vm)
        {
            
            using (var context = new ReviewDbContext())
            {
                vm.Product = _productService.GetById(id);
                vm.Comments = _commentService.GetByProductId(id);
                foreach (var comment in vm.Comments)
                {
                    var upCount = 0;
                    var downCount = 0;
                    foreach (var rating in _ratingService.GetByCommentId(comment.Id))
                    {
                        if (rating.ThumbsUp)
                            upCount++;
                        else
                        {
                            downCount++;
                        }
                    }
                    var dbComments = context.Comments.Where(c => c.productId == id);
                    var dbComment = dbComments.Single(c => c.Id == comment.Id);
                    dbComment.numThumbsUp = upCount;
                    dbComment.numThumbsDown = downCount;
                    context.SaveChanges();
                }
            }
            vm.Comments = vm.Comments.OrderByDescending(c => c.numThumbsUp).ToList();
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
                newComment.UserName = _userManager.GetUserName(User);
                newComment.numThumbsUp = 0;
                newComment.numThumbsDown = 0;
                _commentService.Create(newComment);
                //return RedirectToAction("Details", id);
            }
            return View();
        }

        public IActionResult ThumbsUp(int id, CreateCommentViewModel vm)
        {
            if(User.Identity.IsAuthenticated)
            {
                // if rating found by userId exist as ThumbsUp = true(1) already
                var ratings = _ratingService.GetByCommentUserId(id, _userManager.GetUserId(User));
                int checker = 1;
                foreach(var rating in ratings)
                {
                    if(rating.ThumbsUp == true)
                    {
                        checker = 0;    // user can vote only if checker stays 1 
                    }
                }
                if (checker == 1)       // user can vote ThumbsUp for the comment
                {
                    Rating newRating = new Rating();
                    newRating.ThumbsUp = true;
                    newRating.CommentId = id;
                    newRating.UserId = _userManager.GetUserId(User);
                    _ratingService.Create(newRating);
                    vm.RatingSucceed = true;
                }
                else if (checker == 0)
                {
                    vm.RatingSucceed = false;
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Account");
            }
            return View(vm);
        }

        public IActionResult ThumbsDown(int id, CreateCommentViewModel vm)
        {
            if (User.Identity.IsAuthenticated)
            {
                // if rating found by userId exist as ThumbsUp = false(0) already
                var ratings = _ratingService.GetByCommentUserId(id, _userManager.GetUserId(User));
                int checker = 1;
                foreach (var rating in ratings)
                {
                    if (rating.ThumbsUp == false)
                    {
                        checker = 0;    // user can vote only if checker stays 1 
                    }
                }
                if (checker == 1)       // user can vote ThumbsDown for the comment
                {
                    Rating newRating = new Rating();
                    newRating.ThumbsUp = false;
                    newRating.CommentId = id;
                    newRating.UserId = _userManager.GetUserId(User);
                    _ratingService.Create(newRating);
                    vm.RatingSucceed = true;
                }
                else if (checker == 0)
                {
                    vm.RatingSucceed = false;
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Account");
            }
            return View(vm);
        }
    
    }
}