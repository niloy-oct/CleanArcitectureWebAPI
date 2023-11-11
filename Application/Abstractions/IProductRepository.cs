using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);

        Task<Product> UpdateProduct(Product product, int id);
        Task DeleteProduct(int id);
        
    }
}
