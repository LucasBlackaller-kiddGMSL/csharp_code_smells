namespace DivergentChange;

public static class Shipping
{
    public static decimal CalculateShipping(string region, decimal total)
    {
        decimal shipping;

        if (region == "EU")
            shipping = total > 100 ? 0 : 10;
        else if (region == "UK")
            shipping = total > 50 ? 0 : 8;
        else
            shipping = total > 75 ? 0 : 15;

        return shipping;
    }
}