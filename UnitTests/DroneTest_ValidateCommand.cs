using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Drawing;

namespace UnitTests
{
    [TestClass]
    public class DroneTest_ValidateCommand
    {
        [TestInitialize]
        public void Initialize()
        {
            Drones.BattleField.Instance.UpperRight = new Point(10, 10);
        }

        [TestMethod]
        public void ValidateTurnRightCalledWhenGreaterThanCommandIsPassed()
        {
            var droneControllerMock = MockRepository.GenerateMock<Drones.DroneController>();
            var drone = new Drones.Drone(new System.Drawing.Point(10,10), Drones.CardinalCompassPointEnum.South);
            drone.Controller = droneControllerMock;
            droneControllerMock.Expect(x => x.TurnRight(Arg<Drones.CardinalCompassPointEnum>.Is.Anything)).Return(Drones.CardinalCompassPointEnum.East);
            drone.ExecuteCommand(Drones.DroneCommandEnum.Right);
            droneControllerMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ValidateTurnLeftCalledWhenLessThanCommandIsPassed()
        {
            var droneControllerMock = MockRepository.GenerateMock<Drones.DroneController>();
            var drone = new Drones.Drone(new System.Drawing.Point(10,10), Drones.CardinalCompassPointEnum.South);
            drone.Controller = droneControllerMock;
            droneControllerMock.Expect(x => x.TurnLeft(Arg<Drones.CardinalCompassPointEnum>.Is.Anything)).Return(Drones.CardinalCompassPointEnum.East);
            drone.ExecuteCommand(Drones.DroneCommandEnum.Left);
            droneControllerMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ValidateMoveCalledWhenAsterixCommandIsPassed()
        {
            var droneControllerMock = MockRepository.GenerateMock<Drones.DroneController>();
            var drone = new Drones.Drone(new System.Drawing.Point(10,10), Drones.CardinalCompassPointEnum.South);
            drone.Controller = droneControllerMock;
            droneControllerMock.Expect(x => x.Move(Arg<System.Drawing.Point>.Is.Anything, Arg<Drones.CardinalCompassPointEnum>.Is.Anything)).Return(new Point(1,1));
            drone.ExecuteCommand(Drones.DroneCommandEnum.Ahead);
            droneControllerMock.VerifyAllExpectations();
        }
    }
}
