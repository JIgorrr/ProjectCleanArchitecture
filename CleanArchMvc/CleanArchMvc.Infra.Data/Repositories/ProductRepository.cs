using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
           return await _context.Products.FindAsync(id);
        }

        public async Task<Product> GetProductByCategoryAsync(int? categoryId)
        {
            return await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == categoryId);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
