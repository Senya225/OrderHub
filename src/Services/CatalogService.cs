using OrderHub.Domain;

namespace OrderHub.Services;

public class CatalogService
{
    private readonly List<Product> products = new();
    
    public void AddProduct(string name, decimal price, string category) 
        => products.Add(new Product(name, price, category));

    public void PrintSortedByNaturalOrder() 
    { 
        products.Sort(); 
        Print("По цене (IComparable)"); 
    }
    
    public void PrintSortedByName() 
    { 
        products.Sort(new NameComparer()); 
        Print("По названию (IComparer)"); 
    }
    
    public void PrintSortedByNameLength() 
    { 
        products.Sort((a, b) => a.Name.Length.CompareTo(b.Name.Length)); 
        Print("По длине (лямбда)"); 
    }
    
    private void Print(string title) 
    { 
        Console.WriteLine($"--- {title} ---"); 
        foreach (var p in products) Console.WriteLine(p); 
    }
}