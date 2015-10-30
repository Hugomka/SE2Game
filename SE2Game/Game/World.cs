using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using SE2Game.AI;
using SE2Game.Entities;
using SE2Game.Utils;
using SE2Game.Items;

namespace SE2Game.Game
{
    public class World
    {
        #region Fields and Properties
        /// <summary>
        /// Returns the number of elapsed milliseconds since the game started.
        /// </summary>
        public long Time { get { return stopwatch.ElapsedMilliseconds; } }
        /// <summary>
        /// Gets the size of the world in pixels.
        /// </summary>
        public Size Size { get; private set; }

        /// <summary>
        /// Get the player instance.
        /// </summary>
        public Player Player { get { return player; } }

        /// <summary>
        /// Has the world been created yet?
        /// </summary>
        public bool Created { get; private set; }
        /// <summary>
        /// Is the game over?
        /// </summary>
        public bool GameOver { get { return player.Hitpoints == 0; } }
        /// <summary>
        /// Is the game won?
        /// </summary>
        public bool GameWon
        {
            get
            {
                bool atGoal = Map.CellContentAtPoint(Player.Position) == Game.Map.CellContent.Goal;
                return atGoal && PlayerHasAllItems;
            }
        }
        public bool PlayerHasAllItems
        {
            get
            {
                //Is misschien beter om een aparte functie te hebben die alle items checkt
                return (player.HasItem<Key>() && player.HasItem<Helmet>() && player.HasItem<Boots>());
            }
        }

        /// <summary>
        /// The player entity.
        /// </summary>
        private Player player;
        /// <summary>
        /// The enemy entities.
        /// </summary>
        private List<Enemy> enemies;
        /// <summary>
        /// All available pickups.
        /// </summary>
        private List<Item> pickups;

        /// <summary>
        /// Used to get the elapsed time.
        /// </summary>
        private Stopwatch stopwatch;
        /// <summary>
        /// Holds the time that the last update took place.
        /// </summary>
        private long prevTime = 0;
        /// <summary>
        /// Random number generator used throughout the game
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Gives the size of a single grid cell (always square)
        /// </summary>
        public int GridSize { get { return 32; } }

        /// <summary>
        /// The current map.
        /// </summary>
        public Map Map { get; private set; }

