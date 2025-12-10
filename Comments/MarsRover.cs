namespace Comments;

public class MarsRover
{
    private const string facingNorth = "N";
    private const string facingEast = "E";
    private const string facingSouth = "S";
    private const string facingWest = "W";

    public string Facing { get; private set; }
    public int[] Coordinates { get; }

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
        if (instruction == 'R')
        {
            TurnRight();
        }

        if (instruction == 'L')
        {
            TurnLeft();
        }

        if (instruction == 'F')
        {
            MoveForward();
        }

        if (instruction == 'B')
        {
            MoveBackward();
        }
    }

    private void MoveBackward()
    {
        if (Facing == facingNorth)
        {
            // Y - 1
            Coordinates[1] = Coordinates[1] - 1;
        }

        if (Facing == facingEast)
        {
            // X - 1
            Coordinates[0] = Coordinates[0] - 1;
        }

        if (Facing == facingSouth)
        {
            // Y + 1
            Coordinates[1] = Coordinates[1] + 1;
        }

        if (Facing == facingWest)
        {
            // X + 1
            Coordinates[0] = Coordinates[0] + 1;
        }
    }

    private void MoveForward()
    {
        if (Facing == facingNorth)
        {
            // Y + 1
            Coordinates[1] = Coordinates[1] + 1;
        }

        if (Facing == facingEast)
        {
            // X + 1
            Coordinates[0] = Coordinates[0] + 1;
        }

        if (Facing == facingSouth)
        {
            // Y - 1
            Coordinates[1] = Coordinates[1] - 1;
        }

        if (Facing == facingWest)
        {
            // X - 1
            Coordinates[0] = Coordinates[0] - 1;
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
        // N = North
        if (Facing == facingNorth)
        {
            // E = East
            Facing = facingEast;
            return;
        }

        if (Facing == facingEast)
        {
            // S = South
            Facing = facingSouth;
            return ;
        }

        if (Facing == facingSouth)
        {
            // W = West
            Facing = facingWest;
            return ;
        }

        Facing = facingNorth;
    }
}