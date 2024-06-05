using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Services
{
    public interface ICategoryService
    {
        Task<Response<Category?>> CreateCategoryAsync(CreateCategoryRequest request);
        Task<Response<Category?>> UpdateCategoryAsync(UpdateCategoryRequest request);
        Task<Response<Category?>> DeleteCategoryAsync(DeleteCategoryRequest request);
        Task<Response<Category?>> GetByIdCategoryAsync(CategoryByIdRequest request);
        Task<PagedResponse<List<Category>?>> GetAllCategoryAsync(GetAllCategoryRequest request);
    }
}
