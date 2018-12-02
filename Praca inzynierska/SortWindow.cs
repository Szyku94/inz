using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Threading;

namespace Praca_inzynierska
{
    class SortWindow:GameWindow
    {
        Bars bars;
        public SortWindow(int width, int height) : base(width, height, GraphicsMode.Default, "Sortowanie")
        {
            bars = new Bars(100);
            //bars.fewUnique(20);
            //bars.reverseSort();
            bars.random();
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Sort.Sort sort = new Sort.Bubble();
                sort.sort(bars);
            }).Start();
        }
        void drawBars()
        {
            GL.Begin(PrimitiveType.Quads);
            double barWidth = 2.0/bars.size;
            double barHight = 2.0 / bars.size;
            for (int i = 0; i < bars.size; i++)
            {
                GL.Color3(bars.getColor(i));
                GL.Vertex3(i* barWidth - 1, -1, 0);
                GL.Vertex3(i* barWidth + barWidth-1, -1, 0);
                GL.Vertex3(i * barWidth + barWidth-1, bars.getValue(i)* barHight-1, 0);
                GL.Vertex3(i * barWidth - 1, bars.getValue(i) * barHight-1, 0);
            }
            GL.End();
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.CornflowerBlue);
            drawBars();
            GL.Flush();
            this.SwapBuffers();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(ClientRectangle);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Enable(EnableCap.DepthTest);
        }
        /*public void swap(int a, int b)
        {
            bars.swap(a, b);
        }*/
    }
}
