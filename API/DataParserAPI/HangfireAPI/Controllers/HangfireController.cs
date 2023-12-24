using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangfireAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController:ControllerBase 
    {
        [HttpPost]
        [Route("action")]
        public IActionResult Welcome()
        {
            var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome? stranher !"));
            return Ok($"Job ID: {jobId}. Welcome email sent to user !");
        }

        private void SendWelcomeEmail(string text)
        {
            Console.WriteLine(text);
        }
    }
}
