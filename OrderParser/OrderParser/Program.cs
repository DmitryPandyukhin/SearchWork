using OrdersParser.Models;
using OrdersParser.Services;

Console.WriteLine("Hello, World!");


List<Order>? orderList = XMLParser.LoadOrders();

if (orderList != null)
    DBLoader.LoadToDB(orderList);