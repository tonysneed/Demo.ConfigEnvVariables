using Microsoft.AspNetCore.Mvc;

namespace ConfigEnvVarPoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        [Route("{key}")]
        public IActionResult Get(string key)
        {
            var value = _configuration[key];
            return Ok(value);
        }
    }
}
