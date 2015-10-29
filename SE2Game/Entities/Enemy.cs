using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using SE2Game.Sprites;
using SE2Game.Utils;
using SE2Game.Game;
using SE2Game.AI;

namespace SE2Game.Entities
{
    public class Enemy : Entity
    {
        private IMoveLogic moveLogic;

        public int DamagePerHit { get { return 10; } }

        public Enemy(Vector position, IMoveLogic moveLogic)
            : base(position)
        {
            sprite = new Sprite("sprites/sprites.png", new Point(3, 0));
            this.moveLogic = moveLogic;
            maxSpeed = 65;
        }

        /// <summary>
        /// Function that determines which action the enemy should take.
        /// </summary>
        protected override void Move()
        {
            direction = moveLogic.MakeMove(position, World.Instance.Player.Position);
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            // Draw the name of the AI below the enemy
            PointF textPos = new PointF(Convert.ToSingle(position.X),
                Convert.ToSingle(position.Y) + Convert.ToSingle(World.Instance.GridSize / 1.33));
            g.DrawString(moveLogic.Name, World.Instance.SmallFont, Brushes.Black,
                textPos, World.Instance.StringFormat);
        }
    }
}
