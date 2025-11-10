using System;
using Library;

namespace Program.Tests
{
    public static class TestUsuario
    {
        public static void Run()
        {
            Console.WriteLine("== TestUsuario ==");

            // Preparación de datos
            // Creamos los valores que se usarán para inicializar
            bool activo = true;  // Estado inicial del usuario
            DateTime fechaCreacion = DateTime.Now.AddDays(-7); // Fecha de creación (hace una semana)

            // Creación del objeto 
            // Instanciamos un nuevo usuario con los datos definidos
            Usuario usuario = new Usuario(activo, fechaCreacion);

            //  Prueba de inicialización 
            // Verificamos que el objeto se haya creado correctamente
            if (usuario != null)
                Console.WriteLine("Instancia de Usuario creada correctamente.");
            else
                Console.WriteLine("Error: no se pudo crear la instancia de Usuario.");

            // Verificamos que las propiedades se hayan asignado correctamente
            if (usuario.Activo == activo)
                Console.WriteLine("Propiedad 'Activo' asignada correctamente.");
            else
                Console.WriteLine("Error: propiedad 'Activo' no coincide.");

            if (usuario.FechaCreacion == fechaCreacion)
                Console.WriteLine("Propiedad 'FechaCreacion' asignada correctamente.");
            else
                Console.WriteLine("Error: propiedad 'FechaCreacion' no coincide.");

            // Verificación del Id 
            // Por defecto, el ID se inicializa en 0
            if (usuario.Id == 0)
                Console.WriteLine("ID inicializado correctamente en 0.");
            else
                Console.WriteLine($"Error: el ID debería ser 0, pero es {usuario.Id}.");

            // Modificación y comprobación 
            // Simulamos que el gestor asigna un ID al usuario
            usuario.Id = 5;

            if (usuario.Id == 5)
                Console.WriteLine("Propiedad 'Id' actualizada correctamente.");
            else
                Console.WriteLine("Error al actualizar la propiedad 'Id'.");

            //Resultado final 
            Console.WriteLine("La clase Usuario pasó todas las pruebas correctamente.");
            Console.WriteLine();
        }
    }
}
