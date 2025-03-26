using FluentAssertions;
using NUnit.Framework;
using ToyRobotSimulationApp;

namespace SimulatorAppTests
{
    internal class RobotMovementTests
    {

        [Test]
        public void Move_ValidMove_UpdatesPosition()
        {
            var table = new Table(5, 5);
            var robot = new Robot(table);

            robot.Place(0, 0, "NORTH");
            robot.Move();

            robot.X.Should().Be(0);
            robot.Y.Should().Be(1);
        }

        [Test]
        public void Move_InvalidMove_DoesNotUpdatePosition()
        {
            var table = new Table(5, 5);
            var robot = new Robot(table);

            robot.Place(0, 5, "NORTH");
            robot.Move();

            robot.X.Should().Be(0);
            robot.Y.Should().Be(5);// Robot remains at the edge
        }
    }
}
