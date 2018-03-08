using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    /// <summary>
    /// This class is responsible of setting up the battlefield and build drones with an initial position / direction
    /// </summary>
    public class BattlefieldBuilder
    {
        public BattlefieldBuilder(Point battleFieldUpperRight)
        {
            BattleField.Instance.UpperRight = battleFieldUpperRight;
        }

        public Drone GetDrone(Point startingPosition, CardinalCompassPointEnum direction)
        {
            var controller = new DroneController();
            var drone = new Drone(startingPosition, direction);
            drone.Controller = controller;
            return drone;
        }
    }
}
