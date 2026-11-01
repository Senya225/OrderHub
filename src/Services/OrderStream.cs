using OrderHub.Domain;

namespace OrderHub.Services;

public class OrderStream
{
    public static IEnumerable<Order> Orders()
    {
        int n = 1;
        while (true)
        {
            Console.WriteLine($"Готовлю заказ #{n}");
            yield return new Order(n, "Иванов", "Товар", 1000m * n, DateTime.Now);
            n++;
        }
    }

    public static IEnumerable<Order> Expensive(int limit, decimal threshold)
    {
        for (int i = 1; i <= limit; i++)
        {
            if (i * 1000m < threshold) continue;
            yield return new Order(i, "Иванов", "Товар", 1000m * i, DateTime.Now);
        }
    }
}