﻿using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Category> CreateCategoriesAsync(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
