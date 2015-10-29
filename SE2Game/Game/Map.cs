using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using SE2Game.Utils;

namespace SE2Game.Game
{
    public class Map
    {
        public enum CellContent
        {
            Blank = 1,
            Wall = 2,
            Goal = 4
        };

        // Two dimensional array to hold each cell value
        private CellContent[,] cells;

        private Point goalPosition;
        /// <summary>
        /// The chance that a wall is randomly inserted into generated maps.
        /// </summary>
        private const int WallProbability = 20;

        /// <summary>
        /// The width of the map in cells.
        /// </summary>
        public int Width { get { return cells.GetLength(0); } }
        /// <summary>
        /// The height of the map in cells.
        /// </summary>
        public int Height { get { return cells.GetLength(1); } }


        /// <summary>
        /// Create a new map instance with the given size.
        /// </summary>
        /// <param name="width">The width of the map in cells.</param>
        /// <param name="height">The height of the map in cells.</param>
        /// <param name="fromFile">The bool from createNewMap</param>
        public Map(int width, int height, bool fromFile)
        {
            string filePath = "map.txt";

            if (!fromFile && File.Exists(filePath))
            {
                cells = ReadFile(filePath);
            }
            else
            {
                cells = new CellContent[width, height];
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if ((x > 1 || y > 1) && // We don't want a wall were we start
                            World.Instance.RandomNumber(100) < WallProbability)
                        {
                            cells[x, y] = CellContent.Wall;
                        }
                        else
                        {
                            cells[x, y] = CellContent.Blank;
                        }
                    }
                }

                // Set a random goal position in the lower right quartile
                goalPosition = new Point(World.Instance.RandomNumber(Width * 3 / 4, Width),
                                         World.Instance.RandomNumber(Height * 3 / 4, Height));
                cells[goalPosition.X, goalPosition.Y] = CellContent.Goal;
                goalPosition.X *= World.Instance.GridSize;
                goalPosition.Y *= World.Instance.GridSize;

