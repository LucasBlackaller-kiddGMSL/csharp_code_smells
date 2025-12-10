namespace DivergentChange.Test;

using NUnit.Framework;

[TestFixture]
public class OrderTests
{
    private Order _order;

    [SetUp]
    public void SetUp()
    {
        _order = new Order();
    }

    [Test]
    public void AddItem_ShouldIncreaseItemCount()
    {
        _order.AddItem(10m, 2);
        _order.AddItem(5m, 1);

        Assert.That(_order.Items.Count, Is.EqualTo(2));
    }

    [Test]
    public void CalculateTotal_ShouldReturnSumOfItems()
    {
        _order.AddItem(10m, 2); // 20
        _order.AddItem(5m, 3); // 15

        decimal total = _order.CalculateTotal();

        Assert.That(total, Is.EqualTo(35m));
    }

    [TestCase("EU", 0.20, 100, ExpectedResult = 20)]
    [TestCase("UK", 0.21, 100, ExpectedResult = 21)]
    [TestCase("US", 0.07, 100, ExpectedResult = 7)]
    [TestCase("Other", 0.10, 100, ExpectedResult = 10)]
    public decimal CalculateTax_ShouldApplyCorrectTaxRate(string jurisdiction, double taxRate, decimal orderTotal)
    {
        _order.AddItem(orderTotal, 1);
        return Tax.CalculateTax(jurisdiction, _order.CalculateTotal());
    }

    [TestCase("EU", 50, ExpectedResult = 10)]
    [TestCase("EU", 150, ExpectedResult = 0)]
    [TestCase("UK", 30, ExpectedResult = 8)]
    [TestCase("UK", 60, ExpectedResult = 0)]
    [TestCase("Other", 50, ExpectedResult = 15)]
    [TestCase("Other", 100, ExpectedResult = 0)]
    public decimal CalculateShipping_ShouldReturnCorrectShipping(string region, decimal total)
    {
        _order.AddItem(total, 1);
        return _order.CalculateShipping(region, _order.CalculateTotal());
    }
}