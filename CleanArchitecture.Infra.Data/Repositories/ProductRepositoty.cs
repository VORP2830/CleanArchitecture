using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class ProductRepositoty : IProductRepository
    {
        ApplicationDbContext _ProductContext;

        public ProductRepositoty(ApplicationDbContext context)
        {
            _ProductContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _ProductContext.Add(product);
            await _ProductContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _ProductContext.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _ProductContext.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _ProductContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _ProductContext.Remove(product);
            await _ProductContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _ProductContext.Update(product);
            await _ProductContext.SaveChangesAsync();
            return product;
        }
    }
}