                // Write this map in a text file
                WriteFile(cells);
            }
        }

        public Map(string filePath)
        {
            if (File.Exists(filePath))
            {
                cells = ReadFile(filePath);
            }
        }

        #region old methods writefile and readfile
        //private void WriteFile(CellContent[,] cells)
        //{
        //    try
        //    {
        //        using (StreamWriter text = new StreamWriter("map.txt"))
        //        {
        //            for (int y = 0; y < Height; y++)
        //            {
        //                for (int x = 0; x < Width; x++)
        //                {
        //                    text.Write(x + " " + y + " " + CellContentAtCell(new Point(x, y)) + " ");
        //                }
        //                text.Write("\r\n");
        //            }
        //        }
        //    }
        //    catch (IOException IOE)
        //    {
        //        MessageBox.Show(IOE.Message, "Error IOException", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private CellContent[,] ReadFile(string filePath)
        //{
        //    if (File.Exists(filePath))
        //    {
        //            string[] lines = File.ReadAllLines(filePath);
        //            string[] splits = lines[0].Split(' ');

        //            int countCellsForX = (splits.Length - 1) / 3;
        //            int countCellsForY = lines.Length;
        //            CellContent[,] cells = new CellContent[countCellsForX, countCellsForY];

        //            for (int y = 0; y < countCellsForY; y++)
        //            {
        //            splits = lines[y].Split(' ');
        //            for (int x = 0; x < countCellsForX; x++)
        //                {
        //                Console.WriteLine(splits[(x * 3) + 2]);
        //                    switch (splits[(x * 3) + 2])
        //                    {
        //                        case "Goal":
        //                            cells[x, y] = CellContent.Goal;
        //                            break;
        //                        case "Wall":
        //                            cells[x, y] = CellContent.Wall;
        //                            break;
        //                        case "Blank":
        //                            cells[x, y] = CellContent.Blank;
        //                            break;
        //                    }
        //                }

        //            }
        //            return cells;
        //    }

        //        return null;
        //}
        #endregion

        /// <summary>
        /// Write the world map in a text file
        /// </summary>
        /// <param name="cells">List of cells' location</param>
        private void WriteFile(CellContent[,] cells)
        {
            using (StreamWriter text = new StreamWriter("map.txt"))
            {
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        text.Write("[" + x + "," + y + "]\t");
                    }
                    text.WriteLine("");
                    for (int x = 0; x < Width; x++)
                    {
                        text.Write(CellContentAtCell(new Point(x, y)) + "\t");
                    }
                    text.WriteLine("\r\n");
                }
            }
        }

        /// <summary>
        /// Read the text file for recreating the saved world map
        /// </summary>
        /// <param name="filePath">A path to the file's location</param>
        /// <returns></returns>
        private CellContent[,] ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                string[] cellContents = lines[1].Split('\t');

                int countCellsForX = cellContents.Length - 1;
                int countCellsForY = lines.Length / 3;

                CellContent[,] cells = new CellContent[countCellsForX, countCellsForY];
                for (int y = 0; y < countCellsForY; y++)
                {
                    cellContents = lines[y * 3 + 1].Split('\t');
                    for (int x = 0; x < countCellsForX; x++)
                    {
                        switch (cellContents[x])
                        {
                            case "Goal":
                                cells[x, y] = CellContent.Goal;
                                break;
                            case "Wall":
                                cells[x, y] = CellContent.Wall;
                                break;
                            case "Blank":
                                cells[x, y] = CellContent.Blank;
                                break;
                            default:
                                 throw new InvalidMapException("Corrupt data: \"" + cellContents[x] + "\", actually expecting: Goal, Wall or Blank");
                        }
                    }
                }
                return cells;
            }
            return cells;
        }

        public void Draw(Graphics g)
        {
            // Abbreviation variable to shorten code below
            int gs = World.Instance.GridSize;

            // Draw grid lines 
            for (int i = 0; i < Width; i++)
            {
                g.DrawLine(Pens.LightGray, 0, i * gs, Width * gs, i * gs);
                g.DrawLine(Pens.LightGray, i * gs, 0, i * gs, Height * gs);
            }

            // Color cells
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Rectangle rect = new Rectangle(x * gs, y * gs, gs + 1, gs + 1);
                    switch (cells[x, y])
                    {
                        case CellContent.Goal:
                            g.FillRectangle(World.Instance.PlayerHasAllItems ?
                                Brushes.DarkGreen : Brushes.DarkRed, rect);
                            break;
                        case CellContent.Wall:
                            g.FillRectangle(Brushes.Black, rect);
                            break;
                        case CellContent.Blank:
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// If a wall is in a cell below the entity, draw it again to make it
        /// appear in front of the entity.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="entity"></param>
        public void DrawWallBeforeEntity(Graphics g, Entities.Entity entity)
        {
            // Determine the cell the entity is in
            Point p = PointToCell(entity.Position);
            // Update the position: -1 for X so that the for loop checks the
            // three cells currently below the entity; -1 for Y to move below
            p.X -= 1;
            p.Y += 1;

            for (int x = 0; x < 3; x++)
            {
                if (CellContentAtCell(p) == CellContent.Wall)
                {
                    int gs = World.Instance.GridSize;
                    Rectangle rect = new Rectangle(p.X * gs, p.Y * gs, gs + 1, gs + 1);
                    g.FillRectangle(Brushes.Black, rect);
                }
                p.X += 1;
            }
        }

        /// <summary>
        /// Returns the center coordinate (for sprites) of a random cell that
        /// is passable and not occupied.
        /// </summary>
        public Vector RandomFreePosition()
        {
            Point result;
            do
            {
                result = PointToCell(World.Instance.RandomPosition());
            } while (cells[result.X, result.Y] != CellContent.Blank ||  // Unpassable cell
                     World.Instance.EntityAtCell(result) != null);      // Occupied cell
            return CellCenter(result);
        }

        /// <summary>
        /// Converts a coordinate to a cell index.
        /// </summary>
        public Point PointToCell(int x, int y)
        {
            return new Point(x / World.Instance.GridSize % Width,
                             y / World.Instance.GridSize % Height);
        }
            
        /// <summary>
        /// Converts a coordinate to a cell index.
        /// </summary>
        public Point PointToCell(Vector v)
        {
            return PointToCell(Convert.ToInt32(v.X), Convert.ToInt32(v.Y));
        }
        /// <summary>
        /// Given a point, returns the center of the cell that point is in.
        /// </summary>
        public Vector CellCenter(Point point)
        {
            return CellToPoint(point) + World.Instance.GridSize / 2;
        }
        /// <summary>
        /// Converts a cell index to the coordinate at the top left of that cell.
        /// </summary>
        public Vector CellToPoint(Point point)
        {
            int gs = World.Instance.GridSize;
            return new Vector(point.X * gs, point.Y * gs);
        }
        public CellContent CellContentAtCell(Point p)
        {
            if (p.X < 0 || p.X >= Width || p.Y < 0 || p.Y >= Height)
            {
                return CellContent.Wall;
            }
            return cells[p.X, p.Y];
        }
        public CellContent CellContentAtPoint(Vector v)
        {
            Point p = PointToCell(Convert.ToInt32(v.X), Convert.ToInt32(v.Y));
            return cells[p.X, p.Y];
        }

        /// <summary>
        /// Returns true if the given position does not intersect an non-passable cell.
        /// </summary>
        public bool Reachable(Vector v)
        {
            return CellContentAtPoint(v) != CellContent.Wall;
        }
    }
}
