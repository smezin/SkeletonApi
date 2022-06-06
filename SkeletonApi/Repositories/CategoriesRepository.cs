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
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly SkeletonContext _context;

        public CategoriesRepository(SkeletonContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category is null)
            {
                return default;
            }

            return category;
        }

        public async Task<Category> PutCategory(int id, Category category)
        {
            if (id != category.CategoryID)
            {
                return default;
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return default;
                }
                else
                {
                    throw;
                }
            }

            return category;
        }

        public async Task<Category> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
            {
                return default;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}
