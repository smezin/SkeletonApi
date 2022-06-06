using Microsoft.AspNetCore.Mvc;
using SkeletonApi.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkeletonApi.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<Product> DeleteProduct(int id);
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> PostProduct(Product product);
        Task<IActionResult> PutProduct(int id, Product product);
    }
}