using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    public class BattleField
    {

        public static BattleField Instance
        {
            get
            {
                return _instance;
            }
        }

        private BattleField()
        {
        }

        public Point UpperRight { get; set; }
        private static BattleField _instance = new BattleField();
    }
}
