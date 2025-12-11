namespace FeatureEnvy.Model;

public class OrderHistory
{
    public OrderHistory(List<Order> orders)
    {
        Orders = orders;
    }

    public List<Order> Orders { get; }

    public IEnumerable<Order> FindOrdersByProduct(Product product)
    {
        return Orders.Where(o =>
            o.Confirmed &&
            o.Items.Any(i => i.Product == product));
    }

    public IEnumerable<Order> FindOrdersByAddress(Address address)
    {
        return Orders.Where(o =>
            o.Confirmed &&
            o.ShippingAddress.Country == address.Country);
    }
}