using Fina.Api.Commom.Api;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.Api.EndPoints.Transactions
{
    public class CreateTransactionEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync)
                .WithName("Transactions: Create")
                .WithOrder(1)
                .Produces<Response<Category?>>();
        }

        private static async Task<IResult> HandleAsync(CreateTransactionRequest request, ITransactionService service)
        {
            request.UserId = ApiConfiguration.UserId;
            var response = await service.CreateTransactionAsync(request);
            return response.IsSucess
                ? TypedResults.Created($"/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }
    }
}
