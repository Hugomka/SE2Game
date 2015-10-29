using System;
using System.Collections.Generic;
using System.Drawing;
using SE2Game.Sprites;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.Entities
{
    public abstract class Entity : IComparable<Entity>
    {
        protected Sprite sprite;
        protected Vector position = new Vector();
        protected Vector direction = new Vector();
        public int maxSpeed { set; get; }

        /// <summary>
        /// The current position (center) of the sprite in the world.
        /// </summary>
        public Vector Position { get { return position; } }

        /// <summary>
        /// Gives the bounding box for the enemy. Not very smart, but it is
        /// sufficient for what is needed right now.
        /// </summary>
        public Rectangle BoundingBox
        {
            get
            {
                int hss = Sprite.Size / 2;
                int trim = 1; // Make the bounding box fit a little better
                return new Rectangle(Convert.ToInt32(Position.X) - hss + trim,
                                     Convert.ToInt32(Position.Y) - hss + trim,
                                     Sprite.Size - trim, Sprite.Size - trim);
            }
        }

        public Entity(Vector position)
        {
            this.position = position;
        }

        public virtual void Draw(Graphics g)
        {
            g.DrawImage(sprite.Image, (Position - Sprite.Size / 2).ToPointF());
        }

        /// <summary>
        /// Function that determines which action the entity should take.
        /// </summary>
        protected abstract void Move();

        /// <summary>
        /// Updates the position of the entity.
        /// </summary>
        /// <param name="deltaTime">The number of seconds elapsed since the previous call.</param>
        public void Update(float dt)
        {
            // Let the derived classes update the direction
            Move();

            // Update the sprite state to reflect that we are moving or not
            if (direction.X != 0 || direction.Y != 0)
            {
                sprite.ChangeState(Sprite.State.Moving);
            }
            else
            {
                sprite.ChangeState(Sprite.State.Idle);
            }

            if (sprite.SpriteState == Sprite.State.Moving)
            {
                Direction spriteDirection = Util.DetermineDirection(direction);
                Vector newPosition = position + (direction.Normalize() * maxSpeed * dt);

                int hss = Sprite.Size / 2;
                newPosition.X = Math.Max(hss, Math.Min(World.Instance.Size.Width - hss, newPosition.X));
                newPosition.Y = Math.Max(hss, Math.Min(World.Instance.Size.Height - hss, newPosition.Y));

                if (World.Instance.Map.Reachable(newPosition))
                {
                    position = newPosition;
                }

                sprite.UpdateImage(spriteDirection);
            }
        }

        public int CompareTo(Entity other)
        {
            return position.Y.CompareTo(other.position.Y);
        }
    }
}
