using System;
using System.Collections.Generic;
using Library;

namespace Program.Tests
{
    // Clase de prueba para verificar el correcto funcionamiento del registro de ventas
    public static class TestRegistroVenta
    {
        // Método principal que ejecuta las pruebas de la clase RegistroVenta
        public static void Run()
        {
            Console.WriteLine("== TestRegistroVenta ==");

            // Se crea una lista vacía de ventas que servirá como base de datos temporal
            List<Venta> listaVentas = new List<Venta>();

            // Se crea una instancia de RegistroVenta, pasándole la lista de ventas
            RegistroVenta registro = new RegistroVenta(listaVentas);

            // Se crean tres ventas con diferentes fechas
            Venta v1 = new Venta(1000, DateTime.Now.AddDays(-10)); // Venta de hace 10 días
            Venta v2 = new Venta(2000, DateTime.Now.AddDays(-5));  // Venta de hace 5 días
            Venta v3 = new Venta(3000, DateTime.Now);              // Venta de hoy

            // Se agregan las ventas a la lista general
            listaVentas.Add(v1);
            listaVentas.Add(v2);
            listaVentas.Add(v3);

            // Se definen las fechas de búsqueda: desde hace 7 días hasta hoy
            DateTime desde = DateTime.Now.AddDays(-7);
            DateTime hasta = DateTime.Now;

            // Se obtienen las ventas que ocurrieron dentro del rango de fechas indicado
            List<Venta> resultado = registro.getVentasEntre(desde, hasta);

            // Se verifica si el método getVentasEntre devolvió exactamente 2 ventas
            if (resultado.Count == 2)
                Console.WriteLine("getVentasEntre filtra correctamente por fechas.");
            else
                Console.WriteLine($"Error: se esperaban 2 ventas y se obtuvieron {resultado.Count}.");

            // Línea en blanco para separar la salida visualmente
            Console.WriteLine();
        }
    }
}