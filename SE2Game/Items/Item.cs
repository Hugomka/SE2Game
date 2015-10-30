using System;
using System.Drawing;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.Items
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public Vector Position { get; protected set; }

        /// <summary>
        /// The rendered dimension of the item (always square for now).
        /// </summary>
        public static int Size { get { return World.Instance.GridSize; } }

        protected Image image;

        public Item(string name, Vector position)
        {
            Name = name;
            Position = position;
        }

        public void Draw(Graphics g)
        {
            // For items that have images, draw them; otherwise draw the item name
            if (image != null)
            {
                int his = Item.Size / 2;
                Rectangle rect = new Rectangle(Convert.ToInt32(Position.X) - his,
                                               Convert.ToInt32(Position.Y) - his,
                                               Item.Size, Item.Size);
                g.DrawImage(image, rect);
            }
            else
            {
                g.DrawString(Name, World.Instance.SmallFont, Brushes.DarkRed,
                              Position.ToPointF(), World.Instance.StringFormat);
            }
        }
    }
}
