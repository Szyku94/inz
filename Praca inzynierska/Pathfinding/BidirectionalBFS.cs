using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_inzynierska.Pathfinding
{
    class BidirectionalBFS : Pathfinding
    {
        override public List<Node> calculatePath(Point startP, Point goalP, Grid grid)
        {
            Node start = new Node(startP);
            grid.setVisited(startP);
            Node goal = new Node(goalP);
            List<Node> closedS = new List<Node>();
            List<Node> openS = new List<Node>();
            List<Node> closedG = new List<Node>();
            List<Node> openG = new List<Node>();
            openS.Add(start);
            openG.Add(goal);
            var cameFromS = new Dictionary<Node, Node>();
            var cameFromG = new Dictionary<Node, Node>();
            List<Node> path;
            while (openS.Count > 0&& openG.Count > 0)
            {
                Node current = openS.ElementAt(0);
                if (openG.Contains(current))
                {
                    path = reconstructPath(cameFromS, current, grid);
                    foreach (Node n in reconstructPath(cameFromG, current, grid))
                    {
                        path.Insert(path.Count - 1, n);
                    }
                    grid.setPath(current.point);
                    path.Add(goal);
                    return path;
                }
                openS.Remove(current);
                grid.setVisited(current.point);
                closedS.Add(current);
                foreach (Node neighbor in getNeighbors(current, grid))
                {
                    if (closedS.Contains(neighbor))
                    {
                        continue;
                    }
                    if (!openS.Contains(neighbor))
                    {
                        grid.setOpen(neighbor.point);
                        openS.Add(neighbor);
                    }
                    cameFromS[neighbor] = current;
                }
                current = openG.ElementAt(0);
                if (openS.Contains(current))
                {
                    path = reconstructPath(cameFromS, current, grid);
                    foreach (Node n in reconstructPath(cameFromG, current, grid))
                    {
                        path.Insert(path.Count - 1, n);
                    }
                    grid.setPath(current.point);
                    path.Add(goal);
                    return path;
                }
                openG.Remove(current);
                grid.setVisited(current.point);
                closedG.Add(current);
                foreach (Node neighbor in getNeighbors(current, grid))
                {
                    if (closedG.Contains(neighbor))
                    {
                        continue;
                    }
                    if (!openG.Contains(neighbor))
                    {
                        grid.setOpen(neighbor.point);
                        openG.Add(neighbor);
                    }
                    cameFromG[neighbor] = current;
                }
            }
            return null;
        }
        private List<Node> reconstructPath(Dictionary<Node, Node> cameFrom, Node current, Grid grid)
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
        private HashSet<Node> getNeighbors(Node n, Grid grid)
        {
            HashSet<Node> neighbors = new HashSet<Node>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == j || i + j == 0)
                    {
                        continue;
                    }
                    if (n.X + i >= 0 && n.Y + j >= 0 && n.X + i < grid.width && n.Y + j < grid.height
                        && !grid.isWall(new Point(n.X + i, n.Y + j)))
                    {
                        neighbors.Add(new Node(new Point(n.X + i, n.Y + j)));
                    }
                }
            }
            return neighbors;
        }
    }
}

