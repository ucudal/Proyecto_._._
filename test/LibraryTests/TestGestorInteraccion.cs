using System;
using Library;

namespace Program.Tests
{
    // Clase de prueba para verificar el correcto funcionamiento de GestorInteracciones
    public static class TestGestorInteracciones
    {
        // Método principal que ejecuta las pruebas del gestor de interacciones
        public static void Run()
        {
            Console.WriteLine("== TestGestorInteracciones ==");

            // Se obtiene la instancia única del gestor (Singleton)
            GestorInteracciones gestor = GestorInteracciones.Instancia;

            // AgregarInteraccion 
            int idLlamada = gestor.AgregarInteraccion(
                "llamada",
                DateTime.Now.AddDays(-2),
                "Llamada con cliente",
                "Habló sobre presupuestos",
                true,
                "099123456"
            );

            // Se verifica que la llamada haya sido agregada correctamente
            Interaccion interaccion = gestor.ObtenerInteraccion(idLlamada);
            if (interaccion != null && interaccion.GetType().Name == "Llamada")
                Console.WriteLine("AgregarInteraccion crea correctamente una interacción de tipo Llamada.");
            else
                Console.WriteLine("Error al crear la interacción de tipo Llamada.");

            //  AgregarInteraccion 
            int idInvalido = gestor.AgregarInteraccion(
                "video",
                DateTime.Now,
                "Intento de tipo no válido",
                "",
                false,
                ""
            );
            if (idInvalido == -1)
                Console.WriteLine("AgregarInteraccion maneja correctamente tipos no válidos.");
            else
                Console.WriteLine("Error: se aceptó un tipo de interacción inválido.");

            //  ObtenerInteraccion 
            Interaccion encontrada = gestor.ObtenerInteraccion(idLlamada);
            if (encontrada != null && encontrada.Id == idLlamada)
                Console.WriteLine("ObtenerInteraccion devuelve la interacción correcta.");
            else
                Console.WriteLine("Error en ObtenerInteraccion.");

            // MostrarTodasInteracciones 
            Console.WriteLine("Mostrando todas las interacciones registradas:");
            gestor.MostrarTodasInteracciones();

            // EliminarInteraccion 
            bool eliminada = gestor.EliminarInteraccion(idLlamada);
            Interaccion eliminadaCheck = gestor.ObtenerInteraccion(idLlamada);

            if (eliminada && eliminadaCheck == null)
                Console.WriteLine("EliminarInteraccion elimina correctamente la interacción.");
            else
                Console.WriteLine("Error en EliminarInteraccion.");

            // Línea vacía para mantener ordenada la salida en consola
            Console.WriteLine();
        }
    }
}
