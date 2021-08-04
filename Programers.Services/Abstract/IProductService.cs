using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programers.Entities.ComplexTypes;
using Programers.Entities.Concrete;
using Programers.Entities.Dtos;
using Programers.Shared.Utilities.Results.Abstract;

namespace Programers.Services.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> GetAsync(int productId);
        Task<IDataResult<ProductUpdateDto>> GetProductUpdateDtoAsync(int productId);
        Task<IDataResult<ProductListDto>> GetAllAsync();
        Task<IDataResult<ProductListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<ProductListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataResult<ProductListDto>> GetAllByCategoryAsync(int categoryId);
        Task<IDataResult<ProductListDto>> GetAllByDeletedAsync();
        Task<IDataResult<ProductListDto>> GetAllByViewCountAsync(bool isAscending, int? takeSize);
        Task<IDataResult<ProductListDto>> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 5,
            bool isAscending = false);
        Task<IDataResult<ProductListDto>> GetAllByUserIdOnFilter(int userId, FilterBy filterBy, OrderBy orderBy,
           bool isAscending, int takeSize, int categoryId, DateTime startAt, DateTime endAt, int minViewCount,
           int maxViewCount, int minCommentCount, int maxCommentCount);
        Task<IDataResult<ProductListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 5,
            bool isAscending = false);
        Task<IResult> IncreaseViewCountAsync(int productId);
        Task<IResult> AddAsync(ProductAddDto productAddDto, string createdByName, int userId);
        Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int productId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int productId);
        Task<IResult> UndoDeleteAsync(int productId, string modifiedByName);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
