using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE2Game.Utils;

namespace SE2Game.Items
{
    class Helmet : Item
    {
        public Helmet(Vector position)
                : base("Helmet", position)
        {
            image = System.Drawing.Image.FromFile("sprites/helmet.png");
        }
    }
}
