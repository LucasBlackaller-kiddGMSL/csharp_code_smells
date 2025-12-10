namespace DivergentChange;

public static class Shipping
{
    public static decimal CalculateShipping(string region, decimal total)
    {
        return region switch
        {
            "EU" => total > 100 ? 0 : 10,
            "UK" => total > 50 ? 0 : 8,
            _ => total > 75 ? 0 : 15
        };
    }
}