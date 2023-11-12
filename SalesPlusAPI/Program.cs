using Application.Abstractions;
using Application.Posts.Commands;
using Application.Posts.Queries;
using DataAccess;
using DataAccess.Repositories;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("LocalSqlServer");

builder.Services.AddDbContext<APIDbContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(typeof(CreateProduct));


var app = builder.Build();

app.MapGet("/api/products/{id}", async (IMediator mediator, int id) =>
{
    var getProduct = new GetProductById { Id = id };
    var product = await mediator.Send(getProduct);
    return Results.Ok(product);
}).WithName("GetProductById");






app.MapPost("/api/products", async (IMediator mediator, Product product) =>
{
    var createproduct = new CreateProduct { ProductCode = product.ProductCode, ProductName = product.ProductName};
    var createdproduct = await mediator.Send(createproduct);
    return Results.CreatedAtRoute("GetProductById", new { createdproduct.Id }, createdproduct);

});

app.MapGet("/api/products", async (IMediator mediator) =>
{
    var getCommand = new GetAllProduct();
    var products = await mediator.Send(getCommand);
    return Results.Ok(products);
});

app.MapPut("/api/products/{id}", async (IMediator mediator, Product product, int id) =>
{
    var updateProduct = new UpdateProduct { Id = id, ProductCode = product.ProductCode, ProductName = product.ProductName };
    var updatedProduct = await mediator.Send(updateProduct);
    return Results.Ok(updatedProduct);

});


app.MapDelete("/api/products/{id}", async (IMediator mediator, int id) =>
{
    var deleteproduct = new DeleteProduct { Id = id };
    var deletedproduct = await mediator.Send(deleteproduct);
    return Results.NoContent();
});

app.UseHttpsRedirection();



app.Run();
