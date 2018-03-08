using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            if (args.Length > 1)
                filename = args[1];

            BattlefieldBuilder battleFieldBuilder = null;
            var commandFileReader = new CommandFileReader(filename);
            var remoteController = new RemoteControl();
            Drone drone = null;
            foreach (var command in commandFileReader.Readline())
            {
                switch(command.CommandType)
                {
                    case CommandLineType.UpperRightCoordinates:
                        battleFieldBuilder = new BattlefieldBuilder(command.Position);
                        break;
                    case CommandLineType.DroneInit:
                        drone = battleFieldBuilder.GetDrone(command.Position, command.Direction);
                        Console.WriteLine("Drone Initial position: " + drone.ToString());
                        break;
                    case CommandLineType.Moves:
                        if (drone == null)
                            break;
                        foreach (var c in command.DroneMoves)
                            RemoteControl.SendCommandToDrone(c, drone);
                        Console.WriteLine("Moves :" + command.Text);
                        Console.WriteLine("Drone Final position: " + drone.ToString());
                        break;

                    case CommandLineType.Unknown:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
            Console.ReadKey();
        }
        
    }
}
