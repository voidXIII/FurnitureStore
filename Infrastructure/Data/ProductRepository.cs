using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly FurnitureStoreContext _context;
        public ProductRepository(FurnitureStoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Topology>> GetTopologyAsync()
        {
            return await _context.Topologies.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Topology)
                .Include(p => p.Function)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Topology)
                .Include(p => p.Function)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Function>> GetFunctionsAsync()
        {
            return await _context.Functions.ToListAsync();
        }
    }
}