namespace LongMethod;

public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Validate
        if (order == null)
        {
            Console.WriteLine("Order is null");
            return;
        }

        if (string.IsNullOrEmpty(order.CustomerName))
        {
            Console.WriteLine("Customer name is missing");
            return;
        }

        if (order.Items == null || order.Items.Count == 0)
        {
            Console.WriteLine("No items in order");
            return;
        }

        // Calculate total
        decimal total = 0;
        foreach (var item in order.Items)
        {
            if (item.Quantity <= 0)
            {
                Console.WriteLine("Invalid quantity");
                continue;
            }

            if (item.Price < 0)
            {
                Console.WriteLine("Invalid price");
                continue;
            }

            total += item.Price * item.Quantity;
        }

        // Apply discounts
        if (total > 500)
        {
            total -= total * 0.10m; // 10% discount
        }
        else if (total > 200)
        {
            total -= total * 0.05m; // 5% discount
        }

        // Shipping
        decimal shipping = 0;
        if (total < 50)
        {
            shipping = 10;
        }
        else if (total < 200)
        {
            shipping = 5;
        }

        total += shipping;

        // Print summary
        Console.WriteLine("----- ORDER SUMMARY -----");
        Console.WriteLine("Customer: " + order.CustomerName);
        Console.WriteLine("Items:");
        foreach (var item in order.Items)
        {
            Console.WriteLine($"{item.Name} x{item.Quantity} @ {item.Price:C}");
        }
        Console.WriteLine("-------------------------");
        Console.WriteLine("Shipping: " + shipping.ToString("C"));
        Console.WriteLine("Total: " + total.ToString("C"));
        Console.WriteLine("-------------------------");

        // Send confirmation email
        Console.WriteLine("Sending confirmation email...");
        Console.WriteLine("Email sent.");
    }
}

public class Order
{
    public string CustomerName { get; set; }
    public List<OrderItem> Items { get; set; }
}

public class OrderItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
