using Application.Abstractions;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("LocalSqlServer");

builder.Services.AddDbContext<APIDbContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();

app.UseHttpsRedirection();



app.Run();
