using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class StockService
{
    public readonly Warehouse _warehouse;

    public StockService(Warehouse warehouse)
    {
        _warehouse = warehouse;
    }

    public bool CheckStock(Product product, int qty)
    {
        return _warehouse.CheckStock(product, qty);
    }
}