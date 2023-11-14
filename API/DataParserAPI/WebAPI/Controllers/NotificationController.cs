using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class NotificationController:ControllerBase
    {
        [HttpPost]
        [Route("test-method")]
        public IActionResult TestControllerMethod(string client)
        {
            string jobId = BackgroundJob.Enqueue(() =>
                Console.WriteLine($"{client}, be happy !"));
            return Ok($"JobId: {jobId}");
        }

        [HttpPost]
        [Route("Delayed")]
        public IActionResult Delayed(string client)
        {
            string jobId = BackgroundJob.Schedule(() =>
                Console.WriteLine($"Session for client {client}, be happy !"), TimeSpan.FromSeconds(60));
            return Ok($"Job Id: {jobId}");
        }

        [HttpPost]
        [Route("Recurring")]
        public IActionResult Recurring(string client)
        {
            RecurringJob.AddOrUpdate(() =>
                Console.WriteLine($"Happy birthday {client}, be happy !"), Cron.Daily);
            return Ok();
        }

        [HttpPost]
        [Route("Continuations")]
        public IActionResult Continuations(string client)
        {
            string jobId = BackgroundJob.Enqueue(() =>
                Console.WriteLine($"Check balance for {client}, be happy !"));

            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine($"{client} your balance has been changed !"));
            return Ok();
        }
    }
}
