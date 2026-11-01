using OrderHub.Services;

var service = new OrderService();

service.InitHistory(
    service.CreateOrder("Иванов", "Клавиатура", 5490m),
    service.CreateOrder("Петрова", "Монитор", 18990m)
);

service.PlaceOrderAfterCurrent(service.CreateOrder("Сидоров", "Мышь", 1290m));
service.PrintHistory();

Console.WriteLine(service.TryFindOrder("Иванов", out var found) ? $"Найден: {found}" : "Не найден");
Console.WriteLine(service.TryFindOrder("Нет такого", out _) ? "Найден" : "Не найден");