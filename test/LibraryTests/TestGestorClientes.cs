using System;
using Library;

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba para verificar el correcto funcionamiento de <see cref="GestorClientes"/>.
    /// Contiene pruebas sobre la creación, obtención, actualización, eliminación y visualización de clientes.
    /// </summary>
    public static class TestGestorClientes
    {
        /// <summary>
        /// Ejecuta todas las pruebas del gestor de clientes.
        /// Valida los métodos <see cref="GestorClientes.AgregarCliente"/>,
        /// <see cref="GestorClientes.ObtenerCliente"/>,
        /// <see cref="GestorClientes.ActualizarEmail"/>,
        /// <see cref="GestorClientes.MostrarTodosClientes"/> y
        /// <see cref="GestorClientes.EliminarCliente"/>.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("== TestGestorClientes ==");

            // Obtener instancia única del GestorClientes (Singleton)
            GestorClientes gestor = GestorClientes.Instancia;

            // AgregarCliente: crear un nuevo cliente
            int idCliente = gestor.AgregarCliente("Ana", "García", "ana@mail.com", "099111222");

            // Verificar creación correcta
            Cliente cliente = gestor.ObtenerCliente(idCliente);
            if (cliente != null && cliente.Nombre == "Ana" && cliente.Apellido == "García")
                Console.WriteLine("AgregarCliente funciona correctamente.");
            else
                Console.WriteLine("Error en AgregarCliente.");

            // ObtenerCliente: validar obtención correcta
            Cliente clienteObtenido = gestor.ObtenerCliente(idCliente);
            if (clienteObtenido != null && clienteObtenido.Id == idCliente)
                Console.WriteLine("ObtenerCliente devuelve el cliente correcto.");
            else
                Console.WriteLine("Error en ObtenerCliente.");

            // ActualizarEmail: actualizar correo electrónico del cliente
            bool actualizado = gestor.ActualizarEmail(idCliente, "nuevo@mail.com");
            if (actualizado && cliente.Email == "nuevo@mail.com")
                Console.WriteLine("ActualizarEmail actualiza correctamente el correo.");
            else
                Console.WriteLine("Error en ActualizarEmail.");

            // MostrarTodosClientes: mostrar todos los clientes registrados
            Console.WriteLine("Mostrando todos los clientes registrados:");
            gestor.MostrarTodosClientes();

            // EliminarCliente: eliminar cliente recién creado
            bool eliminado = gestor.EliminarCliente(idCliente);
            Cliente clienteEliminado = gestor.ObtenerCliente(idCliente);
            if (eliminado && clienteEliminado == null)
                Console.WriteLine("EliminarCliente elimina correctamente al cliente.");
            else
                Console.WriteLine("Error en EliminarCliente.");

            Console.WriteLine();
        }
    }
}
