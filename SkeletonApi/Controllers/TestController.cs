using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkeletonApi.Models.AppRequests;
using SkeletonApi.Services.Interfaces;
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

        public TestController(IUserService userService)
        {
            _userService = userService;
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

    }
}
