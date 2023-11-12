using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using SalesPlusAPI;

var builder = WebApplication.CreateBuilder(args);
builder.ResisterServices();

var app = builder.Build();

app.UseHttpsRedirection();
app.ResisterEndpointDefinations();


app.Run();
