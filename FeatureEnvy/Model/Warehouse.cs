namespace FeatureEnvy.Model;

public class Warehouse
{
    public Warehouse(List<WarehouseStock> items)
    {
        Stocks = items;
    }

    public List<WarehouseStock> Stocks { get; }

    public bool CheckStock(Product product, int qty)
    {
        var stock = this.Stocks.FirstOrDefault(s => s.Product == product);
        return stock != null && stock.Quantity >= qty;
    }
}