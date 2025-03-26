using ToyRobotSimulation;
using NUnit.Framework;
using FluentAssertions;

namespace SimulatorAppTests
{
    public class RobotPlacementTests
    {
        [Test]
        public void Place_ValidPosition_SetsPositionAndFacing()
        {
            var table = new Table(5, 5);
            var robot = new Robot(table);

            robot.Place(0, 0, "NORTH");
            robot.X.Should().Be(0);
            robot.Y.Should().Be(0);
            robot.Facing.Should().Be("NORTH");
        }

        [Test]
        public void Place_InvalidPosition_IgnoresPlacement()
        {
            var table = new Table(5, 5);
            var robot = new Robot(table);

            robot.Place(-1, 0, "NORTH");
            robot.Facing.Should().BeNull();
        }
    }
}