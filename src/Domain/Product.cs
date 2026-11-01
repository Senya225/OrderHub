namespace OrderHub.Domain;

public class Product : IComparable<Product>
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Category { get; private set; }

    public Product(string name, decimal price, string category) 
    { 
        Name = name; 
        Price = price; 
        Category = category; 
    }

    public int CompareTo(Product? other) => other is null ? 1 : Price.CompareTo(other.Price);
    
    public override string ToString() => $"{Name} - {Price:0.00} Р ({Category})";
}

public class NameComparer : IComparer<Product>
{
    public int Compare(Product? a, Product? b) => string.Compare(a?.Name, b?.Name, StringComparison.Ordinal);
}

public class PriceDescComparer : IComparer<Product>
{
    public int Compare(Product? a, Product? b) => b!.Price.CompareTo(a!.Price);
}