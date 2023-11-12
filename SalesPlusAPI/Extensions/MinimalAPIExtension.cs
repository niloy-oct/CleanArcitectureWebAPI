using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess.Repositories;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SalesPlusAPI
{
    public static class MinimalAPIExtension
    {
        public static void ResisterServices(this WebApplicationBuilder builder)
        {
            var connection = builder.Configuration.GetConnectionString("LocalSqlServer");

            builder.Services.AddDbContext<APIDbContext>(opt => opt.UseSqlServer(connection));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddMediatR(typeof(CreateProduct));

        }

    }
}
