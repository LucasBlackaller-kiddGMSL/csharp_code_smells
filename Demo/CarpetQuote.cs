namespace Demo;

public class Room
{
    public Room(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public double Length { get; }
    public double Width { get; }
}

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