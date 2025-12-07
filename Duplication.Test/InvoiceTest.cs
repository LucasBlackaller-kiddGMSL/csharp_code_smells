namespace Duplication.Test;

using NUnit.Framework;

[TestFixture]
public class InvoiceTests
{
    [Test]
    public void CalculateTotal_AllItemsPresent_ReturnsCorrectTotal()
    {
        var item1 = new Item(10.0, 2); // 20
        var item2 = new Item(5.0, 3);  // 15
        var item3 = new Item(7.5, 1);  // 7.5
        var item4 = new Item(2.0, 5);  // 10
        var item5 = new Item(12.0, 1); // 12

        var invoice = new Invoice(item1, item2, item3, item4, item5);

        double expectedTotal = 20 + 15 + 7.5 + 10 + 12;

        Assert.That(invoice.CalculateTotal(), Is.EqualTo(expectedTotal));
    }

    [Test]
    public void CalculateTotal_SomeItemsNull_IgnoresNullItems()
    {
        var item1 = new Item(10.0, 2); // 20
        Item item2 = null;
        var item3 = new Item(7.5, 1);  // 7.5
        Item item4 = null;
        var item5 = new Item(12.0, 1); // 12

        var invoice = new Invoice(item1, item2, item3, item4, item5);

        double expectedTotal = 20 + 7.5 + 12;

        Assert.That(invoice.CalculateTotal(), Is.EqualTo(expectedTotal));
    }

    [Test]
    public void CalculateTotal_AllItemsNull_ReturnsZero()
    {
        var invoice = new Invoice(null, null, null, null, null);

        Assert.That(invoice.CalculateTotal(), Is.EqualTo(0.0));
    }

    [Test]
    public void CalculateTotal_SingleItemOnly_ReturnsSingleSubtotal()
    {
        var item1 = new Item(15.0, 3); // 45
        var invoice = new Invoice(item1, null, null, null, null);

        Assert.That(invoice.CalculateTotal(), Is.EqualTo(45.0));
    }

    [Test]
    public void CalculateTotal_ZeroQuantityItems_ReturnsZeroForThoseItems()
    {
        var item1 = new Item(10.0, 0); // 0
        var item2 = new Item(5.0, 2);  // 10
        var invoice = new Invoice(item1, item2, null, null, null);

        double expectedTotal = 0 + 10;

        Assert.That(invoice.CalculateTotal(), Is.EqualTo(expectedTotal));
    }
}
