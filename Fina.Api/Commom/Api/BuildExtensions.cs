using Fina.Api.Data;
using Fina.Api.Services;
using Fina.Core;
using Fina.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;

namespace Fina.Api.Commom.Api
{
    public static class BuildExtensions
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuration.BackEndUrl = builder.Configuration.GetValue<string>("BackEndUrl") ?? string.Empty;
            Configuration.FrontEndUrl = builder.Configuration.GetValue<string>("FrontEndUrl") ?? string.Empty;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen( x => 
            {
                x.CustomSchemaIds(n => n.FullName);
                });
        }

        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(ApiConfiguration.ConnectionString));
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
           options => options.AddPolicy(
               ApiConfiguration.CorsPolicyName,
               policy => policy
                   .WithOrigins([
                       Configuration.BackEndUrl,
                        Configuration.FrontEndUrl
                   ])
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials()
           ));
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddTransient<ITransactionService, TransactionService>();
            builder.Services
                .AddTransient<ICategoryService, CategoryService>();
        }
    }
}
