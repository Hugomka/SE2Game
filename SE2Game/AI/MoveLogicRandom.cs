using System;
using System.Drawing;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.AI
{
    public class MoveLogicRandom : IMoveLogic
    {
        private Vector currentDirection;
        private long lastUpdate;

        public string Name { get { return "Random"; } }

        public MoveLogicRandom()
        {
            currentDirection = new Vector();
            lastUpdate = World.Instance.Time;
        }

        public Vector MakeMove(Vector currentPosition, Vector targetPosition)
        {
            // Change direction every half second
            if (World.Instance.Time - lastUpdate > World.Instance.RandomNumber(400, 600))
            {
                switch (World.Instance.RandomNumber(5))
                {
                    case 0: currentDirection = new Vector(1, 0); break;
                    case 1: currentDirection = new Vector(0, 1); break;
                    case 2: currentDirection = new Vector(-1, 0); break;
                    case 3: currentDirection = new Vector(0, -1); break;
                    default: currentDirection = new Vector(0, 0); break;
                }

                lastUpdate = World.Instance.Time;
            }

            return currentDirection;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
