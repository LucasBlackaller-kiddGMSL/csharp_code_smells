namespace LongParameterList.Test;

[TestFixture]
public class OrderServiceTests
{
    [Test]
    public void CreateOrder_ShouldCreateOrderWithCorrectData()
    {
        string productName = "Laptop";
        Item item = new Item(2, 1220.50m, productName);
        string customerName = "Alice";
        string customerEmail = "alice@example.com";
        string shippingAddress = "123 Main St";
        string billingAddress = "123 Main St";
        DateTime orderDate = new DateTime(2025, 12, 7);
        
        Order order = new OrderService().CreateOrder(new Customer(customerName, customerEmail, shippingAddress, billingAddress),
            orderDate,
            item);

        Assert.That(order, Is.Not.Null);
        Assert.That(order.CustomerName, Is.EqualTo(customerName));
        Assert.That(order.CustomerEmail, Is.EqualTo(customerEmail));
        Assert.That(order.ProductName, Is.EqualTo(productName));
        Assert.That(order.Quantity, Is.EqualTo(item.Quantity));
        Assert.That(order.Price, Is.EqualTo(item.Price));
        Assert.That(order.ShippingAddress, Is.EqualTo(shippingAddress));
        Assert.That(order.BillingAddress, Is.EqualTo(billingAddress));
        Assert.That(order.OrderDate, Is.EqualTo(orderDate));
    }

    [Test]
    public void CreateOrder_ShouldCalculateTotalAmountCorrectly()
    {
        Item item = new Item(3, 150.75m, "");

        Order order = new OrderService().CreateOrder(new Customer("", "", "", ""),
            DateTime.Now,
            item);

        Assert.That(order.TotalAmount, Is.EqualTo(452.25));
    }
}