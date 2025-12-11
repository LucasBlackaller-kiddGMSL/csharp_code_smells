using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class OrderService
{
    public Order CreateOrder(Basket basket, Address shippingAddress)
    {
        return basket.CreateOrder(shippingAddress);
    }
}
