using Fina.Api.Commom;
using Fina.Core;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.Api.EndPoints.Categories
{
    public class GetCategoryByIdEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandleAsync)
                .WithName("Categories: Get By Id")
                .WithOrder(4)
                .Produces<Response<Category?>>();
        }

        private static async Task<IResult> HandleAsync(ICategoryService service, long id)
        {
            var request = new GetCategoryByIdRequest { Id = id, UserId = ApiConfiguration.UserId };

            var result = await service.GetByIdCategoryAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
