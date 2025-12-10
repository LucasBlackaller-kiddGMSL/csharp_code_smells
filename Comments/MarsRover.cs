namespace Comments;

public class Directions
{
    public const string North = "N";
    public const string East = "E";
    public const string South = "S";
    public const string West = "W";
}

public class MarsRover
{
    private const int Right = 'R';
    private const int Left = 'L';
    private const int Forward = 'F';
    private const int Backward = 'B';

    public string Facing { get; private set; }

    public int[] Coordinates { get; }

    public int YAxis
    {
        get => Coordinates[1]; 
        set => Coordinates[1] = value;
    }

    public int XAxis
    {
        get => Coordinates[0];
        set => Coordinates[0] = value;
    }

    public MarsRover(string facing, int[] coordinates)
    {
        Facing = facing;
        Coordinates = coordinates;
    }

    public void Go(string instructions)
    {
        foreach (var instruction in instructions.ToCharArray())
        {
            Execute(instruction);
        }
    }

    private void Execute(char instruction)
    {
        if (instruction == Right)
        {
            TurnRight();
        }

        if (instruction == Left)
        {
            TurnLeft();
        }

        if (instruction == Forward)
        {
            MoveForward();
        }

        if (instruction == Backward)
        {
            MoveBackward();
        }
    }

    private void MoveBackward()
    {
        if (Facing == Directions.North)
        {
            YAxis -= 1;
        }

        if (Facing == Directions.East)
        {
            XAxis -= 1;
        }

        if (Facing == Directions.South)
        {
            YAxis += 1;
        }

        if (Facing == Directions.West)
        {
            XAxis += 1;
        }
    }

    private void MoveForward()
    {
        if (Facing == Directions.North)
        {
            YAxis += 1;
        }

        if (Facing == Directions.East)
        {
            XAxis += 1;
        }

        if (Facing == Directions.South)
        {
            YAxis -= 1;
        }

        if (Facing == Directions.West)
        {
            XAxis -= 1;
        }
    }

    private void TurnLeft()
    {
        if (Facing == Directions.North)
        {
            Facing = Directions.West;
            return;
        }

        if (Facing == Directions.West)
        {
            Facing = Directions.South;
            return;
        }

        if (Facing == Directions.South)
        {
            Facing = Directions.East;
            return;
        }

        Facing = Directions.North;
    }

    private void TurnRight()
    {
        if (Facing == Directions.North)
        {
            Facing = Directions.East;
            return;
        }

        if (Facing == Directions.East)
        {
            Facing = Directions.South;
            return ;
        }

        if (Facing == Directions.South)
        {
            Facing = Directions.West;
            return ;
        }

        Facing = Directions.North;
    }
}