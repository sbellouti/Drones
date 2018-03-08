using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Drones
{
    public class Drone
    {

        public Drone(Point position, CardinalCompassPointEnum direction)
        {
            Direction = direction;
            Position = position;
        }
        public void ExecuteCommand(DroneCommandEnum command)
        {
            switch (command)
            {
                case DroneCommandEnum.Right:
                    this.Direction = Controller.TurnRight(this.Direction);
                    break;
                case DroneCommandEnum.Left:
                    this.Direction = Controller.TurnLeft(this.Direction);
                    break;
                case DroneCommandEnum.Ahead:
                    this.Position = Controller.Move(this.Position, this.Direction);
                    break;
            }
        }
        public CardinalCompassPointEnum Direction { get; private set; }
        public Point Position { get; private set; }

        public DroneController Controller { get; set; }

        public override string ToString()
        {
            return String.Format(" Position({0},{1}) - Direction: {2}", Position.X, Position.Y, Direction.ToString());
        }
    }
}
