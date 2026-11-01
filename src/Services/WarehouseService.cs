namespace OrderHub.Services;

public class WarehouseService
{
    private readonly Dictionary<string, int> stock = new();

    public void Receive(string productName, int quantity)
    {
        if (stock.TryGetValue(productName, out int existing)) 
            stock[productName] = existing + quantity;
        else 
            stock[productName] = quantity;
            
        Console.WriteLine($"[Receive] {productName}: {stock[productName]} шт.");
    }

    public bool Sell(string productName, int quantity)
    {
        if (!stock.TryGetValue(productName, out int existing)) 
        { 
            Console.WriteLine("Нет на складе"); 
            return false; 
        }
        if (existing < quantity) 
        { 
            Console.WriteLine("Недостаточно"); 
            return false; 
        }
        
        int left = existing - quantity;
        if (left == 0) 
        { 
            stock.Remove(productName); 
            Console.WriteLine("Снят с учёта"); 
        }
        else 
        {
            stock[productName] = left;
        }
        
        return true;
    }

    public bool TryGetStock(string productName, out int quantity)
    {
        if (stock.TryGetValue(productName, out quantity)) return true;
        quantity = 0; 
        return false;
    }

    public void PrintStock()
    {
        Console.WriteLine("--- Склад ---");
        foreach (var kv in stock.OrderBy(x => x.Key)) Console.WriteLine($"{kv.Key}: {kv.Value}");
    }
}