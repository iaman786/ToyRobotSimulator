using FluentAssertions;
using ToyRobotSimulationApp;
using NUnit.Framework;

namespace SimulatorAppTests
{
    public class RobotReportTests
    {
        [Test]
        public void Report_ReturnsCorrectPositionAndFacing()
        {
            var table = new Table(5, 5);
            var robot = new Robot(table);

            robot.Place(2, 3, "EAST");
            var report = robot.Report();
            report.Should().Be("2,3,EAST");
        }

    }
}
