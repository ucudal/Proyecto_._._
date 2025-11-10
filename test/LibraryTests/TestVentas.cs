using System;
using Library;

namespace Program.Tests
{
    // Clase de prueba para comprobar el correcto funcionamiento de la clase Venta
    public static class TestVentas
    {
        // Método principal que ejecuta las pruebas de la clase Venta
        public static void Run()
        {
            Console.WriteLine("== TestVentas ==");

            // Se define un valor total y una fecha de ejemplo para la venta
            double total = 1500.50;
            DateTime fecha = DateTime.Now.AddDays(-3); // Venta realizada hace 3 días

            // Se crea una nueva venta con los valores definidos
            Venta venta = new Venta(total, fecha);

            // Se verifica que los valores del constructor se hayan asignado correctamente
            if (venta.Total == total && venta.Fecha == fecha)
                Console.WriteLine("Constructor y propiedades funcionan correctamente.");
            else
                Console.WriteLine("Error en la inicialización de Venta.");

            // Se prueba el método getTotales con criterios ficticios
            double resultado = venta.getTotales("criterio1", "criterio2");

            // Se verifica si el método devuelve el valor esperado
            Console.WriteLine(resultado == total 
                ? "getTotales devuelve el total correctamente." 
                : "Error en getTotales.");

            // Línea vacía para mantener ordenada la salida en consola
            Console.WriteLine();
        }
    }
}