using OrderHub.Services;

var ordersStream = OrderStream.Orders();
Console.WriteLine("После вызова метода (ничего ещё не сгенерировано)");
foreach (var o in ordersStream.Take(5)) Console.WriteLine(o);