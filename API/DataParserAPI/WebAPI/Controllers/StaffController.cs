using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController:ControllerBase
    {
        private readonly ILogger<StaffController> _logger;
        private readonly IStaffRepository _staffRepository;
        public StaffController(ILogger<StaffController> logger, IStaffRepository staffRepository = null)
        {
            _logger = logger;
            _staffRepository = staffRepository;
        }

        [HttpGet("employees")]
        public ActionResult GetAllEmployees() 
        {
            var employees = _staffRepository.GetAllEmployees();
            return Ok(employees);
        }
    }
}
