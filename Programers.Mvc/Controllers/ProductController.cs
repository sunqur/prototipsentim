using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Programers.Entities.ComplexTypes;
using Programers.Mvc.Models;
using Programers.Services.Abstract;
using Programers.Shared.Utilities.Results.ComplexTypes;
using Programers.Entities.Concrete;
using Microsoft.Extensions.Options;

namespace Programers.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ProductRightSideBarWidgetOptions _productRightSideBarWidgetOptions;

        public ProductController(IProductService productService, IOptionsSnapshot<ProductRightSideBarWidgetOptions> productRightSideBarWidgetOptions)
        {
            _productService = productService;
            _productRightSideBarWidgetOptions = productRightSideBarWidgetOptions.Value;
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage=1,int pageSize=5, bool isAscending=false)
        {
            var searchResult = await _productService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            if (searchResult.ResultStatus == ResultStatus.Success)
                return View(new ProductSearchViewModel
                {
                    ProductListDto = searchResult.Data,
                    Keyword = keyword
                });
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int productId)
        {
            var productResult = await _productService.GetAsync(productId);
            if (productResult.ResultStatus==ResultStatus.Success)
            {
                var userProducts = await _productService.GetAllByUserIdOnFilter(productResult.Data.Product.UserId,
                    _productRightSideBarWidgetOptions.FilterBy, _productRightSideBarWidgetOptions.OrderBy,
                    _productRightSideBarWidgetOptions.IsAscending, _productRightSideBarWidgetOptions.TakeSize,
                    _productRightSideBarWidgetOptions.CategoryId, _productRightSideBarWidgetOptions.StartAt,
                    _productRightSideBarWidgetOptions.EndAt, _productRightSideBarWidgetOptions.MinViewCount,
                    _productRightSideBarWidgetOptions.MaxViewCount, _productRightSideBarWidgetOptions.MinCommentCount,
                    _productRightSideBarWidgetOptions.MaxCommentCount);
                await _productService.IncreaseViewCountAsync(productId);
                return View(new ProductDetailViewModel
                {
                    ProductDto = productResult.Data,
                    ProductDetailRightSideBarViewModel = new ProductDetailRightSideBarViewModel
                    {
                        ProductListDto = userProducts.Data,
                        Header = _productRightSideBarWidgetOptions.Header,
                        User = productResult.Data.Product.User
                    }
                });
            }

            return NotFound();
        }
    }
}
