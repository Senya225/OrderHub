namespace OrderHub.Domain;

public class Order
{
    // ЗАДАЧА: добавьте конструктор с параметрами Id, CustomerName, ProductName, Price, CreatedAt
    public Order(int id, string customerName, string productName, decimal price, DateTime createdAt)
    {
        Id = id;
        CustomerName = customerName;
        ProductName = productName;
        Price = price;
        CreatedAt = createdAt;
    }

    // ЗАДАЧА: объявите свойства только для чтения
    public int Id { get; }
    public string CustomerName { get; }
    public string ProductName { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }

    // ЗАДАЧА: переопределите ToString()
    public override string ToString() =>
        $"#{Id} {CustomerName} – {ProductName} {Price:N2} ₽ ({CreatedAt:dd.MM.yyyy})";
}