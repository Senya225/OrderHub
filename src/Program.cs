using OrderHub.Domain;
using OrderHub.Services;

var reports = new ReportService();
var prods = new[] { new Product("Клавиатура", 5490m, "Периферия"), new Product("Монитор", 18990m, "Дисплеи") };

foreach (var line in reports.ExpensiveProducts(prods, 5000m)) Console.WriteLine(line);
Console.WriteLine(reports.CountExpensive(prods, 5000m));
Console.WriteLine(reports.HasVeryExpensive(prods, 50000m));
Console.WriteLine(reports.Cheapest(prods));