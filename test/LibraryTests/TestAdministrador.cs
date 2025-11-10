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

            // Se prueba la creación de un usuario a través del método CrearUsuario
            Usuario nuevoUsuario = admin.CrearUsuario("Juan", "Pérez", "juan@correo.com");

            // Se comprueba que el usuario se haya creado correctamente y esté activo
            if (nuevoUsuario != null && nuevoUsuario.Activo)
                Console.WriteLine("CrearUsuario crea un usuario activo correctamente.");
            else
                Console.WriteLine("Error en CrearUsuario.");

            // Se prueba el método SuspenderUsuario (pasando el Id)
            admin.SuspenderUsuario(nuevoUsuario.Id);

            // Se verifica que el usuario haya sido suspendido correctamente
            if (!nuevoUsuario.Activo)
                Console.WriteLine("SuspenderUsuario funciona correctamente.");
            else
                Console.WriteLine("Error en SuspenderUsuario.");

            // Se prueba EliminarUsuario (también por Id)
            admin.EliminarUsuario(nuevoUsuario.Id);
            Console.WriteLine("EliminarUsuario ejecutado (sin implementación actual).");

            // Línea vacía para mantener ordenada la salida en consola
            Console.WriteLine();
        }
    }
}
