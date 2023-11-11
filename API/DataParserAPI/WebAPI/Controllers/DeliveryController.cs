using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Services.Tests.Intefaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController:Controller
    {
        private readonly IOrderService _orderService;
        private readonly ApplicationDbContext _context;
        public DeliveryController(IOrderService orderService, ApplicationDbContext context)
        {
            _orderService = orderService;
            _context = context;
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

        [HttpGet("GetOrderCount")]
        public IActionResult GetOrderCount()
        {
            int orderCount = _context.Orders.Count();

            return Ok(orderCount);
        }
    }
}
