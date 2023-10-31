using Cooker.FactoryMethod.Factory;
using Cooker.ProxyPattern;

#region ProxyPattern
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
#endregion

#region FactoryMethod
static void Main()
{
    Console.WriteLine("Hi everyone !");

    Console.WriteLine("Enter what you want !");

    Console.WriteLine("> G - Gym");
    Console.WriteLine("> P - Gym and swimming");
    Console.WriteLine("> T - VIP");

    string membershipType = Console.ReadLine();
}

static MembershipFactory GetFactory()
{
    return membershipType.
}
#endregion