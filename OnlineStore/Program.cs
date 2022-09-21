using Microsoft.AspNetCore.Http.Json;
using OnlineStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.WriteIndented = true);
var app = builder.Build();

app.MapGet("/catalog", () => Catalog.phones);

app.MapPost("/catalog/add_product", (Phone phone, HttpContext context) =>
{
    Catalog.phones.Add(phone);
    context.Response.StatusCode = 201;
});

app.MapPost("catalog/clear_catalog", (HttpContext context) =>
{
    Catalog.phones.Clear();
    context.Response.StatusCode = 205;
});
    
app.MapGet("/headers", (HttpContext context) => context.Request.Headers);

app.Run();