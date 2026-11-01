using OrderHub.Domain;
using OrderHub.Services;

var reports = new ReportService();
var prods = new[] { 
    new Product("Клавиатура", 5490m, "Периферия"), 
    new Product("Мышь", 1290m, "Периферия"), 
    new Product("Монитор", 18990m, "Дисплеи") 
};

foreach (var row in reports.SummarizeByCategory(prods))
    Console.WriteLine($"{row.Category}: {row.Count} шт., средняя {row.AveragePrice:0.00} ₽");