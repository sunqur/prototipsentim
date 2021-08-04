using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Programers.Mvc.Models;
using Programers.Services.Abstract;

namespace Programers.Mvc.ViewComponents
{
    public class RightSideBarViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public RightSideBarViewComponent(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            var productResult = await _productService.GetAllByViewCountAsync(isAscending: false, takeSize: 5);
            return View(new RightSideBarViewModel
            {
                Categories = categoriesResult.Data.Categories,
                Products = productResult.Data.Products
            });
        }
    }
}
