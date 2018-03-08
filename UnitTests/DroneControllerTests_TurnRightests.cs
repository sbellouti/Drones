using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DroneControllerTests_TurnRigthTests
    {
        private Drones.DroneController _droneController;

        [TestInitialize]
        public void Initialize()
        {
            Drones.BattleField.Instance.UpperRight = new System.Drawing.Point(10, 10);
            _droneController = new Drones.DroneController();
        }

        [TestMethod]
        public void ValidateWhenHeadingToEastAndTurnRight_ReturnsSouth()
        {
            var newDirection = _droneController.TurnRight(Drones.CardinalCompassPointEnum.East);
            Assert.AreEqual(Drones.CardinalCompassPointEnum.South, newDirection);
        }
        [TestMethod]
        public void ValidateWhenHeadingToSouthAndTurnRight_ReturnsWest()
        {
            var newDirection = _droneController.TurnRight(Drones.CardinalCompassPointEnum.South);
            Assert.AreEqual(Drones.CardinalCompassPointEnum.West, newDirection);
        }

        [TestMethod]
        public void ValidateWhenHeadingToWestAndTurnRight_ReturnsNorth()
        {
            var newDirection = _droneController.TurnRight(Drones.CardinalCompassPointEnum.West);
            Assert.AreEqual(Drones.CardinalCompassPointEnum.North, newDirection);
        }

        [TestMethod]
        public void ValidateWhenHeadingToNorthAndTurnRight_ReturnsEast()
        {
            var newDirection = _droneController.TurnRight(Drones.CardinalCompassPointEnum.North);
            Assert.AreEqual(Drones.CardinalCompassPointEnum.East, newDirection);
        }
    }
}
