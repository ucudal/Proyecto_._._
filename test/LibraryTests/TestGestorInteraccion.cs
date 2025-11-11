using System;
using Library;

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba para verificar el correcto funcionamiento de <see cref="GestorInteracciones"/>.
    /// Contiene pruebas sobre la creación, obtención, eliminación y manejo de tipos inválidos de interacciones.
    /// </summary>
    public static class TestGestorInteracciones
    {
        /// <summary>
        /// Ejecuta todas las pruebas del gestor de interacciones.
        /// Valida los métodos <see cref="GestorInteracciones.AgregarInteraccion"/>,
        /// <see cref="GestorInteracciones.ObtenerInteraccion"/>,
        /// <see cref="GestorInteracciones.MostrarTodasInteracciones"/> y
        /// <see cref="GestorInteracciones.EliminarInteraccion"/>.
        /// También verifica el manejo de tipos de interacción no válidos.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("== TestGestorInteracciones ==");

            // Obtener instancia única del GestorInteracciones (Singleton)
            GestorInteracciones gestor = GestorInteracciones.Instancia;

            // AgregarInteraccion: crear una llamada
            int idLlamada = gestor.AgregarInteraccion(
                "llamada",
                DateTime.Now.AddDays(-2),
                "Llamada con cliente",
                "Habló sobre presupuestos",
                true,
                "099123456"
            );

            // Verificar creación correcta
            Interaccion interaccion = gestor.ObtenerInteraccion(idLlamada);
            if (interaccion != null && interaccion.GetType().Name == "Llamada")
                Console.WriteLine("AgregarInteraccion crea correctamente una interacción de tipo Llamada.");
            else
                Console.WriteLine("Error al crear la interacción de tipo Llamada.");

            // AgregarInteraccion con tipo inválido
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

            // ObtenerInteraccion: validar obtención correcta
            Interaccion encontrada = gestor.ObtenerInteraccion(idLlamada);
            if (encontrada != null && encontrada.Id == idLlamada)
                Console.WriteLine("ObtenerInteraccion devuelve la interacción correcta.");
            else
                Console.WriteLine("Error en ObtenerInteraccion.");

            // MostrarTodasInteracciones: mostrar todas las interacciones registradas
            Console.WriteLine("Mostrando todas las interacciones registradas:");
            gestor.MostrarTodasInteracciones();

            // EliminarInteraccion: eliminar la interacción creada
            bool eliminada = gestor.EliminarInteraccion(idLlamada);
            Interaccion eliminadaCheck = gestor.ObtenerInteraccion(idLlamada);
            if (eliminada && eliminadaCheck == null)
                Console.WriteLine("EliminarInteraccion elimina correctamente la interacción.");
            else
                Console.WriteLine("Error en EliminarInteraccion.");

            Console.WriteLine();
        }
    }
}
