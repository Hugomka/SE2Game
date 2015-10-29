using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE2Game.Utils;

namespace SE2Game.Items
{
    class Boots : Item
    {
        public Boots(Vector position)
                : base("Boots", position)
        {
            image = System.Drawing.Image.FromFile("sprites/boots.png");
        }
    }
}