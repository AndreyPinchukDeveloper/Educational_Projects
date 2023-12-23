using Microsoft.AspNetCore.Mvc;

namespace HangfireAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangfireController:ControllerBase 
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from HanfgireAPI !");
        }
    }
}
