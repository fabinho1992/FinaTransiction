using Fina.Api.Commom.Api;
using Fina.Core;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.EndPoints.Categories
{
    public class GetAllCategoriesEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
        
            app.MapGet("/", HandleAsync)
                .WithName("Categories: GetAll")
                .WithOrder(5)
                .Produces<PagedResponse<List<Category>?>>();


        private static async Task<IResult> HandleAsync(
        ICategoryService handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllCategoryRequest
            {
                UserId = ApiConfiguration.UserId,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };

            var result = await handler.GetAllCategoryAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
