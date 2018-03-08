using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DroneControllerTests_TurnLeftTests
    {
        [TestMethod]
        public void ValidateWhenHeadingToEastAndTurnLeft_ReturnsNorth()
        {
            var droneController = new Drones.DroneController();
            var newDirection = droneController.TurnLeft(Drones.CardinalCompassPointEnum.East);
            Assert.IsTrue(newDirection == Drones.CardinalCompassPointEnum.North);
        }
        [TestMethod]
        public void ValidateWhenHeadingToNorthAndTurnLeft_ReturnsWest()
        {
            var droneController = new Drones.DroneController();
            var newDirection = droneController.TurnLeft(Drones.CardinalCompassPointEnum.North);
            Assert.IsTrue(newDirection == Drones.CardinalCompassPointEnum.West);
        }

        [TestMethod]
        public void ValidateWhenHeadingToWestAndTurnLeft_ReturnsSouth()
        {
            var droneController = new Drones.DroneController();
            var newDirection = droneController.TurnLeft(Drones.CardinalCompassPointEnum.West);
            Assert.IsTrue(newDirection == Drones.CardinalCompassPointEnum.South);
        }

        [TestMethod]
        public void ValidateWhenHeadingToSouthAndTurnLeft_ReturnsEast()
        {
            var droneController = new Drones.DroneController();
            var newDirection = droneController.TurnLeft(Drones.CardinalCompassPointEnum.South);
            Assert.IsTrue(newDirection == Drones.CardinalCompassPointEnum.East);
        }
    }
}
