using System;
using Library;

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba para verificar el correcto funcionamiento de la clase <see cref="Etiqueta"/>.
    /// Contiene pruebas sobre la creación de etiquetas y la obtención de su nombre.
    /// </summary>
    public static class TestEtiqueta
    {
        /// <summary>
        /// Ejecuta todas las pruebas de la clase <see cref="Etiqueta"/>.
        /// Valida el constructor y el método <see cref="Etiqueta.ObtenerNombre"/>.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("== TestEtiqueta ==");

            // Crear una nueva etiqueta con nombre de ejemplo
            string nombreEsperado = "Importante";
            Etiqueta etiqueta = new Etiqueta(nombreEsperado);

            // Verificar que ObtenerNombre devuelva el valor correcto
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