using OrderHub.Collections;

var buffer = new CircularBuffer<string>(3);
buffer.Add("1"); buffer.Add("2"); buffer.Add("3"); buffer.Add("4"); buffer.Add("5");

Console.Write("foreach: "); 
foreach (var x in buffer) Console.Write(x + " "); 
Console.WriteLine();

Console.Write("Reverse: "); 
foreach (var x in buffer.Reverse()) Console.Write(x + " "); 
Console.WriteLine();

Console.WriteLine($"Count={buffer.Count}, IsFull={buffer.IsFull}");