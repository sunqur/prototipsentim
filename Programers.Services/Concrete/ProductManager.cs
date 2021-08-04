using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Programers.Data.Abstract;
using Programers.Entities.ComplexTypes;
using Programers.Entities.Concrete;
using Programers.Entities.Dtos;
using Programers.Services.Abstract;
using Programers.Services.Utilities;
using Programers.Shared.Utilities.Results.Abstract;
using Programers.Shared.Utilities.Results.ComplexTypes;
using Programers.Shared.Utilities.Results.Concrete;

namespace Programers.Services.Concrete
{
    public class ProductManager : ManagerBase, IProductService
    {

        private readonly UserManager<User> _userManager;
        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) :base(unitOfWork, mapper)
        {
            _userManager = userManager;
        }

        public async Task<IDataResult<ProductDto>> GetAsync(int productId)
        {
            var product = await UnitOfWork.Products.GetAsync(a => a.Id == productId, a => a.User, a => a.Category);
            if (product != null)
            {
                product.Comments = await UnitOfWork.Comments.GetAllAsync(c => c.ProductId == productId && !c.IsDeleted && c.IsActive);
                return new DataResult<ProductDto>(ResultStatus.Success, new ProductDto
                {
                    Product = product,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ProductListDto>> GetAllAsync()
        {
            var products = await UnitOfWork.Products.GetAllAsync(null, a => a.User, a => a.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ProductListDto>> GetAllByNonDeletedAsync()
        {
            var products = await UnitOfWork.Products.GetAllAsync(a => !a.IsDeleted, ar => ar.User, ar => ar.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ProductListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var products =
                await UnitOfWork.Products.GetAllAsync(a => !a.IsDeleted && a.IsActive, ar => ar.User,
                    ar => ar.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ProductListDto>> GetAllByCategoryAsync(int categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var products = await UnitOfWork.Products.GetAllAsync(
                    a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, ar => ar.User, ar => ar.Category);
                if (products.Count > -1)
                {
                    return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                    {
                        Products = products,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), null);

        }

        public async Task<IResult> AddAsync(ProductAddDto productAddDto, string createdByName, int userId)
        {
            var product = Mapper.Map<Product>(productAddDto);
            product.CreatedByName = createdByName;
            product.ModifiedByName = createdByName;
            product.UserId = userId;
            await UnitOfWork.Products.AddAsync(product);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Product.Add(product.Title));
        }

        public async Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto, string modifiedByName)
        {
            var oldProduct = await UnitOfWork.Products.GetAsync(a => a.Id == productUpdateDto.Id);
            var product = Mapper.Map<ProductUpdateDto,Product>(productUpdateDto,oldProduct);
            product.ModifiedByName = modifiedByName;
            await UnitOfWork.Products.UpdateAsync(product);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Product.Update(product.Title));
        }
            
        public async Task<IResult> DeleteAsync(int productId, string modifiedByName)
        {
            var result = await UnitOfWork.Products.AnyAsync(a => a.Id == productId);
            if (result)
            {
                var product = await UnitOfWork.Products.GetAsync(a => a.Id == productId);
                product.IsDeleted = true;
                product.IsActive = false;
                product.ModifiedByName = modifiedByName;
                product.ModifiedDate = DateTime.Now;
                await UnitOfWork.Products.UpdateAsync(product);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Product.Delete(product.Title));
            }
            return new Result(ResultStatus.Error, Messages.Product.NotFound(isPlural: false));
        }

        public async Task<IResult> HardDeleteAsync(int productId)
        {
            var result = await UnitOfWork.Products.AnyAsync(a => a.Id == productId);
            if (result)
            {
                var product = await UnitOfWork.Products.GetAsync(a => a.Id == productId);
                await UnitOfWork.Products.DeleteAsync(product);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Product.HardDelete(product.Title));
            }
            return new Result(ResultStatus.Error, Messages.Product.NotFound(isPlural: false));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var productsCount = await UnitOfWork.Products.CountAsync();
            if (productsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, productsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var productsCount = await UnitOfWork.Products.CountAsync(a => !a.IsDeleted);
            if (productsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, productsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<ProductUpdateDto>> GetProductUpdateDtoAsync(int productId)
        {
            var result = await UnitOfWork.Products.AnyAsync(a => a.Id == productId);
            if (result)
            {
                var product = await UnitOfWork.Products.GetAsync(a => a.Id == productId);
                var productUpdateDto = Mapper.Map<ProductUpdateDto>(product);
                return new DataResult<ProductUpdateDto>(ResultStatus.Success, productUpdateDto);
            }
            else
            {
                return new DataResult<ProductUpdateDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: false), null);
            }
        }

        public async Task<IDataResult<ProductListDto>> GetAllByDeletedAsync()
        {
            var products =
                await UnitOfWork.Products.GetAllAsync(a => a.IsDeleted, ar => ar.User,
                    ar => ar.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }

        public async Task<IResult> UndoDeleteAsync(int productId, string modifiedByName)
        {
            var result = await UnitOfWork.Products.AnyAsync(a => a.Id == productId);
            if (result)
            {
                var product = await UnitOfWork.Products.GetAsync(a => a.Id == productId);
                product.IsDeleted = false;
                product.IsActive = true;
                product.ModifiedByName = modifiedByName;
                product.ModifiedDate = DateTime.Now;
                await UnitOfWork.Products.UpdateAsync(product);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Product.UndoDelete(product.Title));
            }
            return new Result(ResultStatus.Error, Messages.Product.NotFound(isPlural: false));
        }

        public async Task<IDataResult<ProductListDto>> GetAllByViewCountAsync(bool isAscending, int? takeSize)
        {
            var products =
                await UnitOfWork.Products.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Category, a => a.User);
            var sortedProducts = isAscending
                ? products.OrderBy(a => a.ViewsCount)
                : products.OrderByDescending(a => a.ViewsCount);
            return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
            {
                Products = takeSize == null ? sortedProducts.ToList() : sortedProducts.Take(takeSize.Value).ToList()
            });
        }

        public async Task<IDataResult<ProductListDto>> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var products = categoryId == null
                ? await UnitOfWork.Products.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Category, a => a.User)
                : await UnitOfWork.Products.GetAllAsync(a => a.CategoryId == categoryId && a.IsActive && !a.IsDeleted,
                    a => a.Category, a => a.User);
            var sortedProducts = isAscending
                ? products.OrderBy(a => a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : products.OrderByDescending(a => a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
            {
                Products = sortedProducts,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = products.Count,
                IsAscending = isAscending
            });
        }

        public async Task<IDataResult<ProductListDto>> GetAllByUserIdOnFilter(int userId, FilterBy filterBy,
            OrderBy orderBy, bool isAscending, int takeSize,int categoryId, DateTime startAt,
            DateTime endAt, int minViewCount, int maxViewCount, int minCommentCount, int maxCommentCount)
        {
            var anyUser = await _userManager.Users.AnyAsync(u => u.Id == userId);
            if (!anyUser)
            {
                return new DataResult<ProductListDto>(ResultStatus.Error, $"{userId} numaralı kullanıcı bulunamadı.",
                    null);
            }

            var userProducts =
                await UnitOfWork.Products.GetAllAsync(a => a.IsActive && !a.IsDeleted && a.UserId == userId);
            List<Product> sortedProducts = new List<Product>();
            switch (filterBy)
            {
                case FilterBy.Category:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.CategoryId == categoryId).Take(takeSize)
                                    .OrderBy(a => a.Date).ToList()
                                : userProducts.Where(a => a.CategoryId == categoryId).Take(takeSize)
                                    .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.CategoryId == categoryId).Take(takeSize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userProducts.Where(a => a.CategoryId == categoryId).Take(takeSize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.CategoryId == categoryId).Take(takeSize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userProducts.Where(a => a.CategoryId == categoryId).Take(takeSize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.Date:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderBy(a => a.Date).ToList()
                                : userProducts.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userProducts.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userProducts.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.ViewCount:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderBy(a => a.Date).ToList()
                                : userProducts.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userProducts.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userProducts.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takeSize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.CommentCount:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedProducts = isAscending
                                ? userProducts.Where(a =>
                                        a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderBy(a => a.Date).ToList()
                                : userProducts.Where(a =>
                                        a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userProducts.Where(a => a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedProducts = isAscending
                                ? userProducts.Where(a => a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userProducts.Where(a => a.CommentCount >= minCommentCount && a.CommentCount <= maxCommentCount)
                                    .Take(takeSize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }

                    break;
            }

            return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
            {
                Products = sortedProducts
            });
        }

        public async Task<IDataResult<ProductListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                var products =
                    await UnitOfWork.Products.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Category,
                        a => a.User);
                var sortedProducts = isAscending
                    ? products.OrderBy(a => a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                    : products.OrderByDescending(a => a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = sortedProducts,
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalCount = products.Count,
                    IsAscending = isAscending
                });
            }

            var searchedProducts = await UnitOfWork.Products.SearchAsync(new List<Expression<Func<Product, bool>>>
            {
                (a) => a.Title.Contains(keyword),
                (a) => a.Category.Name.Contains(keyword),
                (a) => a.SeoDescription.Contains(keyword),
                (a) => a.SeoTags.Contains(keyword)
            },
            a => a.Category, a => a.User);
            var searchedAndSortedProducts = isAscending
                ? searchedProducts.OrderBy(a => a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : searchedProducts.OrderByDescending(a => a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
            {
                Products = searchedAndSortedProducts,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = searchedProducts.Count,
                IsAscending = isAscending
            });
        }

        public async Task<IResult> IncreaseViewCountAsync(int productId)
        {
            var product = await UnitOfWork.Products.GetAsync(a => a.Id == productId);
            if (product == null)
            {
                return new Result(ResultStatus.Error, Messages.Product.NotFound(isPlural: false));
            }

            product.ViewsCount += 1;
            await UnitOfWork.Products.UpdateAsync(product);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Product.IncreaseViewCount(product.Title));
        }
    }
}
