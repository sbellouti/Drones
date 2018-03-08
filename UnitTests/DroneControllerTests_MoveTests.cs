using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace UnitTests
{
    [TestClass]
    public class DroneControllerTests_MoveTests
    {
        private Drones.DroneController _droneController = new Drones.DroneController();
        
        [TestInitialize]
        public void Initialize()
        {
            Drones.BattleField.Instance.UpperRight = new Point(10, 10);
        }


        [TestMethod]
        public void MoveForwardWhenHeadingNorth()
        {
            var currentPosition = new Point(3, 4);
            var newPosition = _droneController.Move(currentPosition, Drones.CardinalCompassPointEnum.North);
            Assert.IsTrue(newPosition.X == currentPosition.X);
            Assert.IsTrue(newPosition.Y == currentPosition.Y + 1);
        }

        [TestMethod]
        public void MoveForwardWhenHeadingSouth()
        {
            var currentPosition = new Point(3, 4);
            var newPosition = _droneController.Move(currentPosition, Drones.CardinalCompassPointEnum.South);
            Assert.IsTrue(newPosition.X == currentPosition.X);
            Assert.IsTrue(newPosition.Y == currentPosition.Y - 1);
        }
        [TestMethod]
        public void MoveForwardWhenHeadingEast()
        {
            var currentPosition = new Point(3,4);
            var newPosition = _droneController.Move(currentPosition, Drones.CardinalCompassPointEnum.East);
            Assert.AreEqual(currentPosition.X + 1, newPosition.X);
            Assert.AreEqual(newPosition.Y, currentPosition.Y);
        }
        [TestMethod]
        public void MoveForwardWhenHeadingWest()
        {
            var currentPosition = new Point(3,4);
            var newPosition = _droneController.Move(currentPosition, Drones.CardinalCompassPointEnum.West);
            Assert.IsTrue(newPosition.X == currentPosition.X - 1);
            Assert.IsTrue(newPosition.Y == currentPosition.Y);
        }
        [TestMethod]
        public void MoveForwardOutsideTheBattlefield_East_ExpectSamePosition()
        {
            var currentPosition = new Point(10,5);
            //try to move east (outside the battlefield)
            var newPosition = _droneController.Move(currentPosition, Drones.CardinalCompassPointEnum.East);
            Assert.AreEqual(currentPosition, newPosition);
        }

        [TestMethod]
        public void MoveForwardOutsideTheBattlefield_West_ExpectSamePosition()
        {
            var currentPosition = new Point(0,5);
            //try to move east (outside the battlefield)
            var newPosition = _droneController.Move(currentPosition, Drones.CardinalCompassPointEnum.West);
            Assert.AreEqual(currentPosition, newPosition);
        }

        [TestMethod]
        public void MoveForwardOutsideTheBattlefield_North_ExpectSamePosition()
        {
            var currentPosition = new Point(0,10);
            //try to move east (outside the battlefield)
            var newPosition = _droneController.Move(currentPosition, Drones.CardinalCompassPointEnum.North);
            Assert.AreEqual(currentPosition, newPosition);
        }

        [TestMethod]
        public void MoveForwardOutsideTheBattlefield_South_ExpectSamePosition()
        {
            var currentPosition = new Point(0,0);
            //try to move east (outside the battlefield)
            var newPosition = _droneController.Move(currentPosition, Drones.CardinalCompassPointEnum.South);
            Assert.AreEqual(currentPosition, newPosition);
        }

    }
}
