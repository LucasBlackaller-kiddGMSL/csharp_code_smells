namespace Comments;

public class MarsRover
{
    private const string facingNorth = "N";
    private const string facingEast = "E";
    private const string facingSouth = "S";
    private const string facingWest = "W";
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
        if (Facing == facingNorth)
        {
            YAxis -= 1;
        }

        if (Facing == facingEast)
        {
            XAxis -= 1;
        }

        if (Facing == facingSouth)
        {
            YAxis += 1;
        }

        if (Facing == facingWest)
        {
            XAxis += 1;
        }
    }

    private void MoveForward()
    {
        if (Facing == facingNorth)
        {
            YAxis += 1;
        }

        if (Facing == facingEast)
        {
            XAxis += 1;
        }

        if (Facing == facingSouth)
        {
            YAxis -= 1;
        }

        if (Facing == facingWest)
        {
            XAxis -= 1;
        }
    }

    private void TurnLeft()
    {
        if (Facing == facingNorth)
        {
            Facing = facingWest;
            return;
        }

        if (Facing == facingWest)
        {
            Facing = facingSouth;
            return;
        }

        if (Facing == facingSouth)
        {
            Facing = facingEast;
            return;
        }

        Facing = facingNorth;
    }

    private void TurnRight()
    {
        if (Facing == facingNorth)
        {
            Facing = facingEast;
            return;
        }

        if (Facing == facingEast)
        {
            Facing = facingSouth;
            return ;
        }

        if (Facing == facingSouth)
        {
            Facing = facingWest;
            return ;
        }

        Facing = facingNorth;
    }
}