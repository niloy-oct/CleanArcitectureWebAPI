using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess.Repositories;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesPlusAPI.Abstructions;

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

        public static void ResisterEndpointDefinations(this WebApplication app)
        {
            var endpointDefinations = typeof(Program).Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefination))
                    && !t.IsAbstract && !t.IsInterface)
                .Select(t => (IEndpointDefination)Activator.CreateInstance(t));

            foreach (var endpointDefination in endpointDefinations)
            {
                endpointDefination.ResisterEndPoint(app);
            }
        }

    }
}
