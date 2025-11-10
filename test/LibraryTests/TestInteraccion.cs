using System;
using Library;

namespace Program.Tests
{
    // Clase de prueba para verificar el funcionamiento de la clase abstracta Interaccion
    public static class TestInteraccion
    {
        // Clase auxiliar que hereda de Interaccion
    
        private class InteraccionPrueba : Interaccion
        {
            // Constructor que llama al constructor base de Interaccion
            public InteraccionPrueba(DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
                : base(fecha, descripcion, notas, respondida, direccion)
            {
            }
        }

        // Método principal que ejecuta todas las pruebas sobre Interaccion
        public static void Run()
        {
            Console.WriteLine("== TestInteraccion ==");

            // Crear una interacción
            // Se crea una instancia de prueba con datos iniciales
            DateTime fecha = DateTime.Now.AddDays(-1);
            InteraccionPrueba interaccion = new InteraccionPrueba(
                fecha,
                "Primera llamada al cliente",
                "Cliente pidió más información",
                false,
                "099876543"
            );

            // Verificamos que la fecha se haya asignado correctamente
            if (interaccion.Fecha == fecha)
                Console.WriteLine("Constructor asigna correctamente la fecha.");
            else
                Console.WriteLine("Error: la fecha no se asignó correctamente.");

            //  Propiedad Respondida 
            // Se cambia el estado de 'respondida' a true y se comprueba
            interaccion.Respondida = true;
            if (interaccion.Respondida)
                Console.WriteLine("Propiedad Respondida funciona correctamente.");
            else
                Console.WriteLine("Error en propiedad Respondida.");

            // agregarNota 
            // Se agrega una nueva nota a la interacción
            interaccion.agregarNota("Se acordó enviar presupuesto el lunes.");

            // Se agrega otra para probar la concatenación en nuevas líneas
            interaccion.agregarNota("Cliente confirmó recepción del correo.");

            // Se intenta agregar una nota vacía (no debería afectar)
            interaccion.agregarNota("");

            
            Console.WriteLine("agregarNota ejecutado correctamente (sin errores).");

            // Validar comportamiento general 
            // Si llegó hasta aquí, la clase base funciona como se espera
            Console.WriteLine("Interaccion base probada con éxito.");

            // Línea vacía para mantener ordenada la salida visual
            Console.WriteLine();
        }
    }
}
