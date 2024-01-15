using ShoppingListApi.Bootstrap;
using ShoppingListApi.Db;
using ShoppingListApi.Models;
using ShoppingListApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Transient - gets created for every time it is referenced
// Scoped - gets created per request
// Singleton - gets created once only
builder.Services.AddSingleton<IShoppingListService, ShoppingListService>();
builder.Services.AddSingleton<IItemsGenerator, ItemsGenerator>();
builder.Services.AddTaxPolicies();

builder.Services.AddDbContext<ShoppingContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();