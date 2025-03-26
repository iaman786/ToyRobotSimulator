namespace ToyRobotSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot(new Table(5, 5));
            var processor = new RobotCommandProcessor(robot);

            Console.WriteLine("-----------------------Toy Robot Simulator--------------------------");
            Console.WriteLine("Enter commands (e.g., PLACE 0,0,NORTH, MOVE, LEFT, RIGHT, REPORT). Type STOP to quit.");
            string input;

            do
            {
                input = Console.ReadLine();
                if (input.ToUpper() != "STOP")
                {
                    processor.ProcessCommand(input);
                }
            } while (input.ToUpper() != "STOP");

            Console.WriteLine("Simulation ended.");

        }
    }
}