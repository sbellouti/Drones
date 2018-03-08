using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    public class DroneController
    {
        public virtual CardinalCompassPointEnum TurnLeft(CardinalCompassPointEnum direction)
        {
            switch(direction)
            {
                case CardinalCompassPointEnum.East:
                    return CardinalCompassPointEnum.North;
                case CardinalCompassPointEnum.North:
                    return CardinalCompassPointEnum.West;
                case CardinalCompassPointEnum.West:
                    return CardinalCompassPointEnum.South;
                case CardinalCompassPointEnum.South:
                    return CardinalCompassPointEnum.East;
            }
            return CardinalCompassPointEnum.East;
        }
        public virtual CardinalCompassPointEnum TurnRight(CardinalCompassPointEnum direction)
        {
            switch (direction)
            {
                case CardinalCompassPointEnum.East:
                    return CardinalCompassPointEnum.South;
                case CardinalCompassPointEnum.South:
                    return CardinalCompassPointEnum.West;
                case CardinalCompassPointEnum.West:
                    return CardinalCompassPointEnum.North;
                case CardinalCompassPointEnum.North:
                    return CardinalCompassPointEnum.East;
            }
            return CardinalCompassPointEnum.East;
        }
        public virtual Point Move(Point position, Drones.CardinalCompassPointEnum direction)
        {
            var newPosition = new Point() { X = position.X, Y = position.Y };
            switch(direction)
            {
                case CardinalCompassPointEnum.North:
                    newPosition.Y++;
                    break;
                case CardinalCompassPointEnum.South:
                    newPosition.Y--;
                    break;
                case CardinalCompassPointEnum.East:
                    newPosition.X++;
                    break;
                default:
                    newPosition.X--;
                    break;
            }

            //Check that the new position is within the battlefield
            if (IsWithinBoundaries(newPosition))
                return newPosition;
            
            return position;
        }
        /// <summary>
        /// Checks that the position is within the battlefield boundaries
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        protected bool IsWithinBoundaries(Point position)
        {
            if ((position.X >= 0 && position.Y >= 0) && (position.X <= BattleField.Instance.UpperRight.X && position.Y <= BattleField.Instance.UpperRight.Y))
                return true;
            return false;
        }

    }
}
