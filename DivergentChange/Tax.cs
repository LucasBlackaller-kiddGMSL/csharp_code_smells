namespace DivergentChange;

public static class Tax
{
    public static decimal CalculateTax(string jurisdiction, decimal total)
    {
        return total * GetTaxRate(jurisdiction);
    }

    private static decimal GetTaxRate(string jurisdiction)
    {
        return jurisdiction switch
        {
            "EU" => 0.20m,
            "UK" => 0.21m,
            "US" => 0.07m,
            _ => 0.10m
        };
    }
}