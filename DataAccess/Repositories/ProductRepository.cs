using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteProduct(int id)
        {
            var product = await _dbcontext.Products.FindAsync(id);

            if (product != null) return;

            _dbcontext.Products.Remove(product);

            await _dbcontext.SaveChangesAsync();

        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            return await _dbcontext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbcontext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> UpdateProduct(UpdateProduct command, int id)
        {
            var objproduct = await _dbcontext.Products.FirstOrDefaultAsync(x => x.Id == id);
            objproduct.ProductCode = command.ProductCode;
            objproduct.ProductName = command.ProductName;

            objproduct.ModifactionDate = DateTime.Now;

            await _dbcontext.SaveChangesAsync();

            return objproduct;
        }
    }
}
