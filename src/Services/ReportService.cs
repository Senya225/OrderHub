using System.Linq;
using OrderHub.Domain;

namespace OrderHub.Services;

public class CategorySummary
{
    public string Category { get; set; } = "";
    public int Count { get; set; }
    public decimal AveragePrice { get; set; }
}

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

    public List<CategorySummary> SummarizeByCategory(IEnumerable<Product> products)
        => products.GroupBy(p => p.Category)
            .Select(g => new CategorySummary { Category = g.Key, Count = g.Count(), AveragePrice = g.Average(p => p.Price) })
            .OrderByDescending(s => s.Count).ToList();

    public List<string> TopCustomers(IEnumerable<Customer> customers, IEnumerable<Order> orders, int topCount)
        => customers.Join(orders, c => c.Name, o => o.CustomerName, (c, o) => new { c.Name, o.Price })
            .GroupBy(x => x.Name).Select(g => new { Name = g.Key, Total = g.Sum(x => x.Price) })
            .OrderByDescending(x => x.Total).Take(topCount).Select(x => $"{x.Name} - {x.Total:0.00} ₽").ToList();
}