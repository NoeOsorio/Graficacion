using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

public class VentanaGame : GameWindow
   {
    public static int paso = 0;
    public Poligono casa;
    public VentanaGame(int ancho, int alto) : base(ancho, alto, GraphicsMode.Default, "My jueguito")
    {
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color.White);


        for (double i = 0; i < 0.5; i+=0.0001)
        {
            casa.mover(i, i, 1);
        }
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        //poligono(3, 0.5f, Color.Azure);
         casa = new Poligono(4, Color.Black, 0, 0);
        /////Pi/4 es la medida para ponerlo derecho
        casa.draw(0.5f, Math.PI/4);
        //casa.getMatrix();


        //drawStar();


        SwapBuffers();
    }
    public void drawStar()
    {
        double arriba = Math.PI / 2;
        double derecha = 0;
        double izquierda = Math.PI;
        double abajo = 3 * (Math.PI / 2);

        Poligono p1, p2, p3, p4, p5, centro;

        centro = p1 = new Poligono(5, Color.Yellow, 0, 0);
        p1.draw(0.2f, abajo);

        
        p1 = new Poligono(3, Color.Yellow, 0, 0.25);
        p1.draw(0.13f, arriba);
        //p1.getMatrix();

        p2 = new Poligono(3, Color.Yellow, 0.235, 0.08);
        p2.draw(0.13f, Math.PI / 10 );
        //p2.getMatrix();

        p3 = new Poligono(3, Color.Yellow, -0.235, 0.08);
        p3.draw(0.13f, 2*Math.PI / 9);
        //p3.getMatrix();

        p4 = new Poligono(3, Color.Yellow, 0.15, -0.20);
        p4.draw(0.13f, 3*Math.PI / 8);
        //p4.getMatrix();

        p5 = new Poligono(3, Color.Yellow, -0.15, -0.2);
        p5.draw(0.13f, 3.05*Math.PI / 5);
        //p1.getMatrix();


    }
}


public class Poligono
{
    int vertices;
    float size;
    Color color;
    double x, y, h, k;
    double initH, initK;
    double theta;
    double[,] matrix = new double[20,2];

    public Poligono(int vertices, Color color, double centroH, double centroK)
    {
        this.vertices = vertices;
        this.color = color;
        this.h = centroH;
        this.k = centroK;
        for (int i = 0; i < matrix.Length/2 - 1; i++)
        {
            matrix[i, 0] = 0;
            matrix[i, 1] = 0;
        }
    }

    public void draw(float size, double theta)
    {
        this.size = size;
        this.theta = theta;

        double step = (2 * Math.PI / vertices);
        //double step = (2 * 90 / vertices);
        Console.WriteLine(step);


        GL.Color4(color);

        GL.Begin(PrimitiveType.Polygon);
        for (int i = 0; i < vertices; i++)
        {
            x = h + (size * Math.Cos(theta));
            y = k + (size * Math.Sin(theta));

            matrix[i, 0] = x;
            matrix[i, 1] = y;

            GL.Vertex2(x, y);

            theta += step;
        }
        GL.End();

    }

    public void mover(double x, double y, float speed) {

        this.initH = this.h;
        this.initK = this.k;

        while (this.h <= x && this.k <= y)
        {
            this.h++;
            this.k++;
            this.draw(this.size, this.theta);
        }

    }

    public void mover()
    {

            this.h++;
            this.k++;
            this.draw(this.size, this.theta);

    }

    public void getMatrix()
    {
       for (int i = 0; i< matrix.Length / 2; i++)
        {
            Console.WriteLine(this.matrix[i,0] + "," + this.matrix[i,1] + "\n");
        }
    }

}


