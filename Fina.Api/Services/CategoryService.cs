using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.Api.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<Response<Category?>> CreateCategoryAsync(CreateCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category?>> DeleteCategoryAsync(DeleteCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Category>?>> GetAllCategoryAsync(GetAllCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category?>> GetByIdCategoryAsync(CategoryByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category?>> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
