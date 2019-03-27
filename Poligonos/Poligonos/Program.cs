using System;

namespace Poligonos
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
