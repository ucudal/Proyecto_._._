using System;
using Library;

namespace Program.Tests
{
    // Clase de prueba para verificar el correcto funcionamiento de la clase Etiqueta
    public static class TestEtiqueta
    {
        // Método principal que ejecuta las pruebas de la clase Etiqueta
        public static void Run()
        {
            Console.WriteLine("== TestEtiqueta ==");

            // Se crea una nueva etiqueta con un nombre de ejemplo
            string nombreEsperado = "Importante";
            Etiqueta etiqueta = new Etiqueta(nombreEsperado);

            // Se verifica que el método ObtenerNombre devuelva el valor correcto
            string nombreObtenido = etiqueta.ObtenerNombre();

            if (nombreObtenido == nombreEsperado)
                Console.WriteLine("Constructor y ObtenerNombre funcionan correctamente.");
            else
                Console.WriteLine($"Error: se esperaba '{nombreEsperado}' y se obtuvo '{nombreObtenido}'.");

            // Línea vacía para mantener ordenada la salida en consola
            Console.WriteLine();
        }
    }
}