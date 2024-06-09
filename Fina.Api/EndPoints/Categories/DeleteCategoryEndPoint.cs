
using Fina.Api.Commom;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.Api.EndPoints.Categories
{
    public class DeleteCategoryEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", HandleAsync)
                .WithName("Categories: Delete")
                .WithOrder(3)
                .Produces<Response<Category?>>();
        }
        private static async Task<IResult> HandleAsync(ICategoryService service, long id)
        {
            var request = new DeleteCategoryRequest { UserId = ApiConfiguration.UserId, Id = id };

            var result = await service.DeleteCategoryAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
