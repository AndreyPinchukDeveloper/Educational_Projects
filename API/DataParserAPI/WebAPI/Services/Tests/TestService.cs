using WebAPI.Services.Tests.Intefaces;

namespace WebAPI.Services.Tests
{
    public class TestService : ISingletonService, IScopedService, ITransientService
    {
        public string ServiceUniqueIdentifier { get; } = Guid.NewGuid().ToString(); 
    }
}
