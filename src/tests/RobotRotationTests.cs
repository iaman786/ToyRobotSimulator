using FluentAssertions;
using ToyRobotSimulationApp;
using NUnit.Framework;


namespace SimulatorAppTests
{
    public class RobotRotationTests
    {
        [Test]
        public void RotateLeft_ChangesFacingDirection()
        {
            var table = new Table(5, 5);
            var robot = new Robot(table);

            robot.Place(0, 0, "NORTH");
            robot.RotateLeft();

            robot.Facing.Should().Be("WEST");
        }

        [Test]
        public void RotateRight_ChangesFacingDirection()
        {
            var table = new Table(5, 5);
            var robot = new Robot(table);

            robot.Place(0, 0, "NORTH");
            robot.RotateRight();

            robot.Facing.Should().Be("EAST");
        }
    }
}
