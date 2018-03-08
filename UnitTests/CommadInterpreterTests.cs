using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    /// <summary>
    /// Summary description for CommandFileReaderTests
    /// </summary>
    [TestClass]
    public class CommadInterpreterTests
    {

        [TestMethod]
        public void ReadlineWithOnlyCoordinates()
        {
            var command = Drones.CommandInterpreter.GetCommandFromString("5 5");
            Assert.AreEqual(Drones.CommandLineType.UpperRightCoordinates,command.CommandType);
            Assert.AreEqual(new System.Drawing.Point(5, 5), command.Position);
        }

        [TestMethod]
        public void ReadlineWitCoordinatesAndDirection()
        {
            var command = Drones.CommandInterpreter.GetCommandFromString("5 5 N");
            Assert.AreEqual(Drones.CommandLineType.DroneInit, command.CommandType);
            Assert.AreEqual(new System.Drawing.Point(5, 5), command.Position);
            Assert.AreEqual(Drones.CardinalCompassPointEnum.North, command.Direction);
        }

        [TestMethod]
        public void ReadlineWitALineOfCommands()
        {
            var commandLine = ">********<**********";
            var command = Drones.CommandInterpreter.GetCommandFromString(commandLine);
            Assert.AreEqual(Drones.CommandLineType.Moves, command.CommandType);
            Assert.AreEqual(commandLine.Length, command.DroneMoves.Length);
        }
    }
}
