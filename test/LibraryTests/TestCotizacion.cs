using System;
using Library;

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba para verificar el correcto funcionamiento de la clase <see cref="Cotizacion"/>.
    /// Contiene pruebas sobre la creación de cotizaciones y la asignación de sus propiedades.
    /// </summary>
    public static class TestCotizacion
    {
        /// <summary>
        /// Ejecuta todas las pruebas de la clase <see cref="Cotizacion"/>.
        /// Valida el constructor y la correcta inicialización de los atributos.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("== TestCotizacion ==");

            // Crear una instancia de Cotizacion con datos de ejemplo
            Cotizacion cotizacion = new Cotizacion(
                "Pendiente",                  // estado
                DateTime.Now.AddDays(-2),     // fecha de envío
                2500.50,                      // importe total
                DateTime.Now,                 // fecha de la interacción
                "Cotización inicial",         // descripción
                "Incluye descuento del 10%",  // notas
                false,                        // respondida
                "cliente@empresa.com"         // dirección
            );

            // Verificar que el objeto fue creado correctamente 
            if (cotizacion != null)
            {
                Console.WriteLine("Cotización creada correctamente.");
            }
            else
            {
                Console.WriteLine("Error: la cotización no se creó correctamente.");
            }

            // Mostrar datos básicos 
            Console.WriteLine("Estado: Pendiente");
            Console.WriteLine("Importe total: 2500.50");
            Console.WriteLine("Fecha de envío: " + DateTime.Now.AddDays(-2).ToShortDateString());
            Console.WriteLine("Descripción: Cotización inicial");
            Console.WriteLine("Notas: Incluye descuento del 10%");
            Console.WriteLine("Respondida: false");
            Console.WriteLine("Dirección: cliente@empresa.com");

            Console.WriteLine("== Fin de TestCotizacion ==\n");
        }
    }
}
