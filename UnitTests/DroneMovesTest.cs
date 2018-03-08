using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Drones;
using System.Drawing;

namespace UnitTests
{
    [TestClass]
    public class DroneMovesTest
    {

        private BattlefieldBuilder _builder;
        [TestInitialize]
        public void Iniatialize()
        {
            _builder = new BattlefieldBuilder(new Point(5, 5));
        }

        [TestMethod]
        public void ValidateDroneMovesResults_1()
        {
            var drone = _builder.GetDrone(new Point(0, 0), CardinalCompassPointEnum.East);
            var command = CommandInterpreter.GetCommandFromString("***");
            foreach(var c in command.DroneMoves)
            {
                RemoteControl.SendCommandToDrone(c, drone);
            }

            Assert.AreEqual(new Point(3, 0), drone.Position);
            Assert.AreEqual(CardinalCompassPointEnum.East, drone.Direction);
        }

        [TestMethod]
        public void ValidateDroneMovesResults_ReachLowerEdge_NoMoves()
        {
            var drone = _builder.GetDrone(new Point(0, 0), CardinalCompassPointEnum.East);
            var command = CommandInterpreter.GetCommandFromString("***>**");
            foreach (var c in command.DroneMoves)
            {
                RemoteControl.SendCommandToDrone(c, drone);
            }

            Assert.AreEqual(new Point(3, 0), drone.Position);
            Assert.AreEqual(CardinalCompassPointEnum.South, drone.Direction);
        }

        [TestMethod]
        public void ValidateDroneMovesResults_2()
        {
            var drone = _builder.GetDrone(new Point(0, 0), CardinalCompassPointEnum.East);
            var command = CommandInterpreter.GetCommandFromString("***<**");
            foreach (var c in command.DroneMoves)
            {
                RemoteControl.SendCommandToDrone(c, drone);
            }

            Assert.AreEqual(new Point(3, 2), drone.Position);
            Assert.AreEqual(CardinalCompassPointEnum.North, drone.Direction);
        }


        [TestMethod]
        public void ValidateDroneMovesResults_3()
        {
            var drone = _builder.GetDrone(new Point(1, 1), CardinalCompassPointEnum.North);
            var command = CommandInterpreter.GetCommandFromString(">********<**********");
            foreach (var c in command.DroneMoves)
            {
                RemoteControl.SendCommandToDrone(c, drone);
            }

            Assert.AreEqual(new Point(5, 5), drone.Position);
            Assert.AreEqual(CardinalCompassPointEnum.North, drone.Direction);
        }
        [TestMethod]
        public void ValidateDroneMovesResults_4()
        {
            var drone = _builder.GetDrone(new Point(1, 2), CardinalCompassPointEnum.North);
            var command = CommandInterpreter.GetCommandFromString("<*<*<*<**");//<*<**");
            foreach (var c in command.DroneMoves)
            {
                RemoteControl.SendCommandToDrone(c, drone);
            }

            Assert.AreEqual(new Point(1, 3), drone.Position);
            Assert.AreEqual(CardinalCompassPointEnum.North, drone.Direction);
        }
    }
}
