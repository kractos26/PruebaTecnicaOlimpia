using System;
using Utilidad.Matematicas;

namespace CircunferenciaSecante
{
    class Program
    {
        static void Main(string[] args)
        {
            Circulo circuloa = new Circulo();
            Circulo circulob = new Circulo();

            Circunferencia circunferencia = new Circunferencia();
            Console.WriteLine("--Calcular si dos circunferncias se crusan");
            Console.WriteLine("Ingrese el valor en X para la primer circunferencia");
            circuloa.CordenadaX = Console.Read();
            Console.WriteLine("Ingrese el valor en Y para la primer circunferencia");
            circuloa.CordenadaY = Console.Read();

            Console.WriteLine("Ingrese el valor en X para la segunda circunferencia");
            circuloa.CordenadaX = Console.Read();
            Console.WriteLine("Ingrese el valor en Y para la segunda circunferencia");
            circulob.CordenadaY = Console.Read();

            if (circunferencia.IsSecantes(circuloa, circulob))
            {
                Console.WriteLine("Los circulos son secantes");
            }
        }
    }
}
