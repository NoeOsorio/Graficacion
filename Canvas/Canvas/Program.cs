using System;

namespace Canvas
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            VentanaGame ventana = new VentanaGame(600, 500);
            ventana.Run();
        }
    }
}
