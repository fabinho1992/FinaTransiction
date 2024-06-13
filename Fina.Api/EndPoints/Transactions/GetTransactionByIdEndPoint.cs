using Fina.Api.Commom.Api;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.Api.EndPoints.Transactions
{
    public class GetTransactionByIdEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandleAsync)
                .WithName("Transaction: Get By Id")
                .WithOrder(4)
                .Produces<Response<Transaction?>>();
        }

        private static async Task<IResult> HandleAsync(ITransactionService service, long id)
        {
            var response = new GetTransactionByIdRequest { Id = id, UserId = ApiConfiguration.UserId };

            var result = await service.GetTransactionByIdAsync(response);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);  
        }
    }
}
