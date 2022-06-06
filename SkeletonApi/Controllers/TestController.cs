using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkeletonApi.Controllers
{
    /// <summary>
    /// Test global functionality 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestController : ControllerBase
    {
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

    }
}
