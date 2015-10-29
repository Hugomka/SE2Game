using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Input;
using SE2Game.AI;

namespace SE2Game.Utils
{
    public static class Util
    {
        public static bool IsKeyDown(Key key)
        {
            return (Keyboard.GetKeyStates(key) & KeyStates.Down) > 0;
        }

        public static Direction DetermineDirection(Vector v)
        {
            if (Math.Abs(v.X) >= Math.Abs(v.Y))
            {
                if (v.X >= 0)
                {
                    return Direction.Right;
                }
                return Direction.Left;
            }
            else
            {
                if (v.Y >= 0)
                {
                    return Direction.Down;
                }
                return Direction.Up;
            }
        }

        /// <summary>
        /// This method get all assemblies for the current project, and then
        /// for each item checks if it is a class, and if an instance
        /// implementing the IMoveLogic interface can be created from this
        /// class. If so, it is added to the list of available types.
        /// </summary>
        /// <returns>A list of types that are all the IMoveLogic
        /// implementations in this project.</returns>
        public static List<Type> AvailableMoveLogics()
        {
            var type = typeof(IMoveLogic);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(s => s.GetTypes())
                            .Where(p => type.IsAssignableFrom(p) && p.IsClass).ToList<Type>();
            return types;
        }

        /// <summary>
        /// Creates a new instance that implements the IMoveLogic interface,
        /// based on a given type. This can be used along with the
        /// AvailableMoveLogics-method above to create instances when the user
        /// has selected a certain AI.
        /// </summary>
        /// <returns>A new instance of the requested type.</returns>
        public static IMoveLogic NewMoveLogic(Type moveLogic)
        {
            return (IMoveLogic)Activator.CreateInstance(moveLogic);
        }
    }
}
