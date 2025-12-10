namespace LongMethod;

using System.Collections.Generic;

public class OrderProcessor
{
    public Invoice ProcessOrder(Order order)
    {
        ValidateOrder(order);

        var invoiceItems = new List<InvoiceItem>();
        var warnings = new List<string>();

        // subtotal order items

        foreach (var item in order.Items)
        {
            if (item.Quantity <= 0)
            {
                warnings.Add($"Invalid quantity for item: {item.Name}");
                continue;
            }

            if (item.Price < 0)
            {
                warnings.Add($"Invalid price for item: {item.Name}");
                continue;
            }

            invoiceItems.Add(new InvoiceItem
            {
                Name = item.Name,
                Quantity = item.Quantity,
                Price = item.Price,
                Total = item.ItemTotalPrice()
            });
        }

        var invoice = new Invoice
        {
            CustomerName = order?.CustomerName,
            Items = invoiceItems,
            Warnings = warnings,
            Subtotal = invoiceItems.Sum(item => item.Total)
        };

        // Apply discount
        
        var discount = GetDiscount(invoice.Subtotal);

        invoice.Discount = discount;

        decimal totalAfterDiscount = invoice.Subtotal - discount;

        // Shipping
        decimal shipping = 0; // shipping is free on orders >= £200
        if (totalAfterDiscount < 50) shipping = 10;
        else if (totalAfterDiscount < 200) shipping = 5;

        decimal total = totalAfterDiscount + shipping;

        invoice.Shipping = shipping;
        invoice.Total = total;

        return invoice;
    }

    private static decimal GetDiscount(decimal subtotal)
    {
        // 10% discount on orders over £500
        if (subtotal > 500)
        {
            return subtotal * 0.10m;
        }
        
        // 5% discount on orders over £200, up to £500
        if (subtotal > 200)
        {
            return subtotal * 0.05m;
        }

        return 0;
    }

    private static void ValidateOrder(Order order)
    {
        if (order == null)
        {
            throw new InvalidOrderException("Order is null");
        }

        if (string.IsNullOrEmpty(order.CustomerName))
        {
            throw new InvalidOrderException("Customer name is missing");
        }

        if (order.Items.Count == 0)
        {
            throw new InvalidOrderException("No items in order");
        }
    }
}

public class InvalidOrderException : Exception
{
    public InvalidOrderException(string message): base(message)
    {

    }
}

// Order and Items
public class Order
{
    public string? CustomerName { get; init; }
    public List<OrderItem>? Items { get; init; }
}

public class OrderItem
{
    public string? Name { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }

    public decimal ItemTotalPrice()
    {
        return this.Price * this.Quantity;
    }
}

// Invoice Classes
public class Invoice
{
    public string? CustomerName { get; set; }
    public List<InvoiceItem>? Items { get; init; }
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Shipping { get; set; }
    public decimal Total { get; set; }
    public List<string>? Warnings { get; init; }
}

public class InvoiceItem
{
    public string? Name { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
    public decimal Total { get; set; }
}
