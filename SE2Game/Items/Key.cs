using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE2Game.Utils;

namespace SE2Game.Items
{
    class Key : Item
    {
        public Key(Vector position)
                : base("Key", position)
        {
            image = System.Drawing.Image.FromFile("sprites/key.png");
        }
    }
}
