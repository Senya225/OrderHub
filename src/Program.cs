using OrderHub.Domain;
using OrderHub.Services;

var reports = new ReportService();
var customers = new[] { new Customer(1, "Иванов", "Москва"), new Customer(2, "Петрова", "СПб") };
var orders = new[] { 
    new Order(1, "Иванов", "Клавиатура", 5490m, DateTime.Now), 
    new Order(2, "Петрова", "Монитор", 18990m, DateTime.Now), 
    new Order(3, "Иванов", "Мышь", 1290m, DateTime.Now) 
};

foreach (var c in reports.TopCustomers(customers, orders, 3)) Console.WriteLine(c);