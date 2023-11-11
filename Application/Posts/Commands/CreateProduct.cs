using Domain.Models;
using MediatR;

namespace Application.Posts.Commands
{
    public class CreateProduct : IRequest<Product>
    {
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
    }
}
