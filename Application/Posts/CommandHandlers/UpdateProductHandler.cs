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
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, Product>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.UpdateProduct(request, request.Id);
            return product;
        }
    }
}
