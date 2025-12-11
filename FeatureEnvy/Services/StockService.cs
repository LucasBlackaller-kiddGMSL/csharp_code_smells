using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class Warehouse
{
    public Warehouse(List<WarehouseStock> stocks)
    {
        Stocks = stocks;
    }

    public List<WarehouseStock> Stocks { get; }

    public bool CheckStock(Product product, int qty)
    {
        var stock = this.Stocks.FirstOrDefault(s => s.Product == product);
        return stock != null && stock.Quantity >= qty;
    }
}

public class StockService
{
    private readonly Warehouse _warehouse;

    public StockService(Warehouse warehouse)
    {
        _warehouse = warehouse;
    }

    public bool CheckStock(Product product, int qty)
    {
        return _warehouse.CheckStock(product, qty);
    }
}