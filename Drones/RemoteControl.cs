using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    public class RemoteControl
    {
        public static void SendCommandToDrone(char command, Drone drone)
        {
            var droneCommand = GetDroneCommand(command);
            if (droneCommand!=DroneCommandEnum.Invalid)
                drone.ExecuteCommand(droneCommand);
        }
        private static DroneCommandEnum GetDroneCommand(char command)
        {
            switch(command)
            {
                case '>':
                    return DroneCommandEnum.Right;
                case '<':
                    return DroneCommandEnum.Left;
                case '*':
                    return DroneCommandEnum.Ahead;
                default:
                    return DroneCommandEnum.Invalid;
            }
        }
    }
}
