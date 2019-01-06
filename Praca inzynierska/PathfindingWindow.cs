using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Praca_inzynierska.Pathfinding;
using System.Threading;

namespace Praca_inzynierska
{
    class PathfindingWindow : GameWindow
    {
        Unit unit;
        float scale;
        float transX;
        float transY;
        Grid grid;
        public PathfindingWindow(int width, int height) : base(width, height, GraphicsMode.Default, "Pathfinding")
        {
            grid = new Grid(50, 50);
            unit = new Unit(grid.cellWidth / 2, grid.cellWidth / 2, grid.cellWidth / 2);
            scale = 1;
            transX = 0;
            transY = 0;
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            var keyboard = OpenTK.Input.Keyboard.GetState();
            var mouse = Mouse.GetState();
            float mouseX = Mouse.X * 2.0F / Width - 1;
            float mouseY = -1 * (Mouse.Y * 2.0F / Height - 1);
            Point gridMousePosition = grid.convert(transform(new PointF(mouseX, mouseY)));
            PointF transformedMousePosition = grid.convert(gridMousePosition);
            if (keyboard[OpenTK.Input.Key.Escape])
            {
                Exit();
            }
            if (keyboard[OpenTK.Input.Key.Space])
            {
                grid.clearPaths();
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Pathfinding.Pathfinding pathfinding = new AStar();
                    pathfinding.calculatePath(grid.convert(unit.center), gridMousePosition, grid);
                }).Start();
                
            }
            if (mouse[OpenTK.Input.MouseButton.Left])
            {
                grid.clearPaths();
                grid.setWall(new PointF(transformedMousePosition.X, transformedMousePosition.Y));
            }
            if (mouse[OpenTK.Input.MouseButton.Right])
            {
                grid.clearPaths();
                grid.unsetWall(new PointF(transformedMousePosition.X, transformedMousePosition.Y));
            }
            if (keyboard[OpenTK.Input.Key.C])
            {
                grid.clearPaths();
                unit = new Unit(new PointF(transformedMousePosition.X, transformedMousePosition.Y), grid.cellWidth / 2);
            }
            if (keyboard[OpenTK.Input.Key.X])
            {
                scale *= 1.1f;
                transform();
            }
            if (keyboard[OpenTK.Input.Key.Z])
            {
                if (scale * 0.9f >= 1)
                {
                    scale *= 0.9f;
                }
                else
                {
                    scale = 1;
                }
                transform();
            }
            if (keyboard[OpenTK.Input.Key.A])
            {
                if ((1 - transX) * scale >= 1f)
                {
                    transX += 0.01f / scale;
                }
                transform();
            }
            if (keyboard[OpenTK.Input.Key.D])
            {
                if ((1 + transX) * scale >= 1f)
                {
                    transX -= 0.01f / scale;
                }
                transform();
            }
            if (keyboard[OpenTK.Input.Key.W])
            {
                if ((1 + transY) * scale >= 1f)
                {
                    transY -= 0.01f / scale;
                }
                transform();
            }
            if (keyboard[OpenTK.Input.Key.S])
            {
                if ((1 - transY) * scale >= 1f)
                {
                    transY += 0.01f / scale;
                }
                transform();
            }
        }
        void draw()
        {
            grid.draw();
            unit.draw();
            GL.Flush();
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.CornflowerBlue);
            draw();
            SwapBuffers();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(ClientRectangle);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Frustum(-1, 1, -1, 1, 0, 0);

        }
        private PointF transform(PointF point)
        {
            point.X = point.X / scale - transX;
            point.Y = point.Y / scale - transY;
            return point;
        }
        private void transform()
        {
            GL.LoadIdentity();
            GL.Scale(scale, scale, 1);
            GL.Translate(transX, transY, 0);
        }
    }
}