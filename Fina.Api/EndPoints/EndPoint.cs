using Fina.Api.Commom.Api;
using Fina.Api.EndPoints.Categories;
using Fina.Api.EndPoints.Transactions;

namespace Fina.Api.EndPoints
{
    public static class EndPoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endPoints = app.MapGroup("");

            endPoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "Ok" });

            endPoints.MapGroup("v1/categories").
                WithTags("Categories")
                .MapEndPoint<CreateCategoryEndPoint>()
                .MapEndPoint<UpdateCategoryEndPoint>()
                .MapEndPoint<DeleteCategoryEndPoint>()
                .MapEndPoint<GetCategoryByIdEndPoint>()
                .MapEndPoint<GetAllCategoriesEndPoint>();

            endPoints.MapGroup("v1/transactions").
                WithTags("Transactions")
                .MapEndPoint<CreateTransactionEndPoint>()
                .MapEndPoint<UpdateTransactionEndPoint>()
                .MapEndPoint<DeleteTransactionEndpoint>()
                .MapEndPoint<GetTransactionByIdEndPoint>()
                .MapEndPoint<GetTransactionsPeriodEndPoint>();

        }

        private static IEndpointRouteBuilder MapEndPoint<TEndPoint>(this IEndpointRouteBuilder app) where TEndPoint : IEndpoint 
        {
            TEndPoint.Map(app);
            return app;
        }
    }
}
