using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkeletonApi.Contexts;
using SkeletonApi.Models.Entities;
using SkeletonApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkeletonApi.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly SkeletonContext _context;

        public ProductsRepository(SkeletonContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }


        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
            {
                return default;
            }

            return product;
        }


        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return default;
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return default;
                }
                else
                {
                    throw;
                }
            }

            return default;
        }


        public async Task<Product> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        [HttpDelete("{id}")]
        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                return default;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
