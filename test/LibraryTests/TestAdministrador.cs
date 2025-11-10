using System;
using Library;

namespace Program.Tests
{
    // Clase de prueba para verificar el correcto funcionamiento de la clase Administrador
    public static class TestAdministrador
    {
        // Método principal que ejecuta todas las pruebas de la clase Administrador
        public static void Run()
        {
            Console.WriteLine("== TestAdministrador ==");

            // Se crea un administrador activo con fecha de creación actual
            Administrador admin = new Administrador(true, DateTime.Now);

            // Se verifica que las propiedades se asignen correctamente
            if (admin.Activo && admin.FechaCreacion.Date == DateTime.Now.Date)
                Console.WriteLine("Constructor y propiedades funcionan correctamente.");
            else
                Console.WriteLine("Error en la inicialización del Administrador.");

            // Se prueba la creación de un usuario a través del método crearUsuario
            Usuario nuevoUsuario = admin.crearUsuario("Juan", "Pérez", "juan@correo.com");

            // Se comprueba que el usuario se haya creado correctamente y esté activo
            if (nuevoUsuario != null && nuevoUsuario.Activo)
                Console.WriteLine("crearUsuario crea un usuario activo correctamente.");
            else
                Console.WriteLine("Error en crearUsuario.");

            // Se prueba el método suspenderUsuario
            admin.suspenderUsuario(nuevoUsuario);

            // Se verifica que el usuario haya sido suspendido correctamente
            if (!nuevoUsuario.Activo)
                Console.WriteLine("suspenderUsuario funciona correctamente.");
            else
                Console.WriteLine("Error en suspenderUsuario.");

            // Se prueba eliminarUsuario (aunque actualmente no tiene implementación)
            admin.eliminarUsuario(nuevoUsuario);
            Console.WriteLine("eliminarUsuario ejecutado (sin implementación actual).");

            // Línea vacía para mantener ordenada la salida en consola
            Console.WriteLine();
        }
    }
}
