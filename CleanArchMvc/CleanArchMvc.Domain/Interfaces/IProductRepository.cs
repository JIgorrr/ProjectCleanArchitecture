﻿using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetByIdAsync(int? id);

        Task<Product> GetProductByCategoryAsync(int? categoryId);

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<Product> RemoveAsync(Product product);
    }
}
