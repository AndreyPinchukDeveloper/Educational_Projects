namespace Cooker;
public class Chief : IChief
{
    public IDictionary<int, string> GetSTatuses()
    {
        Dictionary<int, string> statuses = new();

        statuses.Add(1, "ready");
        statuses.Add(2, "ready");
        statuses.Add(3, "ready");

        Thread.Sleep(2000);

        return statuses;
    }

    public IEnumerable<Order> GetOrders()
    {
        List<Order> orders = new();

        orders.Add(new Order { Name = "Meet", StatusId = RandomizeStatus() });
        orders.Add(new Order { Name = "Cheese", StatusId = RandomizeStatus() });
        orders.Add(new Order { Name = "Tomato", StatusId = RandomizeStatus() });

        return orders;
    }

    private static int RandomizeStatus() => new Random().Next(1, 4);
}
