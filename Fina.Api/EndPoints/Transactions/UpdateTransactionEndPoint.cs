using Fina.Api.Commom.Api;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.Api.EndPoints.Transactions
{
    public class UpdateTransactionEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync)
                .WithName("Transaction: Update")
                .WithOrder(2)
                .Produces<Response<Category?>>();
        }

        private static async Task<IResult> HandleAsync(UpdateTransactionRequest request, ITransactionService service, long id)
        {
            request.Id = id;
            request.UserId = ApiConfiguration.UserId;

            var result = await service.UpdateTransactionAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
