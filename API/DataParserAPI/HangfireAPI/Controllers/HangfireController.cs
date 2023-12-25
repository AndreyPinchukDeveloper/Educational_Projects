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

        [HttpPost]
        [Route("action")]
        public IActionResult Discount()
        {
            int timeInSeconds = 30;
            var jobId = BackgroundJob.Schedule(() => SendWelcomeEmail("Welcome? stranher !"), TimeSpan.FromSeconds(timeInSeconds));
            return Ok($"Job ID: {jobId}. Discount email will be sent in {timeInSeconds} seconds !");
        }

        [HttpPost]
        [Route("action")]
        public IActionResult DatabaseUpdate()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Database was updated"), Cron.Minutely);
            return Ok("Database check job was initiated !");
        }

        [HttpPost]
        [Route("action")]
        public IActionResult Confirm()
        {
            int timeInSeconds = 30;
            var parentJobId = BackgroundJob.Schedule(() => SendWelcomeEmail("Unsubscribe"), TimeSpan.FromSeconds(timeInSeconds));
            BackgroundJob.ContinueJobWith(parentJobId, () => Console.WriteLine("You were unsubscribed :("));
            return Ok($"Confirmation job created !");
        }

        private void SendWelcomeEmail(string text)
        {
            Console.WriteLine(text);
        }
    }
}
