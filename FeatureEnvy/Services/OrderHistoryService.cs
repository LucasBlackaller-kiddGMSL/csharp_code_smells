using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class OrderHistory
{
    public OrderHistory(List<Order> orders)
    {
        Orders = orders;
    }

    public List<Order> Orders { get; }
}

public class OrderHistoryService
{
    private readonly List<Order> _orders;

    public OrderHistoryService(OrderHistory orderHistory)
    {
        var orders = orderHistory.Orders;
        _orders = orders;
    }

    public IEnumerable<Order> FindOrdersByProduct(Product product)
    {
        return _orders.Where(o =>
            o.Confirmed &&
            o.Items.Any(i => i.Product == product));
    }

    public IEnumerable<Order> FindOrdersByAddress(Address address)
    {
        return _orders.Where(o =>
            o.Confirmed &&
            o.ShippingAddress.Country == address.Country);
    }
}
