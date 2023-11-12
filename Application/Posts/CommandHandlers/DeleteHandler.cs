using Application.Abstractions;
using Application.Posts.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.CommandHandlers
{
    public class DeleteHandler : IRequestHandler<DeleteProduct>
    {
        private readonly IProductRepository _productRepository;

        public DeleteHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteProduct(request.Id);
            return Unit.Value;
        }
    }
}
