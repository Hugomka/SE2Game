using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using SE2Game.Sprites;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.Entities
{
    public class Player : Entity
    {
        private List<Items.Item> inventory;

        public int Hitpoints
        {
            get;
            private set;
        }

        public Player(Vector position)
            : base(position)
        {
            sprite = new Sprite("sprites/sprites.png", new Point(0, 0));
            Hitpoints = 100;
            inventory = new List<Items.Item>();
            maxSpeed = 75;
        }

        public int Hit(Enemy hitBy)
        {
            int damage = hitBy.DamagePerHit;
            if (defenceUp)
            {
                damage /= 2;
            }
            
            int damageDealt = Math.Min(Hitpoints, damage);
            Hitpoints -= damageDealt;
            return damageDealt;
        }

        /// <summary>
        /// Function that determines which action the player should take.
        /// </summary>
        protected override void Move()
        {
            direction.X = 0;
            direction.Y = 0;

            if (Util.IsKeyDown(Key.Up)) direction.Y = -1;
            else if (Util.IsKeyDown(Key.Left)) direction.X = -1;
            else if (Util.IsKeyDown(Key.Down)) direction.Y = 1;
            else if (Util.IsKeyDown(Key.Right)) direction.X = 1;
        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);

            PointF textPos = new PointF(
                Convert.ToSingle(Position.X),
                Convert.ToSingle(Position.Y - World.Instance.GridSize / 1.33));

            string inv = "";
            foreach (Items.Item item in inventory)
            {
                inv += item.Name + " ";
            }
            g.DrawString(inv, World.Instance.SmallFont, Brushes.DarkBlue,
                         textPos, World.Instance.StringFormat);
        }

        public void PickUp(Items.Item item)
        {
            inventory.Add(item);
        }

        public bool HasItem<T>()
        {
            foreach (Items.Item item in inventory)
            {
                if (item is T)
                {
                    return true;
                }
            }
            return false;
        }

        private bool speedUp = false;
        public void SpeedUp()
        {
            if(HasItem<SE2Game.Items.Boots>() && !speedUp)
            {
                maxSpeed = Convert.ToInt32(Convert.ToDouble(maxSpeed) * 1.5d);
                speedUp = !speedUp;
            }
        }

        private bool defenceUp = false;
        public void DefenceUp()
        {
            if (HasItem<SE2Game.Items.Helmet>() && !defenceUp)
            {
                defenceUp = !defenceUp;
            }
        }
    }
}
