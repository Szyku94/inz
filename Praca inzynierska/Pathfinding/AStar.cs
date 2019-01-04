using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_inzynierska.Pathfinding
{
    class AStar
    {
        public static List<Node> calculatePath(Point startP, Point goalP, Grid grid)
        {
            Node start = new Node(startP);
            grid.setVisited(startP);
            Node goal = new Node(goalP);
            grid.setVisited(goalP);
            HashSet<Node> closed = new HashSet<Node>();
            HashSet<Node> open = new HashSet<Node>();
            open.Add(start);
            var cameFrom = new Dictionary<Node, Node>();
            var gScore = new Dictionary<Node, float>();
            gScore[start] = 0;
            var fScore = new Dictionary<Node, float>();
            fScore[start] = heuristicCostEstimate(start, goal);
            while (open.Count > 0)
            {
                Node min = open.ElementAt(0);
                foreach (Node n in open)
                {
                    if (fScore[min] > fScore[n])
                    {
                        min = n;
                    }
                }
                Node current = min;
                if (current.Equals(goal))
                {
                    return reconstructPath(cameFrom, current, grid);
                }
                open.Remove(current);
                grid.setVisited(current.point);
                closed.Add(current);
                foreach (Node neighbor in getNeighbors(current,grid))
                {
                    if (closed.Contains(neighbor))
                    {
                        continue;
                    }
                    if (!open.Contains(neighbor))
                    {
                        open.Add(neighbor);
                        gScore[neighbor] = float.PositiveInfinity;
                    }
                    float tentative_gScore = gScore[current] + 1;
                    if (tentative_gScore >= gScore[neighbor])
                    {
                        continue;
                    }
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentative_gScore;
                    fScore[neighbor] = gScore[neighbor] + heuristicCostEstimate(neighbor, goal);
                }
            }
            return null;

        }
        private static List<Node> reconstructPath(Dictionary<Node, Node> cameFrom, Node current,Grid grid)
        {
            List<Node> path = new List<Node>();
            path.Add(current);
            while (cameFrom.ContainsKey(current))
            {
                grid.setPath(current.point);
                current = cameFrom[current];
                path.Insert(0, current);
            }
            path.RemoveAt(0);
            return path;
        }
        private static HashSet<Node> getNeighbors(Node n,Grid grid)
        {
            HashSet<Node> neighbors = new HashSet<Node>();
            if (!grid.isWall(new Point(n.X - 1, n.Y - 1)))
            {
                neighbors.Add(new Node(new Point(n.X - 1, n.Y - 1)));
            }
            if (!grid.isWall(new Point(n.X - 1, n.Y)))
            {
                neighbors.Add(new Node(new Point(n.X - 1, n.Y)));
            }
            if (!grid.isWall(new Point(n.X - 1, n.Y + 1)))
            {
                neighbors.Add(new Node(new Point(n.X - 1, n.Y + 1)));
            }
            if (!grid.isWall(new Point(n.X, n.Y - 1)))
            {
                neighbors.Add(new Node(new Point(n.X, n.Y - 1)));
            }
            if (!grid.isWall(new Point(n.X, n.Y + 1)))
            {
                neighbors.Add(new Node(new Point(n.X, n.Y + 1)));
            }
            if (!grid.isWall(new Point(n.X + 1, n.Y - 1)))
            {
                neighbors.Add(new Node(new Point(n.X + 1, n.Y - 1)));
            }
            if (!grid.isWall(new Point(n.X + 1, n.Y)))
            {
                neighbors.Add(new Node(new Point(n.X + 1, n.Y)));
            }
            if (!grid.isWall(new Point(n.X + 1, n.Y + 1)))
            {
                neighbors.Add(new Node(new Point(n.X + 1, n.Y + 1)));
            }
            return neighbors;
        }
        private static float heuristicCostEstimate(Node start, Node goal)
        {
            return (float)Math.Sqrt((start.X - goal.X) * (start.X - goal.X) + (start.Y - goal.Y) * (start.Y - goal.Y));
        }
    }
}

