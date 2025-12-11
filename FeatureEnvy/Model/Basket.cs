namespace FeatureEnvy.Model;

public class Basket
{
    public List<Item> Items { get; } = new();

    public void AddProducts(Product product, int qty)
    {
        var existing = Items.FirstOrDefault(i => i.Product == product);

        if (existing == null)
        {
            Items.Add(new Item
            {
                Product = product,
                Quantity = qty
            });
        }
        else
        {
            existing.Quantity += qty;
        }
    }

    public Order CreateOrder(Address shippingAddress)
    {
        var order = new Order();

        order.ShippingAddress = shippingAddress;

        foreach (var item in Items)
        {
            order.Items.Add(item);
            order.Total += item.Product.UnitPrice * item.Quantity;
        }

        return order;
    }
}