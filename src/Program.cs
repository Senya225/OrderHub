
﻿using OrderHub.Collections;

var buffer = new CircularBuffer<string>(3);
buffer.Add("1"); buffer.Add("2"); buffer.Add("3"); buffer.Add("4"); buffer.Add("5");

Console.Write("foreach: "); 
foreach (var x in buffer) Console.Write(x + " "); 
Console.WriteLine();

Console.Write("Reverse: "); 
foreach (var x in buffer.Reverse()) Console.Write(x + " "); 
Console.WriteLine();

Console.WriteLine($"Count={buffer.Count}, IsFull={buffer.IsFull}");

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




