using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

class Poligono
    {
        public static void Main(string[] args)
        {
        Poligono pol = new Poligono();
        Ventana ventana = new Ventana(600, 500);
        ventana.Run();
        }
    }

public class Ventana : GameWindow
{
    public Ventana(int ancho, int alto) : base (ancho, alto)
    {

    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color.CornflowerBlue);
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        //makePoly(5);
        GL.Begin(PrimitiveType.Triangles);
        //for (int i = 0; i < 4; i++)
        //{
        GL.Vertex3(-1.0f, -1.0f, 4.0f);
        GL.Vertex3(1.0f, -1.0f, 4.0f);

        GL.Vertex3(0.0f, 1.0f, 4.0f);

        //}
        GL.End();
        SwapBuffers();
    }
    public void makePoly(int num)
    {
        int x = 100, y = 100;
        //GL.Color4(Color.BlanchedAlmond);
        GL.Begin(PrimitiveType.Points);
        for(int i = 0; i < num; i++)
        {
            GL.Vertex2(x + 50, y + 50);
        }
        GL.End();
    }
}
