using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace UnitTests
{

    internal class DroneControllerForTest: Drones.DroneController
    {
        public bool TestIsWithinBoundaries(System.Drawing.Point point)
        {
            return base.IsWithinBoundaries(point);
        }
    }

    [TestClass]
    public class BattleFieldTests
    {
        private DroneControllerForTest _controller;

        [TestInitialize]
        public void Initialize()
        {
            Drones.BattleField.Instance.UpperRight = new System.Drawing.Point(5,5);
            _controller = new DroneControllerForTest();
        }

        [TestMethod]
        public void ValidatePositionIsWithinBoundaries()
        {
            Assert.IsTrue(_controller.TestIsWithinBoundaries(new Point(1,1)));
        }
        [TestMethod]
        public void ValidatePositionIsWithinOutsideBoundaries_Left()
        {
            Assert.IsFalse(_controller.TestIsWithinBoundaries(new Point(6, 1)));
        }
        [TestMethod]
        public void ValidatePositionIsWithinOutsideBoundaries_OnTop()
        {
            Assert.IsFalse(_controller.TestIsWithinBoundaries(new Point(1, 6)));
        }
        [TestMethod]
        public void ValidatePositionIsWithinOutsideBoundaries_OnUpperEdge()
        {
            Assert.IsTrue(_controller.TestIsWithinBoundaries(new Point(5,5)));
        }
        [TestMethod]
        public void ValidatePositionIsWithinOutsideBoundaries_OnLowerEdge()
        {
            Assert.IsTrue(_controller.TestIsWithinBoundaries(new Point(0, 0)));
        }
    }
}
