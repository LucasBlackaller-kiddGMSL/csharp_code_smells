namespace Demo;

public class CarpetQuote
{
    public double Calculate(Room room, double pricePerSqMetre, bool roundUpArea)
    {
        var length = room.Length;
        var width = room.Width;
        double area = length * width;

        if (roundUpArea)
        {
            area = (float)Math.Ceiling(area);
        }
        
        return area * pricePerSqMetre;
    }
}