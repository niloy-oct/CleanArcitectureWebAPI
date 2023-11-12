using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess;
using DataAccess.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("LocalSqlServer");

builder.Services.AddDbContext<APIDbContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(typeof(CreateProduct));


var app = builder.Build();

app.UseHttpsRedirection();



app.Run();
