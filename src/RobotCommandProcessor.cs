namespace ToyRobotSimulationApp
{
    using System;

    public class RobotCommandProcessor
    {
        private readonly Robot _robot;
        private bool _isPlaced;


        public RobotCommandProcessor(Robot robot)
        {
            _robot = robot;
            _isPlaced = false;
        }

        public void ProcessCommand(string command)
        {
            var parts = command.Trim().Split(' ', 2); // Split into command and arguments
            var commandType = parts[0].ToUpper();

            if (commandType == "PLACE" && parts.Length > 1)
            {
                HandlePlaceCommand(parts[1]);
            }
            else if (_isPlaced)
            {
                switch (commandType)
                {
                    case "MOVE":
                        _robot.Move();
                        break;

                    case "LEFT":
                        _robot.RotateLeft();
                        break;

                    case "RIGHT":
                        _robot.RotateRight();
                        break;

                    case "REPORT":
                        Console.WriteLine(_robot.Report());
                        break;

                    default:
                        Console.WriteLine($"Unknown command: {command}");
                        break;
                }
            }
            else
            {
                Console.WriteLine("The robot must be placed on the table first using the PLACE command.");
            }

        }

        private void HandlePlaceCommand(string args)
        {
            var placeArgs = args.Split(',');

            if (placeArgs.Length == 3 &&
                int.TryParse(placeArgs[0], out var x) &&
                int.TryParse(placeArgs[1], out var y) &&
                IsValidDirection(placeArgs[2].ToUpper()) && _robot.IsValidPosition(x,y))
            {
                var facing = placeArgs[2].ToUpper();
                _robot.Place(x, y, facing);
                _isPlaced = true;
            }
            else
            {
                Console.WriteLine($"Invalid PLACE command: {args}");
            }
        }

        private bool IsValidDirection(string direction)
        {
            return direction == "NORTH" || direction == "SOUTH" || direction == "EAST" || direction == "WEST";
        }
       
    }
}
