using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Drones
{
    public enum CommandLineType
    {
        UpperRightCoordinates,
        DroneInit,
        Moves,
        Unknown
    }
    public class CommandLine
    {
        public CommandLine(string text)
        {
            Text = text;
            CommandType = CommandLineType.Unknown;
        }
        public Point Position;
        public CardinalCompassPointEnum Direction;
        public CommandLineType CommandType;
        public char[] DroneMoves;
        public string Text;
    }
    public class CommandInterpreter
    {

        public static CommandLine GetCommandFromString(string line)
        {
            CommandLine command = new CommandLine(line);
            var chars = line.Split(' ');
            var point = Point.Empty;

            if (chars.Length >= 2)
            {
                point = GetPoint(chars);
                if (point == Point.Empty)
                    return command;
                command.Position = point;
            }

            if (chars.Length == 2)
                command.CommandType = CommandLineType.UpperRightCoordinates;
            

            if (chars.Length == 3)
            {
                var direction = GetDirection(chars[2]);
                if (!direction.HasValue)
                    return command;
                command.Direction = direction.Value;
                command.CommandType = CommandLineType.DroneInit;
            }

            if (chars.Length == 1)
            {
                if (string.IsNullOrEmpty(line))
                    return command;

                command.CommandType = CommandLineType.Moves;
                command.DroneMoves = line.ToArray();
            }

            return command;
        }
        
        private static CardinalCompassPointEnum? GetDirection(string direction)
        {
            if (string.IsNullOrEmpty(direction))
                return null;

            CardinalCompassPointEnum? result = null;
            switch(direction)
            {
                case "N":
                    result = CardinalCompassPointEnum.North;
                    break;
                case "E":
                    result = CardinalCompassPointEnum.East;
                    break;
                case "S":
                    result = CardinalCompassPointEnum.South;
                    break;
                case "W":
                    result = CardinalCompassPointEnum.West;
                    break;
            }
            return result;
        }
        private static Point GetPoint(string[] line)
        {
            int x;int y;
            if (Int32.TryParse(line[0], out x) && Int32.TryParse(line[1], out y))
                return new Point(x, y);
            return Point.Empty;
        }
    }
}
