using System;
using System.Collections.Generic;
using System.Drawing;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.AI
{
    public class MoveLogicPathFinder : IMoveLogic
    {
        private Point currentCell;
        private Vector previousPosition;
        private bool toNewCenter = false;

        public string Name { get { return "PathFinder"; } }

        public MoveLogicPathFinder()
        {
        }

        public Vector MakeMove(Vector currentPosition, Vector targetPosition)
        {
            Vector direction = new Vector();
            Point targetCell = World.Instance.Map.PointToCell(targetPosition);

            // Lists to hold the cells that have been checked and still should be checked
            List<Node> closed = new List<Node>();
            List<Node> queue = new List<Node>();

            Node startNode = new Node(World.Instance.Map.PointToCell(currentPosition));
            if (startNode.Cell != currentCell || previousPosition == currentPosition)
            {
                currentCell = startNode.Cell;
                toNewCenter = true;
            }
            previousPosition = currentPosition;
            
            // Check if we are at the center of our current cell
            Vector targetCenter = World.Instance.Map.CellCenter(startNode.Cell);
            double distance = (targetCenter - currentPosition).Length();

            if (toNewCenter && distance >= 2)
            {
                return targetCenter - currentPosition;
            }
            else
            {
                toNewCenter = false;
            }
            NodeSorter nodeSorter = new NodeSorter();
            startNode.Cost = 0;
            queue.Add(startNode);
            Node currentNode = startNode;

            // Keep looping until all nodes have been processed (simple A*)
            while (queue.Count > 0)
            {
                currentNode = queue[0];
                queue.Remove(currentNode);

                // Check if this is the cell to be reached; if so: exit loop
                if (currentNode.Cell == targetCell)
                {
                    break;
                }

                // Mark cell as visited
                closed.Add(currentNode);

                foreach(Node adjacent in AvailableNodes(currentNode.Cell))
                {
                    // See if we already visited this cell; if so: skip
                    if (closed.IndexOf(adjacent) >= 0)
                    {
                        continue;
                    }

                    // Is the cell easier to access via this path; if so: update
                    if (currentNode.Cost + 1 < adjacent.Cost)
                    {
                        adjacent.Cost = currentNode.Cost + 1;
                        adjacent.Estimate = Math.Abs(adjacent.Cell.X - targetCell.X) +
                                            Math.Abs(adjacent.Cell.Y - targetCell.Y);
                        adjacent.FromNode = currentNode;
                    }

                    if (queue.IndexOf(adjacent) == -1)
                    {
                        queue.Add(adjacent);
                    }
                }

                // Sort the nodes so the best guesses are evaluated first
                queue.Sort(nodeSorter);
            }

            // Determine the next node by traversing the node list
            while (currentNode.FromNode != null && currentNode.FromNode.Cell != startNode.Cell)
            {
                currentNode = currentNode.FromNode;
            }
            
            // Set the target position to the center of the next cell and move towards it
            targetPosition = World.Instance.Map.CellCenter(currentNode.Cell);

            return targetPosition - currentPosition;
        }

        private List<Node> AvailableNodes(Point currentCell)
        {
            // Determine adjacent cells
            List<Node> result = new List<Node>();
            if (currentCell.X > 0)
            {
                result.Add(new Node(new Point(currentCell.X - 1, currentCell.Y)));
            }
            if (currentCell.X < World.Instance.Map.Width - 1)
            {
                result.Add(new Node(new Point(currentCell.X + 1, currentCell.Y)));
            }
            if (currentCell.Y > 0)
            {
                result.Add(new Node(new Point(currentCell.X, currentCell.Y - 1)));
            }
            if (currentCell.Y < World.Instance.Map.Height - 1)
            {
                result.Add(new Node(new Point(currentCell.X, currentCell.Y + 1)));
            }

            // Remove walls from result set
            for (int i = result.Count - 1; i >= 0; i--)
            {
                if (World.Instance.Map.CellContentAtCell(result[i].Cell) == Map.CellContent.Wall)
                {
                    result.RemoveAt(i);
                }
            }

            return result;
        }

        public override string ToString()
        {
            return Name;
        }

        // Hide warnings indicating that GetHashCode are not
        // overridden: for the scope of this project and for didactic purposes
        // this is considered better instead of properly implementing these as
        // there are no use cases like dictionaries expected.
        #pragma warning disable 659
        /// <summary>
        /// Wrapper class to be able to formulate a path from cells
        /// </summary>
        class Node
        {
            public Point Cell { get; set; }
            public Node FromNode { get; set; }
            public int Cost { get; set; }
            public float Estimate { get; set; }

            public Node(Point cell)
            {
                Cell = cell;
                FromNode = null;
                Cost = int.MaxValue;
            }

            public override bool Equals(object obj)
            {
                if (obj != null & obj is Node)
                {
                    return Cell == (obj as Node).Cell;
                }
                return false;
            }
        }
        #pragma warning restore 659

        /// <summary>
        /// Sorter to sort nodes based on their total and estimated cost
        /// </summary>
        class NodeSorter : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                return (x.Cost + Convert.ToInt32(x.Estimate)) -
                       (y.Cost + Convert.ToInt32(y.Estimate));
            }
        }
    }
}
