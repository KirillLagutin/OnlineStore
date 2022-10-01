/*
1 Добавьте Swagger к своему проекту
2 Сделайте добавление товаров в каталог потокобезопасным
3 Реализуйте потокобезопасное чтение товаров из каталога
4 * Реализуйте потокобезопасный каталог с использованием потокобезопасной коллекции
5 * Реализуйте потокобезопасное удаление товара из каталога
*/

using Microsoft.AspNetCore.Http.Json;
using OnlineStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.WriteIndented = true);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var tabs = new Tabs();
var phones = new Phones();

/* Использование потокобезопасной коллекции */
app.MapGet("/catalog/get_tabs", () => tabs.GetTabs());

app.MapPost("/catalog/add_tab", (Tab tab) => tabs.AddTabs(tab));

app.MapGet("/catalog/delete_tab", (int id) => tabs.DeleteTab(id));


/*Использование lock*/
app.MapGet("/catalog/get_phones", () => phones.GetPhones());

app.MapPost("/catalog/add_phone", (Phone phone, HttpContext context) =>
{
    phones.AddPhone(phone);
    context.Response.StatusCode = 201;
});

app.MapPost("catalog/clear_phones", (HttpContext context) =>
{
    phones.ClearPhones();
    context.Response.StatusCode = 205;
});

app.MapGet("/headers", (HttpContext context) => context.Request.Headers);


app.Run();