using System;
using Library;

namespace Program.Tests
{
    // Clase de prueba para verificar el correcto funcionamiento de GestorUsuarios
    public static class TestGestorUsuarios
    {
        // Método principal que ejecuta todas las pruebas del gestor de Usuarios
        public static void Run()
        {
            Console.WriteLine("== TestGestorUsuarios ==");

            // Se obtiene la instancia única (Singleton)
            // Esto asegura que todos los lugares del programa usen el mismo gestor
            GestorUsuarios gestor = GestorUsuarios.Instancia;

            // AgregarUsuario 
            // Se agrega un nuevo usuario activo con la fecha actual
            int idUsuario = gestor.AgregarUsuario(true, DateTime.Now);

            // Se obtiene el usuario recién agregado
            Usuario usuario = gestor.ObtenerUsuario(idUsuario);

            // Se verifica que los datos sean correctos
            if (usuario != null && usuario.Activo)
                Console.WriteLine("AgregarUsuario funciona correctamente (usuario creado y activo).");
            else
                Console.WriteLine("Error en AgregarUsuario.");

            //  ObtenerUsuario
            // Se intenta recuperar el mismo usuario por su ID
            Usuario obtenido = gestor.ObtenerUsuario(idUsuario);
            if (obtenido != null && obtenido.Id == idUsuario)
                Console.WriteLine("ObtenerUsuario devuelve correctamente el usuario solicitado.");
            else
                Console.WriteLine("Error en ObtenerUsuario.");

            //  ActualizarActivo
            // Cambiamos el estado del usuario a inactivo
            bool actualizado = gestor.ActualizarActivo(idUsuario, false);

            // Comprobamos que el cambio haya sido aplicado
            if (actualizado && !usuario.Activo)
                Console.WriteLine("ActualizarActivo actualiza correctamente el estado del usuario.");
            else
                Console.WriteLine("Error en ActualizarActivo.");

            // MostrarTodosUsuarios
            // Mostramos por consola todos los usuarios almacenados
            Console.WriteLine("Mostrando todos los usuarios registrados:");
            gestor.MostrarTodosUsuarios();

            // EliminarUsuario 
            // Eliminamos al usuario recién creado
            bool eliminado = gestor.EliminarUsuario(idUsuario);

            // Intentamos obtenerlo de nuevo para confirmar que fue borrado
            Usuario eliminadoCheck = gestor.ObtenerUsuario(idUsuario);

            if (eliminado && eliminadoCheck == null)
                Console.WriteLine("EliminarUsuario elimina correctamente al usuario.");
            else
                Console.WriteLine("Error en EliminarUsuario.");

            // Comportamiento del Singleton 
            // Obtenemos otra instancia del gestor (debería ser la misma)
            GestorUsuarios otraInstancia = GestorUsuarios.Instancia;

            // Se verifica que ambas variables apunten al mismo objeto en memoria
            if (ReferenceEquals(gestor, otraInstancia))
                Console.WriteLine("El patrón Singleton funciona correctamente (una sola instancia activa).");
            else
                Console.WriteLine("Error: se detectaron múltiples instancias del gestor.");

            // Línea vacía para mantener ordenada la salida visual
            Console.WriteLine();
        }
    }
}
