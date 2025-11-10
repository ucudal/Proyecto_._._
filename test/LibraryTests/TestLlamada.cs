using System;
using Library;

namespace Program.Tests
{
    public static class TestLlamada
    {
        public static void Run()
        {
            Console.WriteLine("== TestLlamada ==");

            // Creamos datos de ejemplo para inicializar 
            DateTime fecha = DateTime.Now.AddDays(-1);  // Fecha de la llamada (ayer)
            string descripcion = "Llamada de seguimiento";  // Breve descripción
            string notas = "Cliente interesado en renovar contrato";  // Notas iniciales
            bool respondida = true;  // Indicamos que la llamada fue respondida
            string direccion = "Oficina Central";  // Lugar o dirección asociada
            string duracion = "15 minutos";  // Duración de la llamada

            // Creamos una nueva instancia de Llamada con todos los datos
            // Este constructor utiliza también el de la clase base (Interaccion)
            Llamada llamada = new Llamada(fecha, descripcion, notas, respondida, direccion, duracion);

            // Verificamos que el objeto se haya creado correctamente (no sea null)
            if (llamada != null)
                Console.WriteLine("Instancia creada correctamente.");
            else
                Console.WriteLine("Error al crear la instancia de Llamada.");

            // Comprobamos que la propiedad Fecha haya sido asignada correctamente
            if (llamada.Fecha == fecha)
                Console.WriteLine("Fecha asignada correctamente.");
            else
                Console.WriteLine("Error: la fecha no coincide.");

            // Probamos el método agregarNota heredado desde la clase base Interaccion
            // Este método debe agregar las nuevas notas, separadas por saltos de línea
            llamada.agregarNota("Se acordó próxima reunión.");
            llamada.agregarNota("Cliente confirmó asistencia.");

            // Mostramos un mensaje indicando que se ejecutó sin errores
            Console.WriteLine("Método agregarNota ejecutado sin errores.");

            // Mostramos por consola todas las notas combinadas
            Console.WriteLine("Notas agregadas correctamente a la interacción.");

            Console.WriteLine();
        }
    }
}
