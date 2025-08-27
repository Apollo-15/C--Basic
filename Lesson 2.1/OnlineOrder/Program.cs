using System;
using System.Globalization;

public class Program
{
    static List<Order> orders = new List<Order>();

    public static void Main(String[] args)
    {
        Console.WriteLine("Hello! What would you like to do?");

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nSelect an action:");
            Console.WriteLine("1. Create an order");
            Console.WriteLine("2. View all orders");
            Console.WriteLine("3. Find an order by order's number");
            Console.WriteLine("4. Exit");
            Console.Write("Your choise: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateOrder();
                    break;

                case "2":
                    ShowAllOrders();
                    break;

                case "3":
                    FindOrderByNumber();
                    break;

                case "4":
                    isRunning = false;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void CreateOrder()
    {
        Console.Write("Client: ");
        string client = Console.ReadLine();

        Console.Write("Product: ");
        string product = Console.ReadLine();

        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Address: ");
        string address = Console.ReadLine();

        int orderNumber = orders.Count + 1;
        Order newOrder = new Order(orderNumber, client, product, price, address);
        orders.Add(newOrder);

        Console.WriteLine("\nOrder created");
        newOrder.Info();
    }

    static void ShowAllOrders()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("The order list is empty.");
            return;
        }

        foreach (var order in orders)
        {
            order.Info();
        }
    }

    static void FindOrderByNumber()
    {
        Console.Write("Enter the order number: ");
        int number = int.Parse(Console.ReadLine());
        var order = orders.Find(o => o.OrderNumber == number);
        if (order != null)
        {
            order.Info();
        }
        else
        {
            Console.WriteLine("Order not found.");
        }
    }
}