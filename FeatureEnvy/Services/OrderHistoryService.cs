using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class OrderHistory
{
    public OrderHistory(List<Order> orders)
    {
        Orders = orders;
    }

    public List<Order> Orders { get; }

    public IEnumerable<Order> FindOrdersByProduct2(Product product)
    {
        return this.Orders.Where(o =>
            o.Confirmed &&
            o.Items.Any(i => i.Product == product));
    }

    public IEnumerable<Order> FindOrdersByAddress2(Address address)
    {
        return this.Orders.Where(o =>
            o.Confirmed &&
            o.ShippingAddress.Country == address.Country);
    }
}

public class OrderHistoryService
{
    private readonly OrderHistory _orderHistory;

    public OrderHistoryService(OrderHistory orderHistory)
    {
        _orderHistory = orderHistory;
    }

    public IEnumerable<Order> FindOrdersByProduct(Product product)
    {
        return _orderHistory.FindOrdersByProduct2(product);
    }

    public IEnumerable<Order> FindOrdersByAddress(Address address)
    {
        return _orderHistory.FindOrdersByAddress2(address);
    }
}
