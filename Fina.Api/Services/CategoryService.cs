using Fina.Api.Data;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Category?>> CreateCategoryAsync(CreateCategoryRequest request)
        {
            try
            {
                var category = new Category
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Description = request.Description
                };

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return  new Response<Category?>(category, 201, "Categoria criada com sucesso !");
            }
            catch 
            {
                return new Response<Category?>(null, 500, "Não foi possível criar categoria!");
            }
        }

        public async Task<Response<Category?>> DeleteCategoryAsync(DeleteCategoryRequest request)
        {
            try
            {
                var category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == request.Id && c.UserId == request.UserId);
                if (category is null) return new Response<Category?>(null, 404, "Categoria não encontrada");

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return new Response<Category?>(category, message: "Categoria removida!");
            }
            catch 
            {
                return new Response<Category?>(null, 500, "Não foi possivel excluir!");
            }
        }

        public async Task<PagedResponse<List<Category>?>> GetAllCategoryAsync(GetAllCategoryRequest request)
        {
            var query = _context.Categories.AsNoTracking()
                .Where(c => c.UserId == request.UserId)
                .OrderBy(c => c.Title);

            try
            {
                var categories = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Category>?>(categories, count, request.PageNumber, request.PageSize);
            }
            catch 
            {
                return new PagedResponse<List<Category>?>(null, 500, "Não foi possivel encontrar categorias!");
            }
        }

        public async Task<Response<Category?>> GetByIdCategoryAsync(GetCategoryByIdRequest request)
        {
            try
            {
                var category = await _context.Categories.AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == request.Id && c.UserId == request.UserId);

                return category is null
                    ? new Response<Category?>(null, 404, "Categoria não encontrada!")
                    : new Response<Category?>(category);
            }
            catch (Exception)
            {
                return new Response<Category?>(null, 500, "Não foi possivel encontrar categoria!");
            }
        }

        public async Task<Response<Category?>> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            try
            {
                var category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == request.Id && c.UserId == request.UserId);
                if (category is null) return new Response<Category?>(null, 404, "Categoria não encontrada!");

                category.Title = request.Title;
                category.Description = request.Description;

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return new Response<Category?>(category, message: "Categoria atualizada!");
            }
            catch 
            {
                return new Response<Category?>(null, 500, "Não foi possivel atualizar");
            }
        }
    }
}
