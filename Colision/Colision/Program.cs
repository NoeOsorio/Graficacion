using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
//using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics.OpenGL;

public class Figura
{
    public Figura()
    {
    }

    public void ventana()
    {

    }

    public static void Main()
    {
        Figura clase = new Figura();
        Ventana ventana = new Ventana(500, 500);
        ventana.Run();
    }
}

public class Ventana : GameWindow
{

    int xm, ym, r, v;
    Circle l1;

    public Ventana(int ancho, int alto) : base(ancho, alto)
    {
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        GL.LoadIdentity();
        GL.MatrixMode(MatrixMode.Projection);
        GL.Ortho(-500, 500, -500, 500, -1, 1);
        v = 1;
        xm = ym = 0;
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.Azure);

    }

    public bool DidCollide()
    {
        bool collision;
        if(xm >= 500 - r || xm <= -500 + r)
        {
            Console.WriteLine("Colision!");
            return collision = true;
        }
        collision = false;
        return collision;
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        Random rnd = new Random();

        /*for (int i = 0; i < 100; i++)
        {
            xm = rnd.Next(-500, 500);
            ym = rnd.Next(-500, 500);
            r = rnd.Next(-500, 500);
            Circle l1 = new Circle(xm, ym, r);
        }*/
        r = 50;
        l1 = new Circle(xm, ym, r);

        if (DidCollide())
        {
            v*=-1;

        }
        xm += 100 * v;

        l1.setX(xm);
        l1.draw();

        SwapBuffers();
    }
}
