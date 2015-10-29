using System;
using System.Drawing;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.Sprites
{
    public class Sprite
    {
        public enum State { Idle, Moving, Attacking }

        private Image spriteMap;
        private Image image;
        private Rectangle rectDest;
        private Point originInMap;

        private readonly int sourceSize = 32;
        private State state = State.Idle;
        private long stateChangedAtTime = 0;

        /// <summary>
        /// The current bitmap used to represent the sprite.
        /// </summary>
        public Image Image { get { return image; } }
        /// <summary>
        /// The rendered dimension of the sprite (always square for now).
        /// </summary>
        public static int Size { get { return World.Instance.GridSize; } }
        /// <summary>
        /// Retrieves the current sprite state.
        /// </summary>
        public State SpriteState { get { return state; } }

        /// <summary>
        /// Constructor for new sprites.
        /// </summary>
        /// <param name="pathToSpriteMap">To path to the sprite map to use.</param>
        /// <param name="originInMap">The base position of this sprite in the map.</param>
        public Sprite(string pathToSpriteMap, Point originInMap)
        {
            image = new Bitmap(Size, Size);
            rectDest = new Rectangle(0, 0, Size, Size);
        
            spriteMap = Image.FromFile(pathToSpriteMap);
            this.originInMap = originInMap;
            UpdateImage(Direction.Right);
        }

        /// <summary>
        /// Change the state of the sprite.
        /// </summary>
        /// <param name="newState">The new state to assume.</param>
        public void ChangeState(State newState)
        {
            if (newState != state)
            {
                stateChangedAtTime = World.Instance.Time;
            }
            state = newState;
        }

        /// <summary>
        /// Update the sprite image to use based on the direction and state
        /// </summary>
        public void UpdateImage(Direction direction)
        {
            // This variable holds the location of the sprite in the sprite map
            Point posInMap = originInMap;

            // Sprites are organized by direction, so first determine the block
            switch (direction)
            {
                case Direction.Down: posInMap.Offset(0, 0); break;
                case Direction.Left: posInMap.Offset(0, 1); break;
                case Direction.Right: posInMap.Offset(0, 2); break;
                case Direction.Up: posInMap.Offset(0, 3); break;
                default: throw new InvalidOperationException("Invalid direction");
            }

            // Determine the exact sprite needed, based on the current state;
            // if it is a moving or attacking state, alternate the images
            const int steps = 3;
            const int stepspeed = 200;
            int step = (int)((World.Instance.Time - stateChangedAtTime) % (stepspeed * steps) / stepspeed);
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Moving:
                    posInMap.X = originInMap.X + ((posInMap.X + step + 1) % steps);
                    break;
                case State.Attacking:
                    posInMap.X = originInMap.X + ((posInMap.X + step + 1) % 2);
                    break;
            }

            // Render the relevant part of the sprite map to the image
            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.Transparent);
                g.DrawImage(spriteMap,
                    rectDest,
                    new Rectangle(posInMap.X * sourceSize, posInMap.Y * sourceSize,
                                  sourceSize, sourceSize),
                    GraphicsUnit.Pixel);
            }
        }
    }
}
