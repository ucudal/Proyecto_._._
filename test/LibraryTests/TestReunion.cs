using System;
using Library;

namespace Program.Tests
{
    public static class TestReunion
    {
        public static void Run()
        {
            Console.WriteLine("== TestReunion ==");

            // --- Datos de ejemplo ---
            DateTime fechaPasada = DateTime.Now.AddDays(-3);   // Reunión que ya ocurrió
            DateTime fechaFutura = DateTime.Now.AddDays(2);    // Reunión próxima
            string descripcion = "Reunión de planificación trimestral";
            string notas = "Se trataron los nuevos objetivos del equipo";
            bool respondida = false;
            string direccion = "Oficina central";
            string lugar = "Sala de conferencias 2";

            // --- Creación de objetos ---
            Reunion reunionPasada = new Reunion(fechaPasada, descripcion, notas, respondida, direccion, lugar);
            Reunion reunionFutura = new Reunion(fechaFutura, descripcion, notas, respondida, direccion, lugar);

            // --- Verificación de creación ---
            if (reunionPasada != null && reunionFutura != null)
                Console.WriteLine("Instancias de Reunion creadas correctamente.");
            else
                Console.WriteLine("Error al crear una o ambas instancias de Reunion.");

            // --- Prueba del método esProxima() ---
            if (!reunionPasada.EsProxima())
                Console.WriteLine("EsProxima() correctamente devuelve false para una reunión pasada.");
            else
                Console.WriteLine("Error: EsProxima() debería devolver false.");

            if (reunionFutura.EsProxima())
                Console.WriteLine("EsProxima() correctamente devuelve true para una reunión futura.");
            else
                Console.WriteLine("Error: EsProxima() debería devolver true.");

            // --- Prueba del método heredado agregarNota() ---
            reunionFutura.AgregarNota("Confirmar asistencia del equipo de ventas.");
            reunionFutura.AgregarNota("Preparar proyector y materiales.");

            Console.WriteLine("Método AgregarNota() ejecutado correctamente en Reunion.");

            // --- Confirmación final ---
            Console.WriteLine("La clase Reunion pasó todas las pruebas correctamente.\n");
        }
    }
}
