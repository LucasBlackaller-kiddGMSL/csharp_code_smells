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
}