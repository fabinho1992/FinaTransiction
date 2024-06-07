using Fina.Api.Data;
using Fina.Api.Services;
using Fina.Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var StringConnection = builder.Configuration.GetConnectionString("ConnectionNotbook");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(StringConnection));

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
