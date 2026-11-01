using OrderHub.Services;

var catalog = new CatalogService();
catalog.AddProduct("Клавиатура", 5490m, "Периферия");
catalog.AddProduct("Монитор", 18990m, "Дисплеи");
catalog.AddProduct("Мышь", 1290m, "Периферия");
catalog.PrintSortedByNaturalOrder();
catalog.PrintSortedByName();
catalog.PrintSortedByNameLength();