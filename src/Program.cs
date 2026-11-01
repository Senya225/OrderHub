using OrderHub.Services;

var warehouse = new WarehouseService();
warehouse.Receive("Клавиатура", 10);
warehouse.Receive("Клавиатура", 5);
warehouse.Receive("Монитор", 3);
warehouse.Sell("Монитор", 1);
warehouse.Sell("Монитор", 99);
warehouse.Sell("Проектор", 1);
warehouse.PrintStock();