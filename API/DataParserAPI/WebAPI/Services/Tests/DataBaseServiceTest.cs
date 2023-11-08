using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Tests.Intefaces;

namespace WebAPI.Services.Tests
{
    public class DataBaseServiceTest
    {
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;

        public DataBaseServiceTest(ISingletonService singletonService, IScopedService scopedService, ITransientService transientService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
        }


        public void Save()
        {
            Console.WriteLine("\nTEST database service\n");

            Console.WriteLine($"Singleton UID:\t\t{_singletonService.ServiceUniqueIdentifier}");
            Console.WriteLine($"Scoped UID:\t\t{_scopedService.ServiceUniqueIdentifier}");
            Console.WriteLine($"Transient UID:\t\t{_transientService.ServiceUniqueIdentifier}");
        }
    }
}
