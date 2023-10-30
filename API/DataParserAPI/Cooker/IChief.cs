namespace Cooker
{
    public interface IChief
    {
        IEnumerable<Order> GetOrders();
        IDictionary<int, string> GetSTatuses();
    }
}