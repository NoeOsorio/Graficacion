using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
//using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics.OpenGL;

    public class Circle
    {
        int xm, ym, r;

        public Circle(int xm, int ym, int r)
        {
            this.xm = xm;
            this.ym = ym;
            this.r = r;
        }

        public void setX(int xm)
        {
            this.xm = xm;
        }

    public void draw()
        {
            int x = -r, y = 0, err = 2 - 2 * r;
            GL.Begin(PrimitiveType.Polygon);
            do
            {
                GL.Vertex2(xm - x, ym + y);
                GL.Vertex2(xm - y, ym - x);
                GL.Vertex2(xm + x, ym - y);
                GL.Vertex2(xm + y, ym + x);

                r = err;
                if (r <= y)
                {
                    err += ++y * 2 + 1;
                }
                if (r > x || err > y)
                {
                    err += ++x * 2 + 1;
                }
            } while (x < 0);

            GL.Color3(Color.HotPink);
            GL.End();
        }
}