namespace Cooker.ProxyPattern
{
    public interface IChief
    {
        IEnumerable<Order> GetOrders();
        IDictionary<int, string> GetSTatuses();
    }
}