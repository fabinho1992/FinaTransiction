using Fina.Api.Data;
using Fina.Api.Services;
using Fina.Core.Requests.Categories;
using Fina.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



var StringConnection = builder.Configuration.GetConnectionString("ConnectionNotbook");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(StringConnection));

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();

var app = builder.Build();



app.MapGet("/", (GetAllCategoryRequest request, ICategoryService service) => service.GetAllCategoryAsync(request));



app.Run();
