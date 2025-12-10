namespace Comments;

public class MarsRover
{
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
        // R = Turn Right
        if (instruction == 'R')
        {
            TurnRight();
        }

        // L = Turn Left
        if (instruction == 'L')
        {
            TurnLeft();
        }

        // F = Move Forward
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
        if (Facing == "N")
        {
            // Y - 1
            Coordinates[1] = Coordinates[1] - 1;
        }

        if (Facing == "E")
        {
            // X - 1
            Coordinates[0] = Coordinates[0] - 1;
        }

        if (Facing == "S")
        {
            // Y + 1
            Coordinates[1] = Coordinates[1] + 1;
        }

        if (Facing == "W")
        {
            // X + 1
            Coordinates[0] = Coordinates[0] + 1;
        }
    }

    private void MoveForward()
    {
        if (Facing == "N")
        {
            // Y + 1
            Coordinates[1] = Coordinates[1] + 1;
        }

        if (Facing == "E")
        {
            // X + 1
            Coordinates[0] = Coordinates[0] + 1;
        }

        if (Facing == "S")
        {
            // Y - 1
            Coordinates[1] = Coordinates[1] - 1;
        }

        if (Facing == "W")
        {
            // X - 1
            Coordinates[0] = Coordinates[0] - 1;
        }
    }

    private void TurnLeft()
    {
        if (Facing == "N")
        {
            Facing = "W";
            return;
        }

        if (Facing == "W")
        {
            Facing = "S";
            return;
        }

        if (Facing == "S")
        {
            Facing = "E";
            return;
        }

        Facing = "N";
    }

    private void TurnRight()
    {
        // N = North
        if (Facing == "N")
        {
            // E = East
            Facing = "E";
            return;
        }

        if (Facing == "E")
        {
            // S = South
            Facing = "S";
            return ;
        }

        if (Facing == "S")
        {
            // W = West
            Facing = "W";
            return ;
        }

        Facing = "N";
    }
}