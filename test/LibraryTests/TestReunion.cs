using System;
using Library;

namespace Program.Tests
{
    public static class TestReunion
    {
        public static void Run()
        {
            Console.WriteLine("== TestReunion ==");

            //  Datos de ejemplo
            // Creamos los valores iniciales 
            DateTime fechaPasada = DateTime.Now.AddDays(-3);   // Reunión que ya ocurrió
            DateTime fechaFutura = DateTime.Now.AddDays(2);    // Reunión que está por venir
            string descripcion = "Reunión de planificación trimestral";
            string notas = "Se trataron los nuevos objetivos del equipo";
            bool respondida = false;  // No requiere respuesta, solo control interno
            string direccion = "Oficina central";
            string lugar = "Sala de conferencias 2";

            // Creación de objetos
            // Creamos dos reuniones: una pasada y una futura
            Reunion reunionPasada = new Reunion(fechaPasada, descripcion, notas, respondida, direccion, lugar);
            Reunion reunionFutura = new Reunion(fechaFutura, descripcion, notas, respondida, direccion, lugar);

            // Verificación de creación 
            if (reunionPasada != null && reunionFutura != null)
                Console.WriteLine("Instancias de Reunion creadas correctamente.");
            else
                Console.WriteLine("Error al crear una o ambas instancias de Reunion.");

            // Prueba del método esProxima()
            // Este método debe devolver true solo si la reunión está programada a futuro
            if (!reunionPasada.esProxima())
                Console.WriteLine("esProxima() correctamente devuelve false para una reunión pasada.");
            else
                Console.WriteLine("Error: esProxima() debería devolver false.");

            if (reunionFutura.esProxima())
                Console.WriteLine("esProxima() correctamente devuelve true para una reunión futura.");
            else
                Console.WriteLine("Error: esProxima() debería devolver true.");

            // Prueba del método heredado agregarNota()
            // Se agregan nuevas notas para verificar que el método funciona sin errores
            reunionFutura.agregarNota("Confirmar asistencia del equipo de ventas.");
            reunionFutura.agregarNota("Preparar proyector y materiales.");

            Console.WriteLine("Método agregarNota() ejecutado correctamente en Reunion.");

            // Confirmación final 
            Console.WriteLine("La clase Reunion pasó todas las pruebas correctamente.");

            Console.WriteLine();
        }
    }
}
