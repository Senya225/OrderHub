using System.Linq;
using OrderHub.Domain;

namespace OrderHub.Services;

public class ReportService
{
    public List<string> ExpensiveProducts(IEnumerable<Product> products, decimal threshold)
        => products.Where(p => p.Price > threshold).OrderBy(p => p.Price).Select(p => $"{p.Name} - {p.Price:0.00} Р").ToList();

    public int CountExpensive(IEnumerable<Product> products, decimal threshold) 
        => products.Count(p => p.Price > threshold);
        
    public bool HasVeryExpensive(IEnumerable<Product> products, decimal threshold) 
        => products.Any(p => p.Price > threshold);
        
    public bool AllInStock(IEnumerable<Product> products) 
        => products.All(p => p.Price > 0);
        
    public Product? Cheapest(IEnumerable<Product> products) 
        => products.OrderBy(p => p.Price).FirstOrDefault();
}