using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programers.Entities.Concrete;
using Programers.Mvc.Areas.Admin.Models;
using Programers.Services.Abstract;
using Programers.Shared.Utilities.Results.ComplexTypes;

namespace Programers.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
 
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;

        public HomeController(ICategoryService categoryService, IProductService productService, ICommentService commentService, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _productService = productService;
            _commentService = commentService;
            _userManager = userManager;
        }
        [Authorize(Roles = "SuperAdmin,AdminArea.Home.Read")]

        public async Task<IActionResult> Index()
        {
            var categoriesCountResult = await _categoryService.CountByNonDeletedAsync();
            var productsCountResult = await _productService.CountByNonDeletedAsync();
            var commentsCountResult = await _commentService.CountByNonDeletedAsync();
            var usersCount = await _userManager.Users.CountAsync();
            var productsResult = await _productService.GetAllAsync();
            if (categoriesCountResult.ResultStatus == ResultStatus.Success && productsCountResult.ResultStatus == ResultStatus.Success && commentsCountResult.ResultStatus == ResultStatus.Success && usersCount > -1 && productsResult.ResultStatus == ResultStatus.Success)
            {
                return View(new DashboardViewModel
                {
                    CategoriesCount = categoriesCountResult.Data,
                    ProductsCount = productsCountResult.Data,
                    CommentsCount = commentsCountResult.Data,
                    UsersCount = usersCount,
                    Products = productsResult.Data
                });
            }

            return NotFound();

        }
    }
}
