using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product Product)
        {
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return Product;
        }

        public  async Task Delete(int id)
        {
            var productToDelete = await _context.Products.FindAsync(id);
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }

        public  async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public  async Task Update(Product Product)
        {
            _context.Entry(Product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
