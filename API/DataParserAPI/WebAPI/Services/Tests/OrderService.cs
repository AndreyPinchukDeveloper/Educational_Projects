using WebAPI.Services.Tests.Intefaces;

namespace WebAPI.Services.Tests
{
    public class OrderService : IOrderService
    {
        public bool IsFreeCourierAvailable()
        {
            return true;
        }
    }
}
