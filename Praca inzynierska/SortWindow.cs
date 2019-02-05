using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Praca_inzynierska
{
    class SortWindow:GameWindow
    {
        Bars bars;
        Sort.Sort sort;
        KeyboardState keyboardState, lastKeyboardState;
        public SortWindow(int width, int height,int numberOfElements, Sort.Sort sort, int startingData, string title) : base(width, height, GraphicsMode.Default, title)
        {
            this.sort = sort;
            bars = new Bars(numberOfElements);
            switch(startingData)
            {
                case 0:
                    bars.random();
                    break;
                case 1:
                    bars.fewUnique(4);
                    break;
                case 2:
                    bars.reverseSort();
                    break;
                default:
                    bars.random();
                    break;
            }
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
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
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            keyboardState = OpenTK.Input.Keyboard.GetState();
            if (IsKeyPressed(Key.Escape))
            {
                Exit();
            }
            if (IsKeyPressed(Key.Space))
            {
                sort.changePause();
            }
            if (keyboardState[Key.S])
            {
                sort.nextStep();
            }
            lastKeyboardState = keyboardState;
        }
        public bool IsKeyPressed(Key key)
        {
            return (keyboardState[key] && (keyboardState[key] != lastKeyboardState[key]));
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            if(sort.isFinished())
            {
                MessageBox.Show("Porównania: " + sort.getComparisons()
                    + "\nIlość dostępów do tablicy: " + sort.getAccesses()
                    , "", MessageBoxButtons.OK);
                sort.setFinished(false);
            }
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
    }
}
