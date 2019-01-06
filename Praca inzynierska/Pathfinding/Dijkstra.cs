﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_inzynierska.Pathfinding
{
    class Dijkstra : Pathfinding
    {
        override public List<Node> calculatePath(Point startP, Point goalP, Grid grid)
        {
            Node start = new Node(startP);
            grid.setVisited(startP);
            Node goal = new Node(goalP);
            HashSet<Node> closed = new HashSet<Node>();
            HashSet<Node> open = new HashSet<Node>();
            open.Add(start);
            var cameFrom = new Dictionary<Node, Node>();
            var d = new Dictionary<Node, float>();
            d[start] = 0;
            while (open.Count > 0)
            {
                Node min = open.ElementAt(0);
                foreach (Node n in open)
                {
                    if (d[min] > d[n])
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
                foreach (Node neighbor in getNeighbors(current, grid))
                {
                    if (closed.Contains(neighbor))
                    {
                        continue;
                    }
                    if (!open.Contains(neighbor))
                    {
                        grid.setOpen(neighbor.point);
                        open.Add(neighbor);
                        d[neighbor] = float.PositiveInfinity;
                    }
                    float tentative_gScore = d[current] + 1;
                    if (tentative_gScore >= d[neighbor])
                    {
                        continue;
                    }
                    cameFrom[neighbor] = current;
                    d[neighbor] = tentative_gScore;
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
        private float heuristicCostEstimate(Node start, Node goal)
        {
            return (float)Math.Sqrt((start.X - goal.X) * (start.X - goal.X) + (start.Y - goal.Y) * (start.Y - goal.Y));
        }
    }
}

