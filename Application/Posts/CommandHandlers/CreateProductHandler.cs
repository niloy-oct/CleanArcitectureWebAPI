using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, Product>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var newproduct = new Product
            {
                ProductCode = request.ProductCode,
                ProductName = request.ProductName
            };

            return await _productRepository.CreateProduct(newproduct);
        }
   
    }
}
