using Fina.Api;
using Fina.Api.Commom.Api;
using Fina.Api.Data;
using Fina.Api.EndPoints;
using Fina.Api.Services;
using Fina.Core.Requests.Categories;
using Fina.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDbContext();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();

app.Run();
