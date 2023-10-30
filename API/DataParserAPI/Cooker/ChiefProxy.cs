namespace Cooker;

public class ChiefProxy : IChief
{
    private readonly Chief _chief;
    private IDictionary<int, string> _statuses;
    public ChiefProxy(Chief chief)
    {
        _chief = chief;
    }

    public IEnumerable<Order> GetOrders()
    {
        return _chief.GetOrders();
    }

    public IDictionary<int, string> GetSTatuses()
    {
        if (_statuses is null)
        {
            _statuses = _chief.GetSTatuses();
        }
        return _statuses;
    }
}
