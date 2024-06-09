using Fina.Api.Commom;
using Fina.Core;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Fina.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.EndPoints.Transactions
{
    public class GetTransactionsPeriodEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync)
                .WithName("Transaction: Get Period")
                .WithOrder(5)
                .Produces<PagedResponse<List<Transaction>?>>();
        }

        public static async Task<IResult> HandleAsync(ITransactionService service,
            [FromQuery] DateTime? starDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize
            )
        {
            var request = new GetTransictionByPeriodRequest
            { UserId = ApiConfiguration.UserId, StartDate = starDate, EndDate = endDate, PageNumber = pageNumber, PageSize = pageSize };

            var result = await service.GetTransactionByPeriodAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
