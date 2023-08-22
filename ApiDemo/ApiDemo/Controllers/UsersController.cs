using ApiDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return $"value {id}";
        }

        [HttpGet]
        public string Get()
        {
            XMLService.GenerateXMLFile();
            return "";
        }
    }
}