        /// <summary>
        /// Variable to hold to only possible instance of the World class.
        /// </summary>
        static private World instance = null;
        /// <summary>
        /// Retrieve the instance of the World class, and create it if it does
        /// not yet exist. This construct is called the "Singleton Pattern".
        /// </summary>
        static public World Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new World();
                }
                return instance;
            }
        }

        /// <summary>
        /// Font to use for small text
        /// </summary>
        private Font smallFont = new Font(new FontFamily("Calibri"), 10.0f);
        public Font SmallFont { get { return smallFont; } }

        /// <summary>
        /// Formatter to center text
        /// </summary>
        private StringFormat stringFormat = new StringFormat();
        public StringFormat StringFormat { get { return stringFormat; } }

        #endregion

        /// <summary>
        /// Private constructor: can only be called from within this class.
        /// </summary>
        private World()
        {
            stopwatch = Stopwatch.StartNew();
            Created = false;

            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
        }

        /// <summary>
        /// Initializes the game world by creating a new map, player and enemy.
        /// </summary>
        /// <param name="size">The size of the map.</param>
        /// <param name="enemyCount">The number of enemies to create.</param>
        /// <param name="moveLogic">The AI to use, or null for random AI.</param>
        /// <param name="createNewMap">Create a new map, or reuse the current map.</param>
        public void Create(Size size, int enemyCount, Type moveLogic, bool createNewMap, string filePath)
        {
            // Prevent sprite jumps when restarting
            prevTime = 0;

            // Create a new map if needed
            Size = size;

            if(filePath != null)
            {
                Map = new Map(filePath);
            }
            else if (Map == null || createNewMap)
            {
                Map = new Map(size.Width / GridSize + 1, size.Height / GridSize + 1, createNewMap);
            }

            // Create a new player, always in the top left corner
            player = new Player(Map.CellCenter(new Point(0, 0)));

            // Create the enemies, using either a given AI or a random one
            enemies = new List<Enemy>();
            List<Type> availableMoveLogic = Util.AvailableMoveLogics();
            for (int x = 0; x < enemyCount; x++)
            {
                // Add the enemies, using a random AI if requested
                IMoveLogic newMoveLogic;
                if (moveLogic == null)
                {
                    int r = World.Instance.RandomNumber(availableMoveLogic.Count);
                    newMoveLogic = Util.NewMoveLogic(availableMoveLogic[r]);
                }
                else
                {
                    newMoveLogic = Util.NewMoveLogic(moveLogic);
                }
                enemies.Add(new Enemy(Map.RandomFreePosition(), newMoveLogic));
            }

            // Create the pickups
            pickups = new List<Item>();
            pickups.Add(new Key(Map.RandomFreePosition()));
            pickups.Add(new Helmet(Map.RandomFreePosition()));
            pickups.Add(new Boots(Map.RandomFreePosition()));

            Created = true;
        }

        /// <summary>
        /// Processes all updates to update the game world.
        /// </summary>
        public void Update()
        {
            if (prevTime == 0)
            {
                prevTime = Time;
            }

            // Determine the elapsed time and update the player and enemy
            float deltaTime = (Time - prevTime) / 1000.0f;
            player.Update(deltaTime);
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(deltaTime);

                // Determine if the player has been hit
                if (player.BoundingBox.IntersectsWith(enemy.BoundingBox))
                {
                    player.Hit(enemy);
                }
            }

            foreach (Item item in pickups)
            {
                if ((player.Position - item.Position).Length() < GridSize / 3)
                {
                    player.PickUp(item);
                    pickups.Remove(item);

                    // To prevent crashes: break when removing an item from
                    // the list that is currently looped over
                    break;
                }
            }

            player.SpeedUp();
            player.DefenceUp();

            prevTime = Time;
        }

        /// <summary>
        /// Draw the world objects to the canvas indicated by the parameter.
        /// </summary>
        /// <param name="g">The graphics object used to draw.</param>
        public void Draw(Graphics g)
        {
            Map.Draw(g);

            foreach (Item item in pickups)
            {
                item.Draw(g);
            }

            List<Entity> entities = new List<Entity>(enemies);
            entities.Add(player);
            entities.Sort();

            foreach (Entity entity in entities)
            {
                entity.Draw(g);
                Map.DrawWallBeforeEntity(g, entity);
            }
        }

        /// <summary>
        /// Because we need many random number in quick succession, the numbers
        /// will become identical in many cases. By defining one point that
        /// generates all numbers this problem is avoided.
        /// </summary>
        /// <param name="maxValue">The maximum number to generate.</param>
        /// <returns>A random integer in the range [0..maxValue></returns>
        public int RandomNumber(int maxValue)
        {
            return random.Next(maxValue);
        }
        public int RandomNumber(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
        public Vector RandomPosition()
        {
            return new Vector((RandomNumber(Size.Width) / GridSize) * GridSize,
                              (RandomNumber(Size.Height) / GridSize) * GridSize);
        }

        /// <summary>
        /// Given a cell, returns an entity that is currently located in this
        /// cell. If no entities are found, null is returned. Note that there
        /// is no logic handling the case where multiple entities occupy the
        /// same cell. In this case, the entity that is returned is only
        /// determined by the entity's position in the list.
        /// </summary>
        /// <param name="cell">The cell to check.</param>
        /// <returns>An entity if one is found; null otherwise.</returns>
        public Entity EntityAtCell(Point cell)
        {
            if (Map.PointToCell(Player.Position) == cell)
            {
                return Player;
            }

            foreach (Enemy enemy in enemies)
            {
                if (Map.PointToCell(enemy.Position) == cell)
                {
                    return enemy;
                }
            }

            return null;
        }
    }
}
