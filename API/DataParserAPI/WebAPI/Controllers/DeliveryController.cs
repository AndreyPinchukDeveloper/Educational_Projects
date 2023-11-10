using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Tests.Intefaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController:Controller
    {
        private readonly IOrderService _orderService;
        public DeliveryController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("check-status")]
        public IActionResult CheckStatus()
        {
            return Ok("Active");
        }

        [HttpPost("send-order")]
        public IActionResult SendOrder()
        {
            try
            {
                return _orderService.IsFreeCourierAvailable() ? Ok() : NotFound("There's not available courier !"); 
            }
            catch
            {

                return BadRequest("Order was canceled");
            }
        }

        
    }
}
