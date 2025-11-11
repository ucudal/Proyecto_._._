using System;
using Library;

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba para verificar el correcto funcionamiento de <see cref="GestorUsuarios"/>.
    /// Contiene pruebas sobre la creación, obtención, actualización, eliminación de usuarios
    /// y la validación del patrón Singleton.
    /// </summary>
    public static class TestGestorUsuarios
    {
        /// <summary>
        /// Ejecuta todas las pruebas del gestor de usuarios.
        /// Verifica los métodos <see cref="GestorUsuarios.AgregarUsuario"/>,
        /// <see cref="GestorUsuarios.ObtenerUsuario"/>, <see cref="GestorUsuarios.ActualizarActivo"/>,
        /// <see cref="GestorUsuarios.EliminarUsuario"/> y <see cref="GestorUsuarios.MostrarTodosUsuarios"/>.
        /// También valida el comportamiento del Singleton.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("== TestGestorUsuarios ==");

            // Obtener instancia única del GestorUsuarios (Singleton)
            GestorUsuarios gestor = GestorUsuarios.Instancia;

            // AgregarUsuario: crear un nuevo usuario activo con fecha actual
            int idUsuario = gestor.AgregarUsuario(true, DateTime.Now);

            // ObtenerUsuario: recuperar el usuario recién agregado
            Usuario usuario = gestor.ObtenerUsuario(idUsuario);

            // Verificación de datos
            if (usuario != null && usuario.Activo)
                Console.WriteLine("AgregarUsuario funciona correctamente (usuario creado y activo).");
            else
                Console.WriteLine("Error en AgregarUsuario.");

            // ObtenerUsuario por ID
            Usuario obtenido = gestor.ObtenerUsuario(idUsuario);
            if (obtenido != null && obtenido.Id == idUsuario)
                Console.WriteLine("ObtenerUsuario devuelve correctamente el usuario solicitado.");
            else
                Console.WriteLine("Error en ObtenerUsuario.");

            // ActualizarActivo: cambiar estado del usuario a inactivo
            bool actualizado = gestor.ActualizarActivo(idUsuario, false);
            if (actualizado && !usuario.Activo)
                Console.WriteLine("ActualizarActivo actualiza correctamente el estado del usuario.");
            else
                Console.WriteLine("Error en ActualizarActivo.");

            // MostrarTodosUsuarios: mostrar todos los usuarios almacenados
            Console.WriteLine("Mostrando todos los usuarios registrados:");
            gestor.MostrarTodosUsuarios();

            // EliminarUsuario: eliminar al usuario recién creado
            bool eliminado = gestor.EliminarUsuario(idUsuario);

            // Confirmar eliminación
            Usuario eliminadoCheck = gestor.ObtenerUsuario(idUsuario);
            if (eliminado && eliminadoCheck == null)
                Console.WriteLine("EliminarUsuario elimina correctamente al usuario.");
            else
                Console.WriteLine("Error en EliminarUsuario.");

            // Validación del Singleton: obtener otra instancia y verificar referencia
            GestorUsuarios otraInstancia = GestorUsuarios.Instancia;
            if (ReferenceEquals(gestor, otraInstancia))
                Console.WriteLine("El patrón Singleton funciona correctamente (una sola instancia activa).");
            else
                Console.WriteLine("Error: se detectaron múltiples instancias del gestor.");

            Console.WriteLine();
        }
    }
}
