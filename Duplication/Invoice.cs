namespace Duplication;

public class Item
{
    public double Price { get; }
    public int Quantity { get; }

    public Item(double price, int quantity)
    {
        Price = price;
        Quantity = quantity;
    }
}

public class Invoice
{
    private readonly Item? _item1;
    private readonly Item? _item2;
    private readonly Item? _item3;
    private readonly Item? _item4;
    private readonly Item? _item5;

    public Invoice(Item? item1, Item? item2, Item? item3, Item? item4, Item? item5)
    {
        _item1 = item1;
        _item2 = item2;
        _item3 = item3;
        _item4 = item4;
        _item5 = item5;
    }

    public double CalculateTotal()
    {
        double total = 0.0;

        if (_item1 != null)
        {
            double subtotal1 = _item1.Price * _item1.Quantity;
            total += subtotal1;
        }

        if (_item2 != null)
        {
            double subtotal2 = _item2.Price * _item2.Quantity;
            total += subtotal2;
        }

        if (_item3 != null)
        {
            double subtotal3 = _item3.Price * _item3.Quantity;
            total += subtotal3;
        }

        if (_item4 != null)
        {
            double subtotal4 = _item4.Price * _item4.Quantity;
            total += subtotal4;
        }

        if (_item5 != null)
        {
            double subtotal5 = _item5.Price * _item5.Quantity;
            total += subtotal5;
        }

        return total;
    }
}
