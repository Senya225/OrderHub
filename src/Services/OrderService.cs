using OrderHub.Domain;

namespace OrderHub.Services;

public class OrderService
{
    private readonly List<Order> allOrders = new();
    private readonly Queue<Order> pendingQueue = new();
    private readonly Stack<string> undoHistory = new();
    private int nextId = 1;

    private readonly LinkedList<Order> orderHistory = new();
    private LinkedListNode<Order>? current;

    public Order CreateOrder(string customerName, string productName, decimal price)
    {
        var order = new Order(nextId++, customerName, productName, price, DateTime.Now);
        allOrders.Add(order);
        pendingQueue.Enqueue(order);
        undoHistory.Push($"Создан заказ {order.Id} для {customerName}");
        return order;
    }

    public Order? ProcessNext()
    {
        if (pendingQueue.Count == 0) return null;
        var order = pendingQueue.Dequeue();
        undoHistory.Push($"Обработан заказ {order.Id}");
        Console.WriteLine($"Обработан заказ: {order}");
        return order;
    }

    public bool UndoLastAction()
    {
        if (undoHistory.Count == 0) return false;
        var action = undoHistory.Pop();
        Console.WriteLine($"Отменено действие: {action}");
        return true;
    }

    public void PrintAllOrders()
    {
        Console.WriteLine("--- Все заказы ---");
        foreach (var o in allOrders) Console.WriteLine(o);
    }

    public void PrintPendingQueue()
    {
        Console.WriteLine($"--- В очереди: {pendingQueue.Count} ---");
        if (pendingQueue.Count > 0) Console.WriteLine($"Первый: {pendingQueue.Peek()}");
    }

    public void PrintRecentActions()
    {
        Console.WriteLine("--- Последние действия ---");
        foreach (var a in undoHistory) Console.WriteLine(a);
    }

    public void InitHistory(params Order[] orders)
    {
        orderHistory.Clear();
        foreach (var o in orders) current = orderHistory.AddLast(o);
    }

    public bool PlaceOrderAfterCurrent(Order order)
    {
        if (current == null) current = orderHistory.AddLast(order);
        else current = orderHistory.AddAfter(current, order);
        return true;
    }

    public bool TryFindOrder(string customerName, out Order? order)
    {
        var node = orderHistory.First;
        while (node != null && node.Value.CustomerName != customerName) node = node.Next;
        
        if (node == null) 
        { 
            order = null; 
            return false; 
        }
        
        order = node.Value; 
        return true;
    }

    public void PrintHistory()
    {
        Console.WriteLine("--- История заказов ---");
        foreach (var o in orderHistory) Console.WriteLine(o);
        Console.WriteLine($"Текущий: {current?.Value}");
    }
}