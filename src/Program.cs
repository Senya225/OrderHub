using OrderHub.Domain;
using OrderHub.Services;


var ordersStream = OrderStream.Orders();
Console.WriteLine("После вызова метода (ничего ещё не сгенерировано)");
foreach (var o in ordersStream.Take(5)) Console.WriteLine(o);


var warehouse = new WarehouseService();
warehouse.Receive("Клавиатура", 10);
warehouse.Receive("Клавиатура", 5);
warehouse.Receive("Монитор", 3);
warehouse.Sell("Монитор", 1);
warehouse.Sell("Монитор", 99);
warehouse.Sell("Проектор", 1);
warehouse.PrintStock();


var catalog = new CatalogService();
catalog.AddProduct("Клавиатура", 5490m, "Периферия");
catalog.AddProduct("Монитор", 18990m, "Дисплеи");
catalog.AddProduct("Мышь", 1290m, "Периферия");
catalog.PrintSortedByNaturalOrder();
catalog.PrintSortedByName();
catalog.PrintSortedByNameLength();

var reports = new ReportService();
var prods = new[] { new Product("Клавиатура", 5490m, "Периферия"), new Product("Монитор", 18990m, "Дисплеи") };

foreach (var line in reports.ExpensiveProducts(prods, 5000m)) Console.WriteLine(line);
Console.WriteLine(reports.CountExpensive(prods, 5000m));
Console.WriteLine(reports.HasVeryExpensive(prods, 50000m));
Console.WriteLine(reports.Cheapest(prods));



