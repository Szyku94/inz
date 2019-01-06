using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Praca_inzynierska
{
    class Unit
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float radius { get; }
        private const int NUMBER_OF_POINTS = 24;
        public PointF center;
        private List<PointF> path;
        public Unit(float x, float y, float radius)
        {
            this.radius = radius;
            center.X = x;
            center.Y = y;
            path = new List<PointF>();
        }
        public Unit(PointF point, float radius) : this(point.X, point.Y, radius) { }
        private PointF[] getPoints()
        {
            float angle = 0;
            PointF[] points = new PointF[NUMBER_OF_POINTS];
            for (int i = 0; i < NUMBER_OF_POINTS; i++)
            {
                points[i] = new PointF(center.X + radius * (float)Math.Cos(angle), center.Y + radius * (float)Math.Sin(angle));
                angle += 2 * (float)Math.PI / NUMBER_OF_POINTS;
            }
            return points;
        }
        public void draw()
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(1.0, 1.0, 1.0);
            PointF[] points = getPoints();
            foreach (PointF p in points)
            {
                GL.Vertex2(p.X, p.Y);
            }
            GL.End();
        }
    }
}
