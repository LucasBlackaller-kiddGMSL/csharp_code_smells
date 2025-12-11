using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class BasketService
{
    public void AddToBasket(Basket basket, Product product, int qty)
    {
        basket.AddProducts(product, qty);
    }
}
