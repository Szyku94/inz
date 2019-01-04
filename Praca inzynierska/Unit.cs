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
        private bool debug_drawPaths = false;
        public float X { get; set; }
        public float Y { get; set; }
        public float radius { get; }
        private const int NUMBER_OF_POINTS = 24;
        private float speed;
        private Vector2 vector;
        private PointF destination;
        public PointF center;
        private bool moving;
        private bool selected;
        private List<PointF> path;
        public Unit(float x, float y, float radius)
        {
            this.radius = radius;
            speed = 0.01F;
            vector = new Vector2();
            moving = false;
            destination = new PointF();
            center.X = x;
            center.Y = y;
            selected = false;
            path = new List<PointF>();
        }
        public Unit(PointF point, float radius) : this(point.X, point.Y, radius) { }
        public PointF[] getPoints()
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
        public void move()
        {
            if (moving)
            {
                X += vector.X;
                Y += vector.Y;
                center.X += vector.X;
                center.Y += vector.Y;
                recalculateVector();
                if (center.X == destination.X && center.Y == destination.Y)
                {
                    path.RemoveAt(0);
                    if (path.Count > 0)
                    {
                        destination = path.ElementAt(0);
                    }
                    else
                    {
                        stop();
                    }
                }
            }
        }
        public void moveTo(PointF destination)
        {
            this.destination.X = destination.X;
            this.destination.Y = destination.Y;
            recalculateVector();
            moving = true;
        }
        public void moveTo(List<PointF> path)
        {
            if (path.Capacity > 0)
            {
                this.path = path;
                destination = path.ElementAt(0);
                recalculateVector();
                moving = true;
            }
        }
        private void recalculateVector()
        {
            vector.X = destination.X - center.X;
            vector.Y = destination.Y - center.Y;
            if (vector.Length >= speed)
                vector = Vector2.Multiply(vector, speed / vector.Length);
        }
        public void stop()
        {
            moving = false;
        }
        public void draw()
        {
            //bounds
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(Color.Red);
            GL.Vertex2(-1, -1);
            GL.Vertex2(1, -1);
            GL.Vertex2(1, 1);
            GL.Vertex2(-1, 1);

            GL.End();
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(1.0, 1.0, 1.0);
            PointF[] points = getPoints();
            foreach (PointF p in points)
            {
                GL.Vertex2(p.X, p.Y);
            }
            GL.End();
            if (selected)
            {
                GL.LineWidth(1.5f);

                GL.Begin(PrimitiveType.LineLoop);

                GL.Color3(Color.LimeGreen);
                foreach (PointF p in points)
                {
                    GL.Vertex2(p.X, p.Y);
                }
                GL.End();
            }
            if (debug_drawPaths)
            {
                GL.Begin(PrimitiveType.LineStrip);
                GL.Color3(Color.Pink);
                if (path.Capacity > 0)
                {
                    GL.Vertex2(center.X, center.Y);
                    foreach (PointF p in path)
                    {
                        GL.Vertex2(p.X, p.Y);
                    }
                }
                GL.End();
            }
        }
    }
}
