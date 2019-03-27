using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace Canvas
{
    public class VentanaGame : GameWindow
    {
        public VentanaGame(int ancho, int alto) : base(ancho, alto, GraphicsMode.Default, "My jueguito")
        {
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.White);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            poligono(3, 0.5f, Color.Azure);
            //drawLines();
            SwapBuffers();
        }
        protected override void OnResize(EventArgs e)
        {
            //GL.Viewport(0, 0, Width, Height);
        }
        public void poligono(int vertices, float size, Color4 color)
        {
            double x, y, h = 0.1f, k = 0.2f;
            double theta = 0.0;

            double step = (2 * Math.PI / vertices);


            GL.Color4(color);

            GL.Begin(PrimitiveType.Polygon);
           for (int i = 0; i < vertices; i++)
            {
                x = (h + size * Math.Cos(theta));
                y = (k + size * Math.Sin(theta));

                GL.Vertex2(x, y);

                theta += step;
            }
            GL.End();

        }

        public void drawLines()
        {
            float x, y;

            GL.Begin(PrimitiveType.Points);
            for (x = 0; x <= 1; x+=0.0001f)
            {
                y = 2 * x / 3;

                GL.Color4(Color.Blue);
                GL.Vertex2(x, y);
                y = 9 * x + 0.5f ;
                GL.Color4(Color.Red);
                GL.Vertex2(x, y);
                y = -2 * x / 3;
                GL.Color4(Color.Green);
                GL.Vertex2(x, y);
                y = -6 * x / 7;
                GL.Color4(Color.Yellow);
                GL.Vertex2(x, y);
                y = 12*x*9;
                GL.Color4(Color.Black);
                GL.Vertex2(x, y);

            }
            GL.End();


        }


    }
}
