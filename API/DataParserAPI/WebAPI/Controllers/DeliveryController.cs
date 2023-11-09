using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController:Controller
    {
        [HttpGet("check-status")]
        public IActionResult CheckStatus()
        {
            return Ok("Active");
        }
    }
}
