using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        // Addresses
        Address addr1 = new Address("123 Main St", "Salt Lake City", "UT", "USA");
        Address addr2 = new Address("456 Oak Avenue", "Toronto", "ON", "Canada");

        // Customers
        Customer customer1 = new Customer("John Smith", addr1);
        Customer customer2 = new Customer("Maria Garcia", addr2);

        // Order 1 (USA - $5 shipping)
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LAP123", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "MOU456", 25.50m, 2));
        order1.AddProduct(new Product("Keyboard", "KEY789", 75.00m, 1));

        // Order 2 (International - $35 shipping)
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "SP001", 699.99m, 1));
        order2.AddProduct(new Product("Headphones", "HP200", 149.99m, 1));

        // Display results
        Console.WriteLine("========================================");
        Console.WriteLine("Order 1");
        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():F2}\n");

        Console.WriteLine("========================================");
        Console.WriteLine("Order 2");
        Console.WriteLine("========================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():F2}");
    }
        
    
}