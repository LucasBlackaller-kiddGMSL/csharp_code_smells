namespace DivergentChange;

public static class Tax
{
    public static decimal CalculateTax(string jurisdiction, decimal total)
    {
        var taxRate = jurisdiction switch
        {
            "EU" => 0.20m,
            "UK" => 0.21m,
            "US" => 0.07m,
            _ => 0.10m
        };

        return total * taxRate;
    }
}