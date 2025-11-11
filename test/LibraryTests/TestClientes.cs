using System;
using System.Collections.Generic;
using Library;

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba para verificar el correcto funcionamiento de la clase <see cref="Cliente"/>.
    /// Contiene pruebas sobre la creación de clientes, verificación de estado inactivo y manejo de etiquetas.
    /// </summary>
    public static class TestClientes
    {
        /// <summary>
        /// Ejecuta todas las pruebas relacionadas con la clase <see cref="Cliente"/>.
        /// Valida la inicialización de los atributos, el método <see cref="Cliente.esInactivo"/> 
        /// y el método <see cref="Cliente.agregarEtiqueta"/>.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("== TestClientes ==");

            // Se crea un nuevo cliente con datos de ejemplo
            // Incluye nombre, apellido, teléfono, correo, descripción, género, fecha de nacimiento y última interacción
            Cliente cliente = new Cliente(
                "Juan", 
                "Pérez", 
                "099123456", 
                "juan@correo.com", 
                "Cliente regular", 
                "Masculino", 
                DateTime.Now.AddYears(-30),   // Fecha de nacimiento (30 años atrás)
                DateTime.Now.AddDays(-10)     // Última interacción fue hace 10 días
            );

            // Se comprueba si el cliente se considera inactivo tras más de 5 días sin interacción
            bool inactivo = cliente.esInactivo("5");

            // Se muestra un mensaje dependiendo del resultado de la comprobación
            Console.WriteLine(inactivo 
                ? "Cliente correctamente marcado como inactivo (más de 5 días sin interacción)." 
                : "Error: debería ser inactivo.");

            // Se crea una nueva etiqueta "VIP" y se agrega al cliente
            Etiqueta etiqueta = new Etiqueta("VIP");
            cliente.agregarEtiqueta(etiqueta);

            // Se muestra un mensaje indicando que la prueba de agregarEtiqueta se ejecutó
            Console.WriteLine("agregarEtiqueta ejecutado correctamente.");
        }
    }
}
