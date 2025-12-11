using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class OrderHistoryService
{
    private readonly OrderHistory _orderHistory;

    public OrderHistoryService(OrderHistory orderHistory)
    {
        _orderHistory = orderHistory;
    }

    public IEnumerable<Order> FindOrdersByProduct(Product product)
    {
        return _orderHistory.FindOrdersByProduct(product);
    }

    public IEnumerable<Order> FindOrdersByAddress(Address address)
    {
        return _orderHistory.FindOrdersByAddress(address);
    }
}
