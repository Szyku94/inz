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
    class Grid
    {
        public enum Cell { Wall,Empty,Visited,Path}
        public int width { get; }
        public int height { get; }
        public float cellWidth { get; }
        public float cellHeight { get; }
        public Cell[,] cells { get; }
        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            cellWidth = 2F / width;
            cellHeight = 2F / height;
            cells = new Cell[width,height];
            clear();
        }
        public Point convert(PointF point)
        {
            return new Point(Convert.ToInt32(Math.Floor((point.X + 1) / cellWidth)), Convert.ToInt32(Math.Floor((point.Y + 1) / cellHeight)));
        }
        public PointF convert(Point point)
        {
            return new PointF(point.X * cellWidth - 1 + cellWidth / 2, point.Y * cellHeight - 1 + cellHeight / 2);
        }
        public void setWall(PointF point)
        {
            int x = convert(point).X;
            int y = convert(point).Y;
            cells[x,y]=Cell.Wall;
        }
        public void unsetWall(PointF point)
        {
            int x = convert(point).X;
            int y = convert(point).Y;
            cells[x, y] = Cell.Empty;
        }
        public void draw()
        {
            GL.Begin(PrimitiveType.Quads);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if(cells[i,j]==Cell.Wall)
                    {
                        GL.Color3(Color.Black);
                        GL.Vertex2((float)i / width * 2F - 1F, (float)j / height * 2F - 1F);
                        GL.Vertex2((i + 1F) / width * 2F - 1F, (float)j / height * 2F - 1F);
                        GL.Vertex2((i + 1F) / width * 2F - 1F, (j + 1F) / height * 2F - 1F);
                        GL.Vertex2((float)i / width * 2F - 1F, (j + 1F) / height * 2F - 1F);
                    }
                    else if (cells[i, j] == Cell.Visited)
                    {
                        GL.Color3(Color.Blue);
                        GL.Vertex2((float)i / width * 2F - 1F, (float)j / height * 2F - 1F);
                        GL.Vertex2((i + 1F) / width * 2F - 1F, (float)j / height * 2F - 1F);
                        GL.Vertex2((i + 1F) / width * 2F - 1F, (j + 1F) / height * 2F - 1F);
                        GL.Vertex2((float)i / width * 2F - 1F, (j + 1F) / height * 2F - 1F);
                    }
                    else if (cells[i, j] == Cell.Path)
                    {
                        GL.Color3(Color.Green);
                        GL.Vertex2((float)i / width * 2F - 1F, (float)j / height * 2F - 1F);
                        GL.Vertex2((i + 1F) / width * 2F - 1F, (float)j / height * 2F - 1F);
                        GL.Vertex2((i + 1F) / width * 2F - 1F, (j + 1F) / height * 2F - 1F);
                        GL.Vertex2((float)i / width * 2F - 1F, (j + 1F) / height * 2F - 1F);
                    }
                }
            }
            GL.End();
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            for (float i = -1; i < 1; i += 2F / width)
            {
                GL.Vertex2(i, -1);
                GL.Vertex2(i, 1);
                for (float j = -1; j < 1; j += 2F / height)
                {
                    GL.Vertex2(-1, j);
                    GL.Vertex2(1, j);
                }
            }
            GL.End();
        }
        public bool isWall(Point point)
        {
            return cells[point.X, point.Y] == Cell.Wall;
        }
        public void setVisited(Point point)
        {
            cells[point.X, point.Y] = Cell.Visited;
        }
        public void setPath(Point point)
        {
            cells[point.X, point.Y] = Cell.Path;
        }
        public void clear()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    cells[i, j] = Cell.Empty;
                }
            }
        }
        public void clearPaths()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if(cells[i, j] != Cell.Wall)
                        cells[i, j] = Cell.Empty;
                }
            }
        }
    }
}
