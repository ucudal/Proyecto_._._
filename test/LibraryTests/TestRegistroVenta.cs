using System;
using System.Collections.Generic;
using Library;

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba unitaria para verificar el correcto funcionamiento de la clase <see cref="RegistroVenta"/>.
    /// Permite comprobar la creación de ventas y la filtración por fechas mediante <see cref="RegistroVenta.getVentasEntre"/>.
    /// </summary>
    public static class TestRegistroVenta
    {
        /// <summary>
        /// Ejecuta las pruebas de la clase <see cref="RegistroVenta"/>, creando ventas de ejemplo y validando
        /// que el método <see cref="RegistroVenta.getVentasEntre"/> filtre correctamente por rango de fechas.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("== TestRegistroVenta ==");

            // Lista simulada de ventas (como base de datos temporal)
            List<Venta> listaVentas = new List<Venta>();

            // Instancia de RegistroVenta con la lista creada
            RegistroVenta registro = new RegistroVenta(listaVentas);

            // Se crean tres ventas con todos los parámetros requeridos
            Venta v1 = new Venta(1000, DateTime.Now.AddDays(-10), "Venta antigua", "sin notas", true, "Sucursal A");
            Venta v2 = new Venta(2000, DateTime.Now.AddDays(-5), "Venta intermedia", "ninguna", true, "Sucursal B");
            Venta v3 = new Venta(3000, DateTime.Now, "Venta reciente", "ninguna", true, "Sucursal C");

            // Se agregan las ventas a la lista general
            listaVentas.Add(v1);
            listaVentas.Add(v2);
            listaVentas.Add(v3);

            // Definimos el rango de fechas de búsqueda
            DateTime desde = DateTime.Now.AddDays(-7);
            DateTime hasta = DateTime.Now;

            // Se obtienen las ventas entre esas fechas
            List<Venta> resultado = registro.getVentasEntre(desde, hasta);

            // Verificamos si se filtraron correctamente (esperamos 2 ventas)
            if (resultado.Count == 2)
                Console.WriteLine("GetVentasEntre filtra correctamente por fechas.");
            else
                Console.WriteLine($"Error: se esperaban 2 ventas y se obtuvieron {resultado.Count}.");

            Console.WriteLine();
        }
    }
}
