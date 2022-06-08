using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkeletonApi.Models.AppRequests;
using SkeletonApi.Models.Entities.DTOs;
using SkeletonApi.Repositories.Interfaces;
using SkeletonApi.Services.Interfaces;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SkeletonApi.Controllers
{
    /// <summary>
    /// Test global functionality 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        public TestController(IUserService userService, IHttpClientFactory httpClientFactory, 
            ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _userService = userService;
            _httpClientFactory = httpClientFactory;
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;   
        }

        /// <summary>
        /// get data without storing response
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("NoCacheStore")]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public string GetDemo()
        {
            return "testNoStore";
        }
        /// <summary>
        /// get data from cache / and store in cache
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("CacheStore")]
        public string GetDemo1()
        {
            return "testNoStore";
        }
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterModel model)
        {
            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }
        [HttpGet, Route("cat")]
        public async Task<ActionResult> GetCatFact()
        {
            var httpClient = _httpClientFactory.CreateClient("CatFact");
            var response = await httpClient.GetStringAsync("fact");
            return Ok(response);
        }
        [HttpGet, Route("map")]
        public async Task<ActionResult> TestMapper()
        {
            var categories = await _categoriesRepository.GetCategories();
            var category = categories.ToList().FirstOrDefault();
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

    }
}
