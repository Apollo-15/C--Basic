using System;

public class Order
{
    public int OrderNumber { get; }
    public string Client { get; }
    public string Product { get; }
    public double Price { get; }
    public string Address { get; }

    public Order(int orderNumber, string client, string product, double price, string address)
    {
        OrderNumber = orderNumber;
        Client = client;
        Product = product;
        Price = price;
        Address = address;
    }

    public void Info()
    {
        Console.WriteLine($"\nOrder No {OrderNumber}");
        Console.WriteLine($"Client: {Client}.");
        Console.WriteLine($"Product: {Product}, price {Price} EUR.");
        Console.WriteLine($"Address: {Address}.");
    }
}