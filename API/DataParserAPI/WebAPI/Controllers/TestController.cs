using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Tests;
using WebAPI.Services.Tests.Intefaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController:ControllerBase
    {
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;
        private readonly DataBaseServiceTest _dataBaseServiceTest;

        public TestController(ISingletonService singletonService, IScopedService scopedService, ITransientService transientService, DataBaseServiceTest dataBaseServiceTest)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
            _dataBaseServiceTest = dataBaseServiceTest;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("\nTEST CONTROLLER\n");

            Console.WriteLine($"Singleton UID:\t\t{_singletonService.ServiceUniqueIdentifier}");
            Console.WriteLine($"Scoped UID:\t\t{_scopedService.ServiceUniqueIdentifier}");
            Console.WriteLine($"Transient UID:\t\t{_transientService.ServiceUniqueIdentifier}");
            _dataBaseServiceTest.Save();

            return Ok();
        }
    }
}
