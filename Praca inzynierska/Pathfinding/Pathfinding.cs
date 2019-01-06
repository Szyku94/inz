using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_inzynierska.Pathfinding
{
    abstract class Pathfinding
    {
        abstract public List<Node> calculatePath(Point startP, Point goalP, Grid grid);
    }
}
