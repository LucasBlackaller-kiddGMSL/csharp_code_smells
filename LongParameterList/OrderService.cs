namespace LongParameterList;

public class Order
{
    public Order(string customerName,
        string customerEmail,
        string productName,
        int quantity,
        decimal price,
        string shippingAddress,
        string billingAddress,
        DateTime orderDate, 
        Customer customer)
    {
        CustomerName = customer.CustomerName;
        CustomerEmail = customer.CustomerEmail;
        ProductName = productName;
        Quantity = quantity;
        Price = price;
        ShippingAddress = customer.ShippingAddress;
        BillingAddress = customer.BillingAddress;
        OrderDate = orderDate;
    }

    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; }
    public DateTime OrderDate { get; set; }

    public decimal TotalAmount => Quantity * Price;
}


public class Item
{
    public string ProductName { get; }
    public int Quantity { get; }
    public decimal Price { get; }

    public Item(int quantity, decimal price, string productName)
    {
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }
}

public class Customer
{
    public Customer(string customerName, string customerEmail, string shippingAddress, string billingAddress)
    {
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
    }

    public string CustomerName { get; }
    public string CustomerEmail { get; }
    public string ShippingAddress { get; }
    public string BillingAddress { get; }
}

public class OrderService
{
    public Order CreateOrder(
        Customer customer,
        DateTime orderDate,
        Item item)
    {
        var customerName = customer.CustomerName;
        var customerEmail = customer.CustomerEmail;
        var shippingAddress = customer.ShippingAddress;
        var billingAddress = customer.BillingAddress;
        var order = new Order(
            customerName: customerName,
            customerEmail: customerEmail,
            productName: item.ProductName,
            quantity: item.Quantity,
            price: item.Price,
            shippingAddress: shippingAddress,
            billingAddress: billingAddress,
            orderDate: orderDate, 
            customer: customer);

        return order;
    }
}
