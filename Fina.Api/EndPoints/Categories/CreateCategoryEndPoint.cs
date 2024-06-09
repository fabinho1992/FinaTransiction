using Fina.Api.Commom;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.Api.EndPoints.Categories
{
    public class CreateCategoryEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Categories: Create")
            .WithOrder(1)
            .Produces<Response<Category?>>();
            

        
        private static async Task<IResult> HandleAsync(CreateCategoryRequest request, ICategoryService service)
        {

            request.UserId = ApiConfiguration.UserId;
            var response = await service.CreateCategoryAsync(request);
            return response.IsSucess
                ? TypedResults.Created($"/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }
    }
}
