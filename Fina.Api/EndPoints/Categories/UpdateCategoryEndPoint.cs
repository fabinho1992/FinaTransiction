using Fina.Api.Commom.Api;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.Api.EndPoints.Categories
{
    public class UpdateCategoryEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync)
                .WithName("Categories: Update")
                .WithOrder(2)
                .Produces<Response<Category?>>();
        }

        private static async Task<IResult> HandleAsync(UpdateCategoryRequest request, ICategoryService service, long id)
        {
            request.Id = id;
            request.UserId = request.UserId;

            var response = await service.UpdateCategoryAsync(request);
            return response.IsSucess
                ?TypedResults.Ok(response)
                :TypedResults.BadRequest(response);
        }
    }
}
