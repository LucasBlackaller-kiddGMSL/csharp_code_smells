using FeatureEnvy.Services;

namespace FeatureEnvy.Model;

public class Order
{
    public List<Item> Items { get; set; } = new();
    public Address ShippingAddress { get; set; }
    public decimal Total { get; set; }
    public bool Confirmed { get; set; }

    public bool ConfirmOrder(StockService stockService, Warehouse warehouse)
    {
        foreach (var item in this.Items)
        {
            if (!warehouse.CheckStock(item.Product, item.Quantity))
            {
                this.Confirmed = false;
                return false;
            }
        }

        this.Confirmed = true;
        return true;
    }
}