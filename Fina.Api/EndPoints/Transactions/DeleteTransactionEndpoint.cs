using Fina.Api.Commom;
using Fina.Core;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.Api.EndPoints.Transactions
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", HandleAsync)
                .WithName("Transaction: Delete")
                .WithOrder(3)
                .Produces<Response<Category?>>();
        }
        private static async Task<IResult> HandleAsync(ITransactionService service, long id)
        {
            var response = new DeleteTransactionRequest { Id = id, UserId = ApiConfiguration.UserId };

            var result = await service.DeleteTransactionAsync(response);
            return result.IsSucess
                ?TypedResults.Ok(result)
                :TypedResults.BadRequest(result);
        }
    }
}
