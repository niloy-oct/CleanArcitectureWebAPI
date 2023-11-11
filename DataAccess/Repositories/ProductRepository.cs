using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly APIDbContext _dbcontext;

        public ProductRepository(APIDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.ProductCode = "";
            product.ProductName = "";
            product.CreationDate = DateTime.Now;
            _dbcontext.Products.Add(product);
            await _dbcontext.SaveChangesAsync();
            return product;
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product, int id)
        {
            throw new NotImplementedException();
        }
    }
}
