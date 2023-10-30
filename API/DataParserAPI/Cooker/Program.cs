

using Cooker;

IChief chief = new ChiefProxy(new Chief());

while (true)
{
    Thread.Sleep(2100);
    Console.Clear();
    Console.WriteLine("Hello, stranger!");
    Console.WriteLine("--------------------");

    IEnumerable<Order> orders = chief.GetOrders();

    foreach (Order order in orders)
    {
        string status = chief.GetSTatuses().First(s => s.Key == order.StatusId).Value;

        Console.WriteLine($"{order.Name}\t\t{status}");
    }
}