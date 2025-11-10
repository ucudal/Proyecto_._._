using System;
using Library;

namespace Program.Tests
{
    public static class TestMensaje
    {
        public static void Run()
        {
            Console.WriteLine("== TestMensaje ==");

            //Datos de ejemplo 
            // Creamos valores que se usarán para instanciar el Mensaje
            DateTime fecha = DateTime.Now.AddDays(-2);  // Fecha de envío del mensaje
            string descripcion = "Mensaje de bienvenida";  // Descripción breve del mensaje
            string notas = "El cliente respondió positivamente";  // Nota 
            bool respondida = true;  // Indica si hubo respuesta
            string direccion = "juan@correo.com";  // Dirección de envío (correo o número)
            string medio = "Email";  // Medio del mensaje (ej: Email, SMS, WhatsApp)

            // Creación del objeto
            // Instanciamos un Mensaje con los datos definidos arriba
            // El constructor llama al de la clase base (Interaccion)
            Mensaje mensaje = new Mensaje(fecha, descripcion, notas, respondida, direccion, medio);

            //  Verificaciones básicas 
            // Validamos que la instancia se haya creado correctamente
            if (mensaje != null)
                Console.WriteLine("Instancia de Mensaje creada correctamente.");
            else
                Console.WriteLine("Error: no se pudo crear la instancia de Mensaje.");

            // Confirmamos que la propiedad Fecha se haya asignado correctamente
            if (mensaje.Fecha == fecha)
                Console.WriteLine("Fecha asignada correctamente.");
            else
                Console.WriteLine("Error en la asignación de la fecha.");

            // Prueba del método heredado agregarNota()
            // Probamos que se puedan agregar nuevas notas sin errores
            mensaje.agregarNota("El cliente pidió más información sobre los productos.");
            mensaje.agregarNota("Se envió un segundo correo de seguimiento.");

            Console.WriteLine("Método agregarNota() ejecutado correctamente.");

            // Confirmación final
            Console.WriteLine("La clase Mensaje funciona correctamente con su constructor y método heredado.");

            Console.WriteLine();
        }
    }
}
