namespace ToyRobotSimulationApp
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Facing { get; private set; }

        private Table _table;

        public Robot(Table table)
        {
            // Initial state: not on the table.
            X = -1;
            Y = -1;
            Facing = null;
            _table = table;
        }

        public void Place(int x, int y, string facing)
        {
            // Validate position and facing direction
            if (IsValidPosition(x, y) &&
             (facing == "NORTH" || facing == "SOUTH" || facing == "EAST" || facing == "WEST"))
            {
                X = x;
                Y = y;
                Facing = facing;
            }
        }

        public void Move()
        {
            if (Facing == null) return;

            int newX = X, newY = Y;

            switch (Facing)
            {
                case "NORTH": newY++; break;
                case "SOUTH": newY--; break;
                case "EAST": newX++; break;
                case "WEST": newX--; break;
            }

            if (IsValidPosition(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }

    public void RotateLeft()
        {
            if (Facing == null) return; // Robot not placed

            Facing = Facing switch
            {
                "NORTH" => "WEST",
                "WEST" => "SOUTH",
                "SOUTH" => "EAST",
                "EAST" => "NORTH",
                _ => Facing
            };
        }

        public void RotateRight()
        {
            if (Facing == null) return; // Robot not placed

            Facing = Facing switch
            {
                "NORTH" => "EAST",
                "EAST" => "SOUTH",
                "SOUTH" => "WEST",
                "WEST" => "NORTH",
                _ => Facing
            };
        }

        public string Report()
        {
            return Facing != null ? $"{X},{Y},{Facing}" : "Robot not placed";
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x <= _table.Width && y >= 0 && y <= _table.Height;
        }
    }
}
