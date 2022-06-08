using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SkeletonApi.Models.Entities;
using SkeletonApi.Repositories.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkeletonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductsRepository _productsRepository;

        public ProductsController(ILogger logger, IProductsRepository productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _productsRepository.GetProducts();
            if (products is null)
            {
                _logger.Information($"No products found.");
                return new List<Product>();
            }
            return products;
        }
        [HttpGet("{id:int}")]
        public async Task<Product> GetProduct(int id)
        {
            var product = await _productsRepository.GetProduct(id);
            if (product is null)
            {
                _logger.Information($"ProductId: {id} not found.");
                return default;
            }
            return product;
        }
    }
}
