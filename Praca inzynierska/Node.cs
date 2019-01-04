using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_inzynierska
{
    class Node
    {
        public int X { get { return point.X; } }
        public int Y { get { return point.Y; } }
        public Point point { get; }
        public bool wall { get; }
        public Node(Point point)
        {
            this.point = point;
            wall = false;
        }
        public override bool Equals(object obj)
        {
            if (X == ((Node)obj).X && Y == ((Node)obj).Y)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return X * 13 + Y;
        }
    }
}

