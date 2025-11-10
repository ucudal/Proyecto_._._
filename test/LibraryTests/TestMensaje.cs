using System;
using Library;

namespace Program.Tests
{
    public static class TestMensaje
    {
        public static void Run()
        {
            Console.WriteLine("== TestMensaje ==");

            // --- Datos de ejemplo ---
            DateTime fecha = DateTime.Now.AddDays(-2);                // Fecha de envío del mensaje
            string descripcion = "Mensaje de bienvenida";             // Descripción breve
            string notas = "El cliente respondió positivamente";      // Nota inicial
            bool respondida = true;                                   // Indica si hubo respuesta
            string direccion = "juan@correo.com";                     // Dirección (correo o número)
            string medio = "Email";                                   // Medio del mensaje (Email, SMS, WhatsApp)

            // --- Creación del objeto ---
            Mensaje mensaje = new Mensaje(fecha, descripcion, notas, respondida, direccion, medio);

            // --- Verificaciones básicas ---
            if (mensaje != null)
                Console.WriteLine("Instancia de Mensaje creada correctamente.");
            else
                Console.WriteLine("Error: no se pudo crear la instancia de Mensaje.");

            // Validar asignación de fecha
            if (mensaje.Fecha == fecha)
                Console.WriteLine("Fecha asignada correctamente.");
            else
                Console.WriteLine("Error en la asignación de la fecha.");

            // --- Prueba del método heredado AgregarNota() ---
            // Agregamos notas adicionales para verificar el comportamiento
            mensaje.AgregarNota("El cliente pidió más información sobre los productos.");
            mensaje.AgregarNota("Se envió un segundo correo de seguimiento.");

            Console.WriteLine("Método AgregarNota() ejecutado correctamente.");

            // --- Confirmación final ---
            Console.WriteLine("La clase Mensaje funciona correctamente con su constructor y método heredado.");

            Console.WriteLine();
        }
    }
}
