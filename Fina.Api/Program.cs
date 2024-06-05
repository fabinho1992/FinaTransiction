using Fina.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var StringConnection = builder.Configuration.GetConnectionString("ConnectionNotbook");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(StringConnection));

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
