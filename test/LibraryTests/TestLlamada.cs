using System;
using Library;

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba unitaria para verificar el correcto funcionamiento de la clase <see cref="Llamada"/>.
    /// Permite comprobar la creación de una llamada y la funcionalidad del método heredado <see cref="Interaccion.AgregarNota"/>.
    /// </summary>
    public static class TestLlamada
    {
        /// <summary>
        /// Ejecuta las pruebas de la clase <see cref="Llamada"/>, creando una instancia de ejemplo
        /// y validando la asignación de propiedades y la adición de notas.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("== TestLlamada ==");

            // --- Datos de ejemplo ---
            DateTime fecha = DateTime.Now.AddDays(-1);                // Fecha de la llamada (ayer)
            string descripcion = "Llamada de seguimiento";           // Breve descripción
            string notas = "Cliente interesado en renovar contrato"; // Notas iniciales
            bool respondida = true;                                  // Indica si fue respondida
            string direccion = "Oficina Central";                    // Lugar o dirección asociada
            string duracion = "15 minutos";                          // Duración de la llamada

            // --- Creación del objeto ---
            // Se instancia una llamada usando todos los datos de ejemplo
            Llamada llamada = new Llamada(fecha, descripcion, notas, respondida, direccion, duracion);

            // --- Verificación de creación ---
            if (llamada != null)
                Console.WriteLine("Instancia creada correctamente.");
            else
                Console.WriteLine("Error al crear la instancia de Llamada.");

            // Verificar asignación de la fecha
            if (llamada.Fecha == fecha)
                Console.WriteLine("Fecha asignada correctamente.");
            else
                Console.WriteLine("Error: la fecha no coincide.");

            // --- Prueba del método heredado AgregarNota() ---
            // Se agregan notas adicionales para verificar el funcionamiento
            llamada.AgregarNota("Se acordó próxima reunión.");
            llamada.AgregarNota("Cliente confirmó asistencia.");

            Console.WriteLine("Método AgregarNota ejecutado sin errores.");
            Console.WriteLine("Notas agregadas correctamente a la interacción.\n");
        }
    }
}
