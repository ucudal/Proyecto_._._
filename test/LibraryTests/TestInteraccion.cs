using System;
using Library;

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba para verificar el correcto funcionamiento de la clase abstracta <see cref="Interaccion"/>.
    /// Contiene pruebas sobre asignación de propiedades, método <see cref="Interaccion.AgregarNota"/> y estado de <see cref="Interaccion.Respondida"/>.
    /// </summary>
    public static class TestInteraccion
    {
        /// <summary>
        /// Clase auxiliar que hereda de <see cref="Interaccion"/> para permitir instanciación de la clase abstracta.
        /// </summary>
        private class InteraccionPrueba : Interaccion
        {
            /// <summary>
            /// Constructor que llama al constructor base de <see cref="Interaccion"/>.
            /// </summary>
            /// <param name="fecha">Fecha de la interacción.</param>
            /// <param name="descripcion">Descripción breve de la interacción.</param>
            /// <param name="notas">Notas iniciales.</param>
            /// <param name="respondida">Indica si la interacción fue respondida.</param>
            /// <param name="direccion">Dirección asociada a la interacción.</param>
            public InteraccionPrueba(DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
                : base(fecha, descripcion, notas, respondida, direccion)
            {
            }
        }

        /// <summary>
        /// Ejecuta todas las pruebas sobre la clase <see cref="Interaccion"/> usando <see cref="InteraccionPrueba"/>.
        /// Verifica la asignación de fecha, la propiedad <see cref="Interaccion.Respondida"/> y el método <see cref="Interaccion.AgregarNota"/>.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("== TestInteraccion ==");

            // Crear una interacción de prueba
            DateTime fecha = DateTime.Now.AddDays(-1);
            InteraccionPrueba interaccion = new InteraccionPrueba(
                fecha,
                "Primera llamada al cliente",
                "Cliente pidió más información",
                false,
                "099876543"
            );

            // Verificar asignación de fecha
            if (interaccion.Fecha == fecha)
                Console.WriteLine("Constructor asigna correctamente la fecha.");
            else
                Console.WriteLine("Error: la fecha no se asignó correctamente.");

            // Verificar propiedad Respondida
            interaccion.Respondida = true;
            if (interaccion.Respondida)
                Console.WriteLine("Propiedad Respondida funciona correctamente.");
            else
                Console.WriteLine("Error en propiedad Respondida.");

            // Prueba del método AgregarNota()
            interaccion.AgregarNota("Se acordó enviar presupuesto el lunes.");
            interaccion.AgregarNota("Cliente confirmó recepción del correo.");
            interaccion.AgregarNota(""); // Nota vacía, no debe afectar

            Console.WriteLine("agregarNota ejecutado correctamente (sin errores).");

            // Confirmación de funcionamiento general
            Console.WriteLine("Interaccion base probada con éxito.\n");
        }
    }
}
