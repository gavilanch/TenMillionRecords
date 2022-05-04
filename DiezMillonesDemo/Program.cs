using DiezMillonesDemo;
using System.Diagnostics;

Console.WriteLine("Processing");

var route = @"C:\Users\ASUS\source\repos\TenMillionDemo\DiezMillonesDemo\data.txt";

// Calentamiento
Utilities.Warmup(route);

Utilities.CreateFileWithData(10_000_000, route);

Console.WriteLine("Inserting data in SQL Server");

Stopwatch sw = new Stopwatch();

sw.Start();

//Console.WriteLine("--Efficient way--");
//EfficientCode.InsertData(route);

sw.Stop();

Console.WriteLine($"Duration: {sw.ElapsedMilliseconds / 1000.0} seconds");

sw.Restart();

Console.WriteLine("--Inefficient way--");
InefficientCode.InsertData(route);

sw.Stop();

Console.WriteLine($"Duration: {sw.ElapsedMilliseconds / 1000.0} seconds");

Console.WriteLine("The end");
