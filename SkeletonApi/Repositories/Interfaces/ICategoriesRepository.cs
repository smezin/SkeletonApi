using Microsoft.AspNetCore.Mvc;
using SkeletonApi.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkeletonApi.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<Category> DeleteCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> PostCategory(Category category);
        Task<Category> PutCategory(int id, Category category);
    }
}