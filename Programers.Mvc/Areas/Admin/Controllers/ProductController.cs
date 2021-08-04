using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using Programers.Entities.ComplexTypes;
using Programers.Entities.Concrete;
using Programers.Entities.Dtos;
using Programers.Mvc.Areas.Admin.Models;
using Programers.Mvc.Helpers.Abstract;
using Programers.Services.Abstract;
using Programers.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;

namespace Programers.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;

        public ProductController(IProductService productService, ICategoryService categoryService,UserManager<User> userManager ,IMapper mapper, IImageHelper imageHelper, IToastNotification toastNotification):base( userManager,mapper, imageHelper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }
        [Authorize(Roles = "SuperAdmin,Product.Read")]

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllByNonDeletedAsync();
            if(result.ResultStatus==ResultStatus.Success) return View(result.Data);
            return NotFound();
        }
        [Authorize(Roles = "SuperAdmin,Product.Create")]

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            if (result.ResultStatus==ResultStatus.Success)
            {
                return View(new ProductAddViewModel
                {
                    Categories = result.Data.Categories
                });
            }

            return NotFound();
        }
        [Authorize(Roles = "SuperAdmin,Product.Create")]

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel productAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var productAddDto = Mapper.Map<ProductAddDto>(productAddViewModel);
                var imageResult = await ImageHelper.Upload(productAddViewModel.Title,
                    productAddViewModel.ThumbnailFile, PictureType.Post);
                productAddDto.Thumbnail = imageResult.Data.FullName;
                var result = await _productService.AddAsync(productAddDto, LoggedInUser.UserName, LoggedInUser.Id);
                //
                if (result.ResultStatus==ResultStatus.Success)
                {
                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                    {
                        Title = "Başarılı İşlem!"
                    });
                    return RedirectToAction("Index", "Producte");
                }
                else
                {
                    ModelState.AddModelError("",result.Message);
                }
            }

            var categories = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            productAddViewModel.Categories = categories.Data.Categories;
            return View(productAddViewModel);
        }
        [Authorize(Roles = "SuperAdmin,Product.Update")]

        [HttpGet]
        public async Task<IActionResult> Update(int productId)
        {
            var productResult = await _productService.GetProductUpdateDtoAsync(productId);
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            if (productResult.ResultStatus==ResultStatus.Success && categoriesResult.ResultStatus==ResultStatus.Success)
            {
                var productUpdateViewModel = Mapper.Map<ProductUpdateViewModel>(productResult.Data);
                productUpdateViewModel.Categories = categoriesResult.Data.Categories;
                return View(productUpdateViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "SuperAdmin,Product.Update")]

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateViewModel productUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                bool isNewThumbnailUploaded = false;
                var oldThumbnail = productUpdateViewModel.Thumbnail;
                if (productUpdateViewModel.ThumbnailFile!=null)
                {
                    var uploadedImageResult = await ImageHelper.Upload(productUpdateViewModel.Title,
                        productUpdateViewModel.ThumbnailFile, PictureType.Post);
                    productUpdateViewModel.Thumbnail = uploadedImageResult.ResultStatus == ResultStatus.Success
                        ? uploadedImageResult.Data.FullName
                        : "postImages/defaultThumbnail.jpg";
                    if (oldThumbnail!= "postImages/defaultThumbnail.jpg")
                    {
                        isNewThumbnailUploaded = true;
                    }
                }
                var productUpdateDto = Mapper.Map<ProductUpdateDto>(productUpdateViewModel);
                var result = await _productService.UpdateAsync(productUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    if (isNewThumbnailUploaded)
                    {
                        ImageHelper.Delete(oldThumbnail);
                    }
                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                    {
                        Title = "Başarılı İşlem!"
                    });
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }

            var categories = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            productUpdateViewModel.Categories = categories.Data.Categories;
            return View(productUpdateViewModel);
        }
        [Authorize(Roles = "SuperAdmin,Product.Delete")]

        [HttpPost]
        public async Task<JsonResult> Delete(int productId)
        {
            var result = await _productService.DeleteAsync(productId, LoggedInUser.UserName);
            var productResult = JsonSerializer.Serialize(result);
            return Json(productResult);
        }
        [Authorize(Roles = "SuperAdmin,Product.Read")]

        [HttpGet]
        public async Task<JsonResult> GetAllProducts()
        {
            var products = await _productService.GetAllByNonDeletedAndActiveAsync();
            var productResult = JsonSerializer.Serialize(products, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(productResult);
        }
        [Authorize(Roles = "SuperAdmin,Product.Read")]
        [HttpGet]
        public async Task<IActionResult> DeletedArticles()
        {
            var result = await _productService.GetAllByDeletedAsync();
            return View(result.Data);

        }
        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllDeletedArticles()
        {
            var result = await _productService.GetAllByDeletedAsync();
            var articles = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(articles);
        }
        [Authorize(Roles = "SuperAdmin,Article.Update")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(int articleId)
        {
            var result = await _productService.UndoDeleteAsync(articleId, LoggedInUser.UserName);
            var undoDeleteArticleResult = JsonSerializer.Serialize(result);
            return Json(undoDeleteArticleResult);
        }
        [Authorize(Roles = "SuperAdmin,Article.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int articleId)
        {
            var result = await _productService.HardDeleteAsync(articleId);
            var hardDeletedArticleResult = JsonSerializer.Serialize(result);
            return Json(hardDeletedArticleResult);
        }

    }
}